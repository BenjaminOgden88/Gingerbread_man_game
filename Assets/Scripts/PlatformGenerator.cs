using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public float prevPlatformTop; // prev 5.3
    public float platformHeight; 
    public float PlatformX; 
    public float PlatformZ;
    public GameObject level1; 
    public GameObject level2; 
    public GameObject level3; 
    public GameObject level4; 
    public GameObject level5; 
    private int numLevels = 5;
    private GameObject[] levels; 
    public Transform player; 
    
    // Start is called before the first frame update
    void Start()
    {
        levels = new GameObject[numLevels]; 
        levels[0] = level1; 
        levels[1] = level2;
        levels[2] = level3;
        levels[3] = level4;
        levels[4] = level5; 
    }

    void Update()
    {
        // Call when player.Y is large enough that player will see above the current scene 
        if(player.position.y > prevPlatformTop - platformHeight*1.5) {
            int r = Random.Range(0,numLevels); // generate a random int between 0 and numLevels
            // Debug.Log("Generating level " + r);
            Instantiate(levels[r], new Vector3(PlatformX, prevPlatformTop, PlatformZ), gameObject.transform.rotation * Quaternion.Euler (0f, 180f, 0f));
            prevPlatformTop += platformHeight; 
        }
    }
}
