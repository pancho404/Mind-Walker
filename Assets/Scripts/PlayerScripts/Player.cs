using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player self;
    [SerializeField] LayerMask groundLayers;
    public BoxCollider2D box;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator animator;
    public bool isGrounded;
    public bool isPushing;
    
    public float jumpForce = 10f;
    public float speed = 8f;
    public float strenght = 5f;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        SetAnimatorBoolsToFalse();
        GroundCheck();
        Movement();
        OnGround();
        PushAnimator();
    }

    private void PushAnimator()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 0.56f, groundLayers);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 0.6f, groundLayers);
        if (hit)
        {
            animator.SetBool("Pushing", true);
        }
        if (hit2)
        {
            animator.SetBool("Pushing", true);
        }
    }
    private void SetAnimatorBoolsToFalse()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Pushing", false);
    }

    private void Movement()
    {
        Vector2 playerInput;

        // Recogemos el input del jugador
        playerInput.x = Input.GetAxis("Horizontal") * 10f;
       
        // Recordamos la velocidad vertical del Rigidbody
        playerInput.y = rb.velocity.y;

        // Si pulsamos saltar
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Nos da igual la velocidad vertical anterior, ahora queremos que vaya para arriba
            playerInput.y = jumpForce;
            animator.SetBool("Grounded", false);
            animator.SetBool("Jump", true);
        }
        // Asignamos los inputs recogidos al rigidbody
        rb.velocity = playerInput;
        // Si vamos hacia la izquierda
        if (playerInput.x < 0f)
        {
            // Miramos hacia la izquierda
            sprite.flipX = true;
            animator.SetBool("Grounded", true);
            animator.SetBool("Run", true);
        }
        // Si vamos hacia la derecha
        if (playerInput.x > 0f)
        {
            // Miramos hacia la derecha
            sprite.flipX = false;
            animator.SetBool("Grounded", true);
            animator.SetBool("Run", true);
        }
    }
    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 1.1f, transform.position.y - 1.1f),
            new Vector2(transform.position.x + 1f, transform.position.y - 1.1f), groundLayers);
    }

    void OnGround()
    {
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Grounded", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
