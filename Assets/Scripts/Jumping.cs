using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public PlayerMovement playerMovement;

    /*private void OnCollisionEnter(collision:Collision)
    {
        if(collision.gameObject.tag == "Volcano")
        {
            isGrounded = true;
        }
        
    }*/


    private void OnCollisionStay()
    {

        playerMovement.isGrounded = true;
    }

    public void Update()
    {
        //Collider jumpCollider = GetComponent<Collider>();


        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.isGrounded)
        {

            playerMovement.rb.AddForce(playerMovement.jump * playerMovement.jumpForce, ForceMode.Impulse);
            playerMovement.isGrounded = false;
        }
    }
}
