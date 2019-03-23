using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBody : MonoBehaviour {
    public PolygonCollider2D bc2d1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
            DGameController.instance.IsGameover = true;
    }
}
