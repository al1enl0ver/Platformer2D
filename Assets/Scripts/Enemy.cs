using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2f;
    public float jumpForce = 2f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGroundedLeft, isGroundedRight;
    private Vector2 leftRayOrigin, rightRayOrigin;
    private bool shouldJump;
    private bool hasJumped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        leftRayOrigin = new Vector2(transform.position.x - 0.7f, transform.position.y);
        rightRayOrigin = new Vector2(transform.position.x + 0.65f, transform.position.y);
        isGroundedLeft = Physics2D.Raycast(leftRayOrigin, Vector2.down, 1f, groundLayer);
        isGroundedRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, 1f, groundLayer);
        Debug.DrawRay(leftRayOrigin, Vector2.down * 1.5f, Color.red);
        Debug.DrawRay(rightRayOrigin, Vector2.down * 1.5f, Color.red);
        float direction = Mathf.Sign(player.position.x - transform.position.x);
        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, 1 << player.gameObject.layer);

        if (isGroundedLeft || isGroundedRight)
        {
            hasJumped = false;
            rb.velocity = new Vector2(direction * chaseSpeed, rb.velocity.y);

            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2f, groundLayer);
            RaycastHit2D gapAhead = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2f, groundLayer);
            RaycastHit2D platformAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, groundLayer);

            if (!groundInFront.collider && !gapAhead)
            {
                shouldJump = true;
            }
            else if (isPlayerAbove && platformAbove.collider)
            {
                shouldJump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if ((isGroundedLeft || isGroundedRight) && shouldJump && !hasJumped)
        {
            shouldJump = false;
            hasJumped = true;
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 jumpDirection = direction * jumpForce;
            rb.AddForce(new Vector2(jumpDirection.x, jumpForce), ForceMode2D.Impulse);
        }
    }
}
