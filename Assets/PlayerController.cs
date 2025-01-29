using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
   
    public float jumpForce=100;
    public float speed;
    void Start()
    {
        animator =GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        animator.SetFloat("speed",Mathf.Abs(movementVector.x));
        if (movementVector.x > 0)
        {
            spriteRenderer.flipX = false;
            transform.Translate(Vector2.right * speed*Time.deltaTime);
        }
        else if (movementVector.x < 0) {
            spriteRenderer.flipX=true;
            transform.Translate(Vector2.left *speed* Time.deltaTime);
        }
        if (movementVector.y > 1) {
            transform.Translate(Vector2.up*movementVector.y*Time.deltaTime);
            movementVector.y *= 0.9f;
        }

    }
    public void OnMove(InputValue movementValue) {
        movementVector = movementValue.Get<Vector2>();
    }

    public void OnJump()
    {
        movementVector.y = jumpForce;
}
    }
