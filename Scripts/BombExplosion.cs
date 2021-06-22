using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{ 
    public BoxCollider2D boxCollider;
    public GameObject explosionPrefab;


    private bool collisionWithPlayer1 = false;
    private bool collisionWithPlayer2 = false;

    [SerializeField]
    private float explosionDuration = 0.4f;
    private GameObject Player = null;
    private Vector3 roundedPositionOfBomb;


    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player = GameObject.Find("Player2");
           
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Player = GameObject.Find("Player1");
           
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            collisionWithPlayer1 = true;
          
        }
        if(collision.gameObject.name == "Player2")
        {
            collisionWithPlayer2 = true;
            
        }

    }

   

    void OnTriggerExit2D(Collider2D other)
    {if (other.gameObject.name == "Player1") collisionWithPlayer1 = false;
        if (other.gameObject.name == "Player2") collisionWithPlayer2 = false;
        
        if (!collisionWithPlayer1 && !collisionWithPlayer2)
        {
            boxCollider.isTrigger = false;
        }
    }

   

    public void Explode()
    {
        roundedPositionOfBomb = Vector3Int.RoundToInt(this.gameObject.transform.position);
        // creating an explosion in a place where the bomb is
        GameObject explosion = Instantiate(explosionPrefab, roundedPositionOfBomb, Quaternion.identity) as GameObject;
        //destroying it
        Destroy(explosion, this.explosionDuration);
       
        //creating explosions in all directions
        CreateExplosions(Vector2.left, Player);
        CreateExplosions(Vector2.right, Player);
        CreateExplosions(Vector2.up, Player);
        CreateExplosions(Vector2.down, Player);
        // destroying the bomb , because it exploded
        
        // invoke doesn't work if the gameobject is first destroyed and then it's called, but it works when gameObject is disabled
        gameObject.SetActive(false);
        Destroy(this.gameObject, 1f);
    }
   
    void CreateExplosions(Vector2 direction, GameObject playerGameObject)
    {
        

        ContactFilter2D filter = new ContactFilter2D();
        Vector2 dimensionsOfBox = Vector2.one;
        Vector2 halfDimensions = Vector2.one / 2f;

        Vector2 positionOfBox = (Vector2)roundedPositionOfBomb + (direction * dimensionsOfBox.x);
        
        //player1
        

            for (int i = 1; i <=playerGameObject.GetComponent<BombMaking>().explosionRange; i++)
            {

                Collider2D[] objs = new Collider2D[2];
                bool foundBlockOrWalls = false;
                bool foundWall = false;
                Physics2D.OverlapBox(positionOfBox, halfDimensions, 0f, filter, objs);
                foreach (Collider2D collider in objs)
                {
                    if (collider)
                    {
                        foundBlockOrWalls = collider.gameObject.CompareTag("Walls") || collider.CompareTag("Block");
                        if (foundBlockOrWalls)
                        {
                            if (collider.gameObject.CompareTag("Block"))
                            {
                                Destroy(collider.gameObject, explosionDuration);
                                GameObject explosion = Instantiate(explosionPrefab, positionOfBox, Quaternion.identity) as GameObject;
                                Destroy(explosion, explosionDuration);
                               
                            }
                            else foundWall = true;

                        }
                    }

                }

                if (foundBlockOrWalls) break;
                if (!foundWall)
                {
                    GameObject explosion = Instantiate(explosionPrefab, positionOfBox, Quaternion.identity) as GameObject;
                    Destroy(explosion, explosionDuration);
                }
                positionOfBox += (direction * dimensionsOfBox.x);
            }

        }
}
