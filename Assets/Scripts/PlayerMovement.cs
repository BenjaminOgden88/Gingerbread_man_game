using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

/*this is the player controller. Also contains scripts
 * for triggering animations based on movement type
 * 
 * */
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    //private SettingsScript settingScript;



    public Vector3 jump;
    public float jumpForce;

    public bool isGrounded;
    public Rigidbody rb;

    public Collider collider;

    public GameObject jumpCollider;

    public Transform feetPosition;

    private Animator anim;

    public GameObject bodyPlayerToRotate;


    [SerializeField]

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }



    /*private void OnCollisionStay()
    {

        Debug.Log("YEAAHHHHH");
        isGrounded = true;
    }*/

    public void OnTriggeEnter(Collider collision)
    {

    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    private bool a = false;

    private bool alreadyRotated = false;
    private bool wentLeft = false;
    private bool wentRight = false;

    public Text timerText;
    public Text distanceText;

    public float distancePlayerTraveledInRun = 0;
    public int timeSurvived;


    public GameObject initialGroundPosition;
    public GameObject PlayersFootPosition;







    private Vector3 inputVector;
    private void Update()
    {

        /// Update timer for players survivale time here 
        timerText.text = "Time Survived: " + (int)Time.time;
        timeSurvived = (int)Time.time;


        Vector3 groundAccountOnlyHorizontal = new Vector3(PlayersFootPosition.transform.position.x, initialGroundPosition.transform.position.y, PlayersFootPosition.transform.position.z);

        initialGroundPosition.transform.position = groundAccountOnlyHorizontal;

        //update distacne traveled in game scene text
        float dist = Vector3.Distance(PlayersFootPosition.transform.position, groundAccountOnlyHorizontal);
        distanceText.text = "Distance Traveled: " + dist;

        distancePlayerTraveledInRun = dist;


        //transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0);

        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        rb.AddForce(inputVector * speed,ForceMode.VelocityChange);
        



        if (Input.GetKeyDown("d") || Input.GetKeyDown("a") && isGrounded == true && alreadyRotated == false)
        {
            if (Input.GetKeyDown("d"))
            {
                bodyPlayerToRotate.transform.Rotate(0.0f, -90.0f, 0.0f);
                wentRight = true;
                wentLeft = false;
                alreadyRotated = true;
            }
            else
            {
                bodyPlayerToRotate.transform.Rotate(0.0f, 90.0f, 0.0f);
                wentRight = false;
                wentLeft = true;
                alreadyRotated = true;
            }

            anim.CrossFade("RunLoop", 0.1f);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", false);
        }

        //ready player to possibly rotate a new direction
        /*if(Input.GetKeyUp("d") || Input.GetKeyUp("a") && isGrounded)
        {
            if(wentLeft == true)
            {
                bodyPlayerToRotate.transform.Rotate(0.0f, 90.0f, 0.0f);
            }
            else
            {
                bodyPlayerToRotate.transform.Rotate(0.0f, -90.0f, 0.0f);
            }
            wentRight = false;
            wentLeft = false;
            alreadyRotated = false;
        }*/

        //isGrounded = Physics.Raycast(transform.position, Vector3.down, 4f , 1 << LayerMask.NameToLayer("Volcano"));
        //Debug.DrawRay(transform.position, Vector3.down * 4f, Color.green, 5f);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.CrossFade("Jump", 0.1f);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            //rb.AddForce(jump * jumpForce);
            isGrounded = false;
            anim.SetBool("isJumping", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);

            resetRotationPlayer();

        }

        //idle
        if (Input.GetAxisRaw("Horizontal") == 0 && isGrounded == true /*&& a == false*/)
        {

            anim.CrossFade("Idle", 0.1f);
            anim.SetBool("isIdle", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", false);
            resetRotationPlayer();
            //a = true;
        }

        //when mid jump
        if (Input.GetAxisRaw("Horizontal") == 0 && isGrounded == false /*&& a == false*/)
        {
            anim.CrossFade("Jump", 0.1f);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            resetRotationPlayer();
            //a = true;
        }




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - VarsFromMenu.levelCurrentlyIn);
            //settingScript.totalLevelsBeaten++;
            //Debug.Log(settingScript.totalLevelsBeaten);

        }


    }

    private void resetRotationPlayer()
    {
        if (wentLeft == true && alreadyRotated == true)
        {
            bodyPlayerToRotate.transform.Rotate(0.0f, -90.0f, 0.0f);
        }
        else if (wentRight == true && alreadyRotated == true)
        {
            bodyPlayerToRotate.transform.Rotate(0.0f, 90.0f, 0.0f);
        }


        wentRight = false;
        wentLeft = false;
        alreadyRotated = false;
    }


    //USE THIS TO FIX PPLAYEQR MOVMENT TO USE PHYSICS FOR JUMPING AND MVOEMNT
    private void FixedUpdate()
    {
        Vector3 moveMentChange = new Vector3(inputVector.x,rb.velocity.y,rb.velocity.z);
        rb.velocity = moveMentChange;
        //rb.velocity = rb.velocity + inputVector;

    }

}