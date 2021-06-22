using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLife : MonoBehaviour
{

    public int numberOfLives = 2;

    [SerializeField] private float invulnerabilityDuration = 2f;
    [SerializeField] private GameObject playerLifeImage;
    private List<GameObject> lifeImages;
    private bool isInvulnerable = false;
    private AudioSource hurtSound;

    private void Start()
    {
        hurtSound = GetComponent<AudioSource>();
    if (this.gameObject.name == "Player1")
        {
            GameObject playerLivesGrid = GameObject.Find("Player1LivesGrid");
            this.lifeImages = new List<GameObject>();
            for (int lifeIndex = 0; lifeIndex < this.numberOfLives; lifeIndex++)
            {
                GameObject lifeImage = Instantiate(playerLifeImage, playerLivesGrid.transform) as GameObject;
                this.lifeImages.Add(lifeImage);

            }
        }
        else
        {
            GameObject playerLivesGrid = GameObject.Find("Player2LivesGrid");
            this.lifeImages = new List<GameObject>();
            for (int lifeIndex = 0; lifeIndex < this.numberOfLives; lifeIndex++)
            {
                GameObject lifeImage = Instantiate(playerLifeImage, playerLivesGrid.transform) as GameObject;
                this.lifeImages.Add(lifeImage);

            }

        }
    }

    public void LoseLife()
    {
        if (!isInvulnerable)
        {
            GetComponent<ChangePlayerColor>().enabled = true;

                hurtSound.Play();
            
            this.numberOfLives--;
            GameObject lifeImage = this.lifeImages[this.lifeImages.Count - 1];
            Destroy(lifeImage);
            //remove from the list
            this.lifeImages.RemoveAt(this.lifeImages.Count - 1);
            if(numberOfLives == 0)
            {
                
                Destroy(this.gameObject);
                
            }
            this.isInvulnerable = true;
            if (isInvulnerable)
            {
                Invoke("BecomeVulnerable", this.invulnerabilityDuration);

            }
        }

    }

    void BecomeVulnerable() => this.isInvulnerable = false;

    


    
}
