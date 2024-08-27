using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float horizontal;
    private bool isJump;
    private Vector2 direction = Vector2.down;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float Jumps;
    [SerializeField] private LayerMask groundLayer;
    
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontal*speed, rigidbody2D.velocity.y);

        if (isJump == true)
        {
            Salto();
        }
    }
    private void Salto()
    {
        if (Physics2D.Raycast(transform.position, direction, 1.03f, groundLayer))
        {
            if (isJump&&Jumps>0)
            {
                rigidbody2D.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
                --Jumps;
            }
            else
            {
                Jumps = 2;
            }
        }
        isJump= Physics2D.Raycast(transform.position, direction, 1.03f, groundLayer);
    }
}
