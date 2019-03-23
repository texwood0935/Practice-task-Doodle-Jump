using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < Camera.main.transform.position.y - 4)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Body")
        {
            //Destroy(other.gameObject);
            DGameController.instance.IsGameover = true;
            Debug.Log("true!");
        }
        //if (other.tag == "Footplate"&&other.tag=="DisappearFootPlate")
        if(other.tag!="MainCamera")
            Destroy(other.gameObject);
    }
}
