using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Code was made by The youtube channel Press Start.
 * https://www.youtube.com/watch?v=7-8nE9_FwWs
 * 
 * also uses a mix of original code from tutorial "How to make grappling Gun In
 * unity
 * https://www.youtube.com/watch?v=Xgh4v1w5DxU&t=423s
 * I edited to grapple from pov to 2.5D
 */
public class PointShootTutorial : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;

    /*public GameObject bulletPrefab;
    public GameObject bulletStart;*/
    public Camera camera;
    public int offset;
    public GameObject gunTip;
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    /*public Transform gunTip;*/ /*camera;*/
    public float maxDistance = 100f;
    private SpringJoint joint;

    public float bulletSpeed = 60.0f;

    private Vector3 target;


    public MoveCursor moveCursor;

    public GameObject grappleUI;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        //Cursor.visible = false;
    }

    // Update is called once per frame


    [SerializeField] private Camera mainCamera;

    public float fireRateTimer = 1.0f;
    private float nextFire;

    private bool currentlyGrappling = false;

    void Update()
    {




        bool foundSpotToGrapple = false;
        Vector3 mousePos = new Vector3(0, 0, 0);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mousePos /*=  transform.position*/ = raycastHit.point;
            foundSpotToGrapple = true;
        }

        Vector3 posMouse = new Vector3(mousePos.x, mousePos.y, mousePos.z);
        Vector3 difference = posMouse - player.transform.position;





        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(Time.time > nextFire)
        {
            grappleUI.active = true;
        }
        else if (Time.time > nextFire)
        {
            grappleUI.active = false;
        }


        if (Input.GetMouseButtonDown(0) && foundSpotToGrapple == true && Time.time > nextFire)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();


         


            
            currentlyGrappling = true;
           

            StartGrapple(direction, rotationZ);


            //fireBullet(direction, rotationZ);
        }
        else if(Input.GetMouseButtonUp(0) && currentlyGrappling == true)
        {
            //restart timer and stop grapple
            nextFire = Time.time + fireRateTimer;
            currentlyGrappling = false;
            grappleUI.active = false;
            StopGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            
            StopGrapple();
        }
        //TODO NEED SOME SORT OF IF TIMER IS OVER, THEN SHOW THE UI ELEMENT TO USE GRAPPLE HOOK

    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }


    public float springAmt;
    public float damperAmt;
    public float massScaleAmt;
    void StartGrapple(Vector2 directionToGrapple, float rotationZ)
    {

        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, directionToGrapple, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;


            float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);


            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;




            //Adjust these values to fit your game.
            /*joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;*/

            joint.spring = springAmt;
            joint.damper = damperAmt;
            joint.massScale = massScaleAmt;


            lr.positionCount = 2;

            currentGrapplePosition = gunTip.transform.position;


        }

    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.transform.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }

    /*void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }*/
}