using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{private bool objectIsRed = false;
    private bool objectIsWhite = false;
    
    [SerializeField] private float timer = 0.1f;
    private float timerColorChanger = 0.15f;
    private Renderer playerRenderer;

    IEnumerator ChangeColor( Color color)
    {
       // Debug.Log("changing the colors...");
       yield return new WaitForSeconds(timer);
        playerRenderer.material.color = Color.Lerp(playerRenderer.material.color, color, timerColorChanger);
        if (playerRenderer.material.color == Color.red) objectIsRed = true;       
        if (playerRenderer.material.color == Color.white) objectIsWhite = true;
      
    }

    private void OnEnable()
    {
        objectIsRed = false;
        objectIsWhite = false;
        playerRenderer = GetComponent<Renderer>();

    }

 

    void Update()
    {
        
        if (!objectIsRed && !objectIsWhite)
        {
            StartCoroutine(ChangeColor(Color.red));
        }

        else if(objectIsRed && !objectIsWhite)
        {
            StartCoroutine(ChangeColor(Color.white));
        }
        else
        {
         
            GetComponent<ChangePlayerColor>().enabled = false;
        }
        
    }
}
