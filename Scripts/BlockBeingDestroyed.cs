using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBeingDestroyed : MonoBehaviour
{
    private Renderer blockRenderer;
    
    [SerializeField] private float timer = 0.05f;
    [SerializeField] private float changingColorTime = 0.15f;
    IEnumerator ChangeColorRed ()
    {
        yield return new WaitForSeconds(timer);
        blockRenderer.material.color = Color.Lerp(blockRenderer.material.color, Color.red, changingColorTime);

    }

    private void OnEnable()
    {
        blockRenderer = GetComponent<Renderer>();
    }


    void Update()
    {
        StartCoroutine(ChangeColorRed());
    }
}
