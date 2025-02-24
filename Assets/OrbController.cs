using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RaycastHit2D Lefthit = Physics2D.Raycast(transform.position, Vector2.left, 3f);
        RaycastHit2D Righthit = Physics2D.Raycast(transform.position, Vector2.right, 3f);
        if (Lefthit.collider != null && Lefthit.collider.gameObject.CompareTag("Player"))
        {
            rb.velocity=Vector2.left*5;
        }
        else if (Righthit.collider != null && Righthit.collider.gameObject.CompareTag("Player")) {
            rb.velocity = Vector2.right*5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
            Destroy(gameObject);
    }
}
