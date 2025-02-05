using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    private int direction = 1;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
       RaycastHit2D hit=  Physics2D.Raycast(transform.position, Vector2.down,1f);
        Debug.DrawRay(transform.position, new Vector2(0,-1),Color.red,0.5f);
        if (hit.collider == null)
        {
            direction *= -1;
            rend.flipX = !rend.flipX;
        }
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 1 * direction, transform.position.y), Time.deltaTime);

        RaycastHit2D Headhit = Physics2D.Raycast(transform.position, Vector2.up, 1f);
        if (Headhit.collider != null && Headhit.collider.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
