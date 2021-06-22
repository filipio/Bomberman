using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public AudioSource audioPowerUp;
    public bool isVulnerable = false;
    private float explosionDuration = 0.5f;

    private bool collisionHappened = false;

    private void Awake()
    {
        Invoke("BecomeVulnerable", explosionDuration);
        ResetCollision();
    }

    void BecomeVulnerable() => this.isVulnerable = true;
    void ResetCollision() => collisionHappened = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player") && !collisionHappened)
        {
            collisionHappened = true;
            if(this.gameObject.CompareTag("PowerUpBomb"))
            {
                GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Renderer>().enabled = false;
                collider.gameObject.GetComponent<BombMaking>().AddABomb();
                Destroy(this.gameObject, 0.265f);

            }
            else if(this.gameObject.CompareTag("PowerUpSpeed"))
            {
                GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Renderer>().enabled = false;
                collider.gameObject.GetComponent<Movement>().MovementUpgrade();
                Destroy(this.gameObject, 0.265f);
            }

            else if(this.gameObject.CompareTag("PowerUpExplosion"))
            {
                GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Renderer>().enabled = false;
                collider.gameObject.GetComponent<BombMaking>().BiggerExplosion();
                Destroy(this.gameObject, 0.265f);
            }
            else if(this.gameObject.CompareTag("PowerUpBombMoving"))
            {
                GetComponent<AudioSource>().Play();
                gameObject.GetComponent<Renderer>().enabled = false;
                collider.gameObject.GetComponent<BombMoving>().ableToMoveBomb = true;
                Destroy(this.gameObject, 0.265f);
            }

        }
    }


}
