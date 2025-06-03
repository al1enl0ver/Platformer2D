using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private float horizontalInput;
    private bool facingRight;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        SetDirectionByComponent();
    }

    void SetDirectionByComponent()
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
