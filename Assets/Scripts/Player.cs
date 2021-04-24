using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    public BoxCollider2D box;
    public Rigidbody2D rb;
    public bool isGrounded;
    public float jumpForce = 10f;
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Jump();
        Movement();
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            if (transform.rotation.y == 1f)
            {
                transform.RotateAround(transform.position, transform.up, -180f);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            if (transform.rotation.y == 0f)
            {
                transform.RotateAround(transform.position, transform.up, 180f);
            }
        }
    }
    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 1.1f, transform.position.y - 1.1f),
            new Vector2(transform.position.x + 1f, transform.position.y - 1.1f), groundLayers);
    }
}
