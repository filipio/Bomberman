using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [SerializeField] private AudioSource explosionSound;

    private int numberToRespawnAPrefab = 7;

    [Header("PowerUps")]
    public GameObject powerUpSpeedPrefab;
    public GameObject powerUpBombAmountPrefab;
    public GameObject powerUpBombExplosionRangePrefab;
    public GameObject powerUpBombMovingPrefab;

    private Vector2 positionOfABoxPrefabRespawn;


    [SerializeField]
    private float explosionDuration = 0.4f;

    private void Start()
    {
        explosionSound.Play();
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    { if(collider.CompareTag("Player"))
        {
           collider.gameObject.GetComponent<PlayerLife>().LoseLife();

        }
        if(collider.CompareTag("Bomb"))
        {
            collider.gameObject.GetComponent<BombExplosion>().Explode();
        }

    if(collider.CompareTag("Block"))
        {   if (!collider.GetComponent<BlockBeingDestroyed>().enabled)
            {
                positionOfABoxPrefabRespawn = collider.gameObject.transform.position;
                collider.GetComponent<BlockBeingDestroyed>().enabled = true;

                int randomBeginingValue = 7;
                int randomEndingValue = 9;
                int randomNumber = Random.Range(randomBeginingValue, randomEndingValue);

                if (randomNumber == numberToRespawnAPrefab)
                {
                    StartCoroutine(RespawnPrefabPowerUp(randomBeginingValue, randomEndingValue));
                }
            }
        }
    if(collider.CompareTag("PowerUpBomb") && collider.gameObject.GetComponent<PowerUps>().isVulnerable)
        {
            Destroy(collider.gameObject);
        }
        if (collider.CompareTag("PowerUpSpeed") && collider.gameObject.GetComponent<PowerUps>().isVulnerable)
        {
            Destroy(collider.gameObject);
        }
        if (collider.CompareTag("PowerUpExplosion") && collider.gameObject.GetComponent<PowerUps>().isVulnerable)
        {
            Destroy(collider.gameObject);
        }
        if (collider.CompareTag("PowerUpBombMoving") && collider.gameObject.GetComponent<PowerUps>().isVulnerable)
        {
            Destroy(collider.gameObject);
        }


    }

    IEnumerator RespawnPrefabPowerUp(int randomBeginingValue, int randomEndingValue)
    {
        yield return new WaitForSeconds(explosionDuration);      

            randomBeginingValue -= 7;
            randomEndingValue -= 5;
           int randomNumber = Random.Range(randomBeginingValue, randomEndingValue);
        switch (randomNumber)
        {
            case 0:
                _ = Instantiate(powerUpSpeedPrefab, positionOfABoxPrefabRespawn, Quaternion.identity) as GameObject;
                break;
            case 1:
                _ = Instantiate(powerUpBombAmountPrefab, positionOfABoxPrefabRespawn, Quaternion.identity) as GameObject;
                break;
            case 2:
                _ = Instantiate(powerUpBombExplosionRangePrefab, positionOfABoxPrefabRespawn, Quaternion.identity) as GameObject;
                break;
            case 3:
                _ = Instantiate(powerUpBombMovingPrefab, positionOfABoxPrefabRespawn, Quaternion.identity) as GameObject;
                break;

        }
    }

}
