using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJump : MonoBehaviour {

    public static bool whichis = false;

    //public BoxCollider2D forjump;
    public BoxCollider2D hastrigger;
    public BoxCollider2D nottrigger;
    private Rigidbody mRigidbody;

   // private bool stayCollision = false;

    void Start()
    {
        this.mRigidbody = this.GetComponent<Rigidbody>();
        nottrigger = GetComponent<BoxCollider2D>();
        hastrigger = GetComponent<BoxCollider2D>();
        nottrigger.enabled = true;
        hastrigger.enabled = true;
    }

    void Update()
    {
        if (!DPlayerController.isUP)
        {
            nottrigger.enabled = false;
            hastrigger.enabled = false;
        }
        else
        {
            nottrigger.enabled = true;
            hastrigger.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Footplate"|| collision.tag == "enemy")
        whichis = true;
    }
}
