using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMaking : MonoBehaviour
{
    public GameObject bomb;

    private int bombAmount = 1;
    public int explosionRange = 1;
    public void AddABomb()
    {
        this.bombAmount += 1;
    }
    public void SubstractABomb()
    {
        this.bombAmount -= 1;
    }

    public void BiggerExplosion()
    {
        this.explosionRange += 1;
    }

    void MakeABomb()
    {
        Instantiate(bomb, Vector3Int.RoundToInt(this.gameObject.transform.position), Quaternion.identity);
    }
    void Update()
    {     
        if(Input.GetKeyDown(KeyCode.LeftShift) && this.bombAmount > 0 && gameObject.name == "Player1" )
        {
        
            SubstractABomb();
            MakeABomb();
            Invoke("AddABomb", 2f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && this.bombAmount > 0 && gameObject.name == "Player2")
        {

            SubstractABomb();
            MakeABomb();
            Invoke("AddABomb", 2f);
        }
    }
}
