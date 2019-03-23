using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMonster : MonoBehaviour {
    public BoxCollider2D bc2d1;
    public BoxCollider2D bc2d2;
    public Rigidbody2D rb2d;
    public int wheretodestory;

    private Animator animator;
    private float vect;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        rb2d.mass = 0f;
        vect = transform.position.x;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0.1f, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (DPlayerController.isUP)
        {
            bc2d1.enabled = false;
        }
        else
        {
            bc2d1.enabled = true;
        }
        if(transform.position.x>vect+0.05f)
            GetComponent<Rigidbody2D>().velocity = new Vector3(-0.1f, 0, 0);
        if (transform.position.x < vect - 0.05f)
            GetComponent<Rigidbody2D>().velocity = new Vector3(0.1f, 0, 0);
        if (transform.position.y < Camera.main.transform.position.y - wheretodestory)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Foot"&&!DPlayerController.isUP)
        {
            //rb2d.gravityScale = 1;
            //rb2d.mass = 1f;
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, -250));
            bc2d1.enabled = false;
            bc2d2.enabled = false;
            Debug.Log("!");
            DGameController.instance.Addscore();
        }
        if(collision.tag=="Body")
        {
            DGameController.instance.IsGameover = false;
        }
    }
}
