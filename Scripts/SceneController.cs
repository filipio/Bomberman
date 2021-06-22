using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    IEnumerator LoadWinnerScene()
    {
        yield return new WaitForSeconds(0.5f);
        if(player1 == null && player2 == null)
        {
            int randomInt = Random.Range(0, 2);
            if(randomInt == 1)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
        else if (player1 == null && player2 != null)
        {
            SceneManager.LoadScene(2);
        }
        else if(player1 != null && player2 == null)
        {
            SceneManager.LoadScene(3);
        }
    }


    void Update()
    {
        
        if (player1 == null || player2 == null)
        {
            StartCoroutine(LoadWinnerScene());
        }


    }
}