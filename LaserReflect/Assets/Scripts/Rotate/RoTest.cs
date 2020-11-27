using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoTest : MonoBehaviour
{
    float rotationSpeed = 10.0f;
    float lerpSpeed = 1.0f;

    public Vector3 speed = new Vector3();
    private Vector3 avgSpeed = new Vector3();
    private bool dragging = false;
    private Vector3 targetSpeedX = new Vector3();

    void OnMouseDown()
    {
        dragging = true;
    }

    void Update()
    {

        if (Input.GetMouseButton(0) && dragging)
        {
            speed = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            //avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 5);
        }
        else
        {
            if (dragging)
            {
                speed = avgSpeed;
                dragging = false;
            }
            //var i = Time.deltaTime * lerpSpeed;
            //speed = Vector3.Lerp(speed, Vector3.zero, i);
        }

        //transform.Rotate(Camera.main.transform.forward * (-speed.x + speed.y) * rotationSpeed, Space.World);


        //if (transform.rotation.z >= 0)
        // {
        //transform.Rotate(Camera.main.transform.forward * (-speed.x + speed.y) * rotationSpeed, Space.World);
        transform.Rotate(transform.forward,1f);

        //}

        //if (transform.rotation.z >= -0.1f)
        //{
        //    transform.Rotate(Camera.main.transform.forward * (speed.x + speed.y) * rotationSpeed, Space.World);
        //}

        //else
        //{
        //    transform.Rotate(Camera.main.transform.forward * (-speed.x + speed.y) * rotationSpeed, Space.World);
        //}


    }


}
