using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlContr : MonoBehaviour {
    public float speed = 20f;
    private Rigidbody2D rb;
    float moveX;
    private bool faseR=true;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 200000);
        }
        if(moveX>0&&!faseR)
        {
            flip();
        }
        else if (moveX < 0 && faseR )
        {
            flip();
        }
	}
     void flip(){
         faseR = !faseR;
         transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
     }
}
