using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCameraFollowing : MonoBehaviour {
    public static bool isMove;
    public GameObject DPlayer;

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        transform.position = Vector3.zero;
        isMove = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!DGameController.instance.IsGameover && DPlayer.transform.position.y >= transform.position.y)
        {
            offset = Vector3.up * (DPlayer.transform.position.y - transform.position.y);
            transform.position = transform.position + offset;
            isMove = true;
        }
        else
            isMove = false;
	}
}
