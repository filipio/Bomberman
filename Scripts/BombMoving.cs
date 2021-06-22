using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMoving : MonoBehaviour
{
    enum collisionPoint { left, up, right, down};
    private collisionPoint point;
    [SerializeField] private float forceToMove = 400f;
    public bool ableToMoveBomb = false;

    private void Start()
    {//random value
        point = collisionPoint.left;
    }

    void MoveTheBomb(collisionPoint point, Rigidbody2D rb)
    {
        switch (point)
        {
            case collisionPoint.left:
                rb.AddForce(Vector2.right * forceToMove);
                break;
            case collisionPoint.right:
                rb.AddForce(Vector2.left * forceToMove);
                break;
            case collisionPoint.up:
                rb.AddForce(Vector2.down * forceToMove);
                break;
            case collisionPoint.down:
                rb.AddForce(Vector2.up * forceToMove);
                break;

        }
        
    }


    private float RoundToDecimalPlaces(float number, int decimalPlaces)
    {
        return Mathf.Round(number * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();

        if (collider.gameObject.CompareTag("Bomb"))
        {
            if (!ableToMoveBomb)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                foreach (ContactPoint2D contactPoint in collider.contacts)
                {

                    Vector2 contact = contactPoint.point;
                    if (RoundToDecimalPlaces(contact.x, 1) < collider.collider.bounds.center.x)
                    {
                        point = collisionPoint.left;

                    }
                    else if (RoundToDecimalPlaces(contact.x, 1) > collider.collider.bounds.center.x)
                    {
                        point = collisionPoint.right;
                    }
                    else if (RoundToDecimalPlaces(contact.y, 1) < collider.collider.bounds.center.y)
                    {
                        point = collisionPoint.down;
                    }
                    else
                    {
                        point = collisionPoint.up;
                    }
                }
                MoveTheBomb(point,rb);
            }

        }
    }

}
