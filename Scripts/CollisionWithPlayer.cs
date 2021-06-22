using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPlayer : MonoBehaviour
{ private Collider2D thisCollider;


    void Start()
    {
        thisCollider = GetComponent<Collider2D>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider, thisCollider);
           

        }
        
    }



  
}
