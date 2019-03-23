using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDisappearFootPlate : MonoBehaviour {
    public BoxCollider2D bc2d;
    public Rigidbody2D rb2d;

    private Animator animator;

    // Use this for initialization
    void Start () {
        bc2d.enabled = true;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (DPlayerController.isUP)
        {
            bc2d.enabled = false;
        }
        else
        {
            bc2d.enabled = true;
        }
        if (transform.position.y < Camera.main.transform.position.y - 4)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Foot")
        {
            animator.SetTrigger("Jump");
            rb2d.gravityScale = 1;
        }  
    }
}
