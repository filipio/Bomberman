using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public Animator animator;

    [SerializeField] private float speedOfPlayer = 3f;
    [SerializeField] private float speedUpgrade = 1.5f;
    [SerializeField] private bool isPlayerOne = false;
    private float moveHorizontal;
    private float moveVertical;
    bool facingRight = true;

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;       
        transform.localScale = theScale;

    }

    public void MovementUpgrade()
    {
        this.speedOfPlayer += speedUpgrade;

    }

    void Move()
    {
            if (moveHorizontal > 0.5f || moveHorizontal < -0.5f)
            {

                transform.Translate(moveHorizontal * this.speedOfPlayer * Time.deltaTime, 0, 0);
                if (moveHorizontal > 0.5f && !facingRight)
                {
                    Flip();

                }
                else if (moveHorizontal < 0.5f && facingRight)
                {
                    Flip();

                }
            }

            else if (moveVertical > 0.5f || moveVertical < -0.5f)
            {
                animator.SetBool("IsMovingY", true);
                transform.Translate(0, moveVertical * this.speedOfPlayer * Time.deltaTime, 0);

            }
            if (moveVertical == 0f) animator.SetBool("IsMovingY", false);

    }
    void FixedUpdate()
    {
        if(isPlayerOne)
        {
            moveHorizontal = Input.GetAxisRaw("HorizontalPlayerOne");
            moveVertical = Input.GetAxisRaw("VerticalPlayerOne");
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("HorizontalPlayerTwo");
            moveVertical = Input.GetAxisRaw("VerticalPlayerTwo");
        }
        Move();
        animator.SetFloat("MovementX", Mathf.Abs(moveHorizontal));
        animator.SetFloat("MovementY", moveVertical);

    }

}
