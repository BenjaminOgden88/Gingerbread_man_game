using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Help for this script can be found at 
//https://www.codinblack.com/how-to-make-the-camera-follow-an-object-in-unity3d/

public class CameraScript : MonoBehaviour
{
    public float smoothness;
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    public void Start()
    {
        initalOffset = transform.position - targetObject.position;
    }

    public void FixedUpdate()
    {
        Vector3 playersPositon = new Vector3(0, targetObject.position.y, targetObject.position.z);


        cameraPosition = playersPositon + initalOffset;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);


        /* cameraPosition = targetObject.position + initalOffset;
         transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);*/
    }
}
