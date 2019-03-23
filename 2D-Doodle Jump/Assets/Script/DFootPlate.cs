using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFootPlate : MonoBehaviour {
    public BoxCollider2D bc2d;
    public BoxCollider2D bc2d1;

	// Use this for initialization
	void Start () {
        bc2d.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (DPlayerController.isUP)
        {
            bc2d.enabled = false;
            bc2d1.enabled = false;
        }
        else
        {
            bc2d.enabled = true;
            bc2d1.enabled = true;
        }
        if (transform.position.y < Camera.main.transform.position.y - 4)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
