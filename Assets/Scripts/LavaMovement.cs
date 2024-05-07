using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LavaMovement : MonoBehaviour
{
    public Vector3 velocity = Vector3.up;
    private float minDistance = 25f;

    public GameObject surfaceOfLava;
    public GameObject PlayersFootPosition;


    public float timeToWaitBeforeAddingSpeedToLava = 10.0f;
    private float nextTimeAdditionToIncreaseLavaSpeed;
    public float speedIncrease;

   // public GameObject txt;
    public Text txt;

    public PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;


        GameObject player = GameObject.FindWithTag("Player");
        Vector3 playerPosition = PlayersFootPosition.transform.position;

    

        //NOTE: Ben added distance form player to lava here for visual
        //surfaceLavaVector tracks plaerys feet in x and z axis, NOT Y, Y axis is for surface of lava
        Vector3 surfaceLavaVector = new Vector3(PlayersFootPosition.transform.position.x,surfaceOfLava.transform.position.y , PlayersFootPosition.transform.position.z);
        surfaceOfLava.transform.position = surfaceLavaVector;


        //use players horizontal and match surfaceOfLava with it, so distance is only in vertical direction

        float dist = Vector3.Distance(playerPosition, surfaceOfLava.transform.position);


        //rubber banding for the lava so the player can't get too far away from it
        //first sets an offset of 3 units then gets the players y position 
        //then sets the surfacelava y position to where the player is minus the offset
        if (dist > minDistance)
        {

            surfaceLavaVector = transform.position;
            Vector3 offset = new Vector3(0, 5, 0);
            float playerY = playerPosition.y;
            float offsetNum = offset.y;
            surfaceLavaVector.y = playerY - offsetNum;
            transform.position = surfaceLavaVector;
            
        }

        //NOTE: Ben is adding a timer to deal with increasing speed of lava every given timeToWaitBeforeAddingSpeedToLava form of time
        if (Time.time > nextTimeAdditionToIncreaseLavaSpeed)
        {
            Vector3 addtoSpeedVector = new Vector3(0, speedIncrease, 0);
            velocity = velocity + addtoSpeedVector;
        }
        else
        {
            nextTimeAdditionToIncreaseLavaSpeed = Time.time + timeToWaitBeforeAddingSpeedToLava;
           
        }
        txt.text = "Distance From Player: " + dist;
    }

    private void OnTriggerEnter(Collider col)
    {
        Camera.main.transform.parent = null;
        if (col.tag == "Player")
        {
            VarsFromMenu.timeSurvived = playerMovement.timeSurvived;
            VarsFromMenu.distaceTraveled = playerMovement.distancePlayerTraveledInRun;
            Debug.Log("Survive = " + VarsFromMenu.timeSurvived);
            Debug.Log("Distance Traveled " + VarsFromMenu.distaceTraveled);
            Destroy(col.gameObject);
            /*Note from Ben: When player is hit by lava we load back to the 
             main menu. For later version we might change this so that a simple shows on screen
            showing how player did, their score and such*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
