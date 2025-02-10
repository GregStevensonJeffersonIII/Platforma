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
        rb.velocity= Vector3.right*force;
        Invoke("Die", 4f);
    }
    void Die() {
        Destroy(gameObject);
    }
    
}
