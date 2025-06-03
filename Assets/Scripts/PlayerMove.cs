using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private float Move;
    private Rigidbody2D rb2d;
    [SerializeField] public float jump;
    [SerializeField] private Animator anim;
    public bool isGrounded;
    public BoxCollider2D groundCollider;
    public LayerMask GroundLayer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
    }

    void Update()
    {
        if (Move >= 0.1f || Move <= -0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        Move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(Move * speed, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jump));
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", false);
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (GroundLayer == (1 << other.gameObject.layer))
        {
            isGrounded = true;
        }
    }
}
