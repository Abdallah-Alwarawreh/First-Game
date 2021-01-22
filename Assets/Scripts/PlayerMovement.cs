using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float Speed;
    public float JumpForce;
    [Header("Ground Check")]
    bool IsGrounded;
    public Transform GroundCheck;
    public float CheckRaduis;
    public LayerMask GroundLayer;

    void Update()
    {
        Move();
        GroundChecker();
        Jump();
    }

    void Move()
    {
        //Moveing the player on the x axis
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * Speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }
    void GroundChecker()
    {
        Collider2D coll = Physics2D.OverlapCircle(GroundCheck.position, CheckRaduis, GroundLayer);
        if(coll != null)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

    }
}
