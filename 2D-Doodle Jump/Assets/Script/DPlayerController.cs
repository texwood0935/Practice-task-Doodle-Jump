using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlayerController : MonoBehaviour {

    public static bool isUP = false;
    public float upperForce = 250f;
    public float rightPosition = 250f;
    public float leftPosition = 250f;

    private Rigidbody2D rb2d;               
    private Animator animator;              
    private bool isRight = false;
    private float rightborden;
    private float leftborden;
    private float highpos;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        leftborden = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x;
        rightborden = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x;
        highpos = transform.position.y;
    }

    void Update()
    {
        Vector3 diff = transform.localPosition;
        if(!DGameController.instance.IsGameover)
        {
            if (DJump.whichis)                                        //control movement
            {
                animator.SetTrigger("Jump");
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upperForce));
                DJump.whichis = false;
                if (highpos+0.1 < transform.position.y)
                {
                    DGameController.instance.Addscore();            //add score
                    highpos = transform.position.y;
                    Debug.Log("*"+highpos.ToString() + "," + transform.position.y.ToString());
                }
                Debug.Log(highpos.ToString() + "," + transform.position.y.ToString());
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(-leftPosition,0));
                isRight = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(rightPosition, 0));
                isRight = true;
            }
            if (rb2d.velocity.y >= 0)
                isUP = true;
            else
                isUP = false;
            if(isRight)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else
                transform.rotation = Quaternion.Euler(0, 0, 0);
            if (transform.localPosition.x < leftborden)
                diff.x = rightborden;
            if (transform.localPosition.x > rightborden)
                diff.x = leftborden;
            transform.localPosition = diff;                //movement control end
            
        }
       
    }

}
