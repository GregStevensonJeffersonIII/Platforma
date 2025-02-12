using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float force = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = player.GetComponent<PlayerController>().GetDirection();
        rb.velocity= direction*force;
        Invoke("Die", 4f);
    }
    void Die() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObj=collision.gameObject;
        if(collisionObj.CompareTag("Enemy")||collisionObj.CompareTag("Ground"))
            Die();
    }
}
