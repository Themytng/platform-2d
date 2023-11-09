using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    //variable
    public float speed; //control speed of movement
    float move;         //control direction

    public float jump;
    public bool isJumping;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jump = 400f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");                    //when horizontal keys are pressed, move
        rb.velocity = new Vector2(speed * move, rb.velocity.y); // change the rb to move

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Debug.Log("space");
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping= true;    
         
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
