using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = false;
    private bool jump = false;
    private Rigidbody2D body;

    public float gravMult = 2f;
    public float jumpForce;
    public float speed;
    public float maxSpeed = 7f;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(movementVector.x));
        if (movementVector.x > 0 && body.velocity.x<maxSpeed)
        {
            spriteRenderer.flipX = false;
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            body.AddForce(Vector2.right * speed);

        }
        else if (movementVector.x < 0 && Mathf.Abs(body.velocity.x)<maxSpeed)
        {
            spriteRenderer.flipX = true;
            //transform.Translate(Vector2.left * speed * Time.deltaTime);
            body.AddForce(Vector2.left * speed);
        }
        if (jump)
        {
            //StartCoroutine(LerpJump());
            body.AddForce(Vector2.up * jumpForce);
            jump = false;
            isGrounded = false;
        }
        if (body.velocity.y < 0)
        {
            body.gravityScale = gravMult;
        }
        else { 
            body.gravityScale = 0.5f;
        }
    }
    public void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            jump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    IEnumerator LerpJump()
    {
        float desired =1.5f;
        while (desired>0.1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+desired);
            desired *= 0.7f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundry"))
        {
            GameManager.instance.DecreaseLives();
            SceneManager.LoadScene(0);
        }
    }
}
