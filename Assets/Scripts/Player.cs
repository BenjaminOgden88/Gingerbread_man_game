using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   /* public int maxHealth;
    public int currentHealth;
    public GameObject DataHolder;
    public bool invincible = false;
    private float Invincible_time = 0;
    public GameObject Shield;

    public HealthBar healthBar;

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Shield = GameObject.FindGameObjectWithTag("Shield");
        DataHolder = GameObject.FindGameObjectWithTag("Data_Holder");
        invincible = false;


        int difficulty = DataHolder.GetComponent<Background_Data>().Difficulty;
        //Add difficulty standard here
        if (difficulty == 1)
        {
            Invincible_time = 3.0f;
        }
        else if (difficulty == 2)
        {
            Invincible_time = 2.0f;
        }
        else if (difficulty == 3)
        {
            Invincible_time = 1.5f;
        }
    }

    public void Update()
    {
        //GameObject.FindGameObjectWithTag("Health").GetComponent<Text>().Text = currentHealth;

        if (invincible)
        {
            Shield.GetComponent<Renderer>().enabled = true;
            StartCoroutine(Shield_active());
        }

        DataHolder.GetComponent<Background_Data>().Player_Health = currentHealth;

        if(currentHealth <= 0)
        {
            DataHolder.GetComponent<Background_Data>().Condition = false;
        }

    }

    IEnumerator Shield_active()
    {
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(Invincible_time);

        Shield.GetComponent<Renderer>().enabled = false;
        invincible = false;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!invincible)
        {
            if (collision.tag == "Enemy")
            {

                Destroy(collision.gameObject);
                TakeDamage(20);
                invincible = true;
            }
        }

        if (!invincible)
        {
            if (collision.tag == "Tank")
            {

                Destroy(collision.gameObject);
                TakeDamage(40);
                invincible = true;
            }
        }

        if (collision.tag == "Powerup")
        {
            Debug.Log(collision.tag);
            Destroy(collision.gameObject);

        }


    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.setHealth(currentHealth);
    }*/
}