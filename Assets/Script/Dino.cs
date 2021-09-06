using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D mRb;
    Animator mAnim;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0 && !isDead){         //move right
            mRb.velocity = new Vector2(1f, mRb.velocity.y)*speed;
            mAnim.SetBool("Run",true);
            transform.localScale = new Vector3(transform.localScale.x<0? transform.localScale.x* -1:transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }else if(Input.GetAxisRaw("Horizontal") < 0 && !isDead){   //move left
            mRb.velocity = new Vector2(-1f, mRb.velocity.y)*speed;
            mAnim.SetBool("Run",true);
            transform.localScale = new Vector3(transform.localScale.x>0? transform.localScale.x* -1:transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }else{
            mRb.velocity = new Vector2(0, mRb.velocity.y);
            mAnim.SetBool("Run",false);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        mAnim.SetTrigger("Dead");
        isDead = true;
        mRb.velocity = new Vector2(0, mRb.velocity.y);
    }
}
