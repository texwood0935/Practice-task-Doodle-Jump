using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMovePlate : MonoBehaviour {
    public BoxCollider2D bc2d;
    public BoxCollider2D bc2d1;
    public int speed;

    private float rightborden;
    private float leftborden;
    // Use this for initialization
    void Start()
    {
        bc2d.enabled = true;
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        leftborden = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x;
        rightborden = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (transform.localPosition.x - 0.2 < leftborden)
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0, 0);
        if (transform.localPosition.x + 0.2 > rightborden)
            GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, 0, 0);
        if (transform.position.y < Camera.main.transform.position.y - 4)
            Destroy(this.gameObject);
    }

}
