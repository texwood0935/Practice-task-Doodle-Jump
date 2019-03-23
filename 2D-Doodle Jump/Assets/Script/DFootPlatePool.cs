using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFootPlatePool : MonoBehaviour {

    public GameObject[] footplatePrefab;
    public GameObject Hole;
    public GameObject[] MonsterPrefab;
    public GameObject DPlayer;
    public float footplateXMin;       
    public float footplateXMax;         
    public float footplateYHigh;
    public float footplateYMax;
    public float QuantityMax;
    public float High;
    public float StartY;

    private int footplateQuantity;    
    private int ifgiveHole;
    private bool isCreate;
    private float lastHolePos;
    private float lastMonPos;

    void Start()
    {
        isCreate = true;
        lastHolePos = 0.0f;
        lastMonPos = 0.0f;
        {
            GameObject FootPlate = footplatePrefab[Random.Range(0, footplatePrefab.Length)];
            Vector2 spawnPosition = new Vector2(DPlayer.transform.position.x, StartY);
            Instantiate(FootPlate, spawnPosition, Quaternion.identity);
        }
        for (int i=1;i<QuantityMax;)
        {
            GameObject FootPlate = footplatePrefab[Random.Range(0, footplatePrefab.Length)];
            float footplateX = Random.Range(DPlayer.transform.position.x + footplateXMin, DPlayer.transform.position.x + footplateXMax);
            float footplateY = StartY + i * High;
            Vector2 spawnPosition = new Vector2(footplateX, footplateY);
            Instantiate(FootPlate, spawnPosition, Quaternion.identity);
            i++;
            Debug.Log(i.ToString());
        }
    }

    void Update()
    {
        if(!DGameController.instance.IsGameover)
        {
            float footplateY = StartY + QuantityMax * High;
            if (isCreate)
            {
                int ifitcreate = Random.Range(0, 10);
                if(ifitcreate >2)
                {
                    GameObject FootPlate = footplatePrefab[Random.Range(0, footplatePrefab.Length)];
                    float footplateX = Random.Range(DPlayer.transform.position.x+footplateXMin,DPlayer.transform.position.x+footplateXMax);
                    footplateY = StartY + QuantityMax * High;
                    Vector2 spawnPosition = new Vector2(footplateX, footplateY);
                    Instantiate(FootPlate, spawnPosition, Quaternion.identity);
                }
                ifgiveHole = Random.Range(0, 1000);
                int ifisgiveMon = Random.Range(0, 1000);
                if(ifgiveHole<40&&(Camera.main.transform.position.y + footplateYHigh-lastHolePos)>15f)
                {
                    GameObject hole = Hole;
                    float HoleX = Random.Range(DPlayer.transform.position.x + footplateXMin, DPlayer.transform.position.x + footplateXMax);  
                    Vector2 HspawnPosition = new Vector2(HoleX, Camera.main.transform.position.y + footplateYHigh);
                    Instantiate(hole, HspawnPosition, Quaternion.identity);
                    lastHolePos = hole.transform.position.y;
                }
                if (ifisgiveMon < 50&& (Camera.main.transform.position.y + footplateYHigh-lastMonPos)>4f)
                {
                    GameObject Monster = MonsterPrefab[Random.Range(0, MonsterPrefab.Length)];
                    float MfootplateX = Random.Range(DPlayer.transform.position.x + footplateXMin, DPlayer.transform.position.x + footplateXMax);
                    Vector2 MspawnPosition = new Vector2(MfootplateX, Camera.main.transform.position.y + footplateYHigh);
                    Instantiate(Monster, MspawnPosition, Quaternion.identity);
                    lastMonPos = Monster.transform.position.y;
                }
                QuantityMax++;
            }
            if (footplateY - Camera.main.transform.position.y > 10)
                isCreate = false;
            else
                isCreate = true;
        }
        
    }

}
