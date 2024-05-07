using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{


    public Text timeSuriviedText;
    public Text distanceTraveledText;

   



    // Start is called before the first frame update
    void Start()
    {
        timeSuriviedText.text = "You Survived: " + VarsFromMenu.timeSurvived + " Seconds";
        distanceTraveledText.text = "You Traveled: " + VarsFromMenu.distaceTraveled + " Meters";
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void goBackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
}
