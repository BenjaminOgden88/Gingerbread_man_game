using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* from brackeys tutorial on "TOP DOWN SHOOTING in Unity"
 * https://www.youtube.com/watch?v=LNLVOjbrQj4&t=105s
 */
public class PointAndShoot : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("x: " + movement.x + ", y:" + movement.y);
        }







    }

    public void FixedUpdate()
    {
        /*Vector3 a = new Vector2(rb.x, rb.y);

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;*/
    }


}
