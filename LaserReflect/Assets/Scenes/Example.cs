using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField]
    public string rottag;

    [SerializeField]
    public float RotSpeed;

    Transform t;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            float rotateSpeed = 0.05f;
            Touch touchZero = Input.GetTouch(0);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                if (hit.collider.tag == "ref")
                {
                    t = hit.transform;
                }
            }

            //if (touchZero.position.x < Mathf.Abs(Screen.width) && touchZero.deltaPosition.x < 0)
            //{
            //    Vector3 localAngel = t.localEulerAngles;
            //    localAngel.z += rotateSpeed * Mathf.Abs(touchZero.deltaPosition.x);;
            //    t.localEulerAngles = localAngel;
            //}

            //else
            //{
            //    Vector3 localAngel = t.localEulerAngles;
            //    localAngel.z -= rotateSpeed * Mathf.Abs(touchZero.deltaPosition.x);
            //    t.localEulerAngles = localAngel;
            //}

            //if(touchZero.position.y < Mathf.Abs(Screen.height) && touchZero.deltaPosition.y < 0)
            //{
            //    Vector3 localAngel = t.localEulerAngles;
            //    localAngel.z -= rotateSpeed * Mathf.Abs(touchZero.deltaPosition.y);
            //    t.localEulerAngles = localAngel;
            //}

            //else
            //{
            //    Vector3 localAngel = t.localEulerAngles;
            //    localAngel.z += rotateSpeed * Mathf.Abs(touchZero.deltaPosition.y);
            //    t.localEulerAngles = localAngel;
            //}

            if (touchZero.deltaPosition.x > 0 && touchZero.deltaPosition.y < 0)
            {
                Vector3 localAngel = t.localEulerAngles;
                localAngel.z -= rotateSpeed * Mathf.Abs(touchZero.deltaPosition.x);
                t.localEulerAngles = localAngel;
            }

            if (touchZero.deltaPosition.x < 0 && touchZero.deltaPosition.y < 0)
            {
                Vector3 localAngel = t.localEulerAngles;
                localAngel.z += rotateSpeed * Mathf.Abs(touchZero.deltaPosition.x);
                t.localEulerAngles = localAngel;
            }

            if (touchZero.deltaPosition.x > 0 && touchZero.deltaPosition.y > 0)
            {
                Vector3 localAngel = t.localEulerAngles;
                localAngel.z += rotateSpeed * Mathf.Abs(touchZero.deltaPosition.x);
                t.localEulerAngles = localAngel;
            }

            if (touchZero.deltaPosition.x < 0 && touchZero.deltaPosition.y > 0)
            {
                Vector3 localAngel = t.localEulerAngles;
                localAngel.z -= rotateSpeed * Mathf.Abs(touchZero.deltaPosition.x);
                t.localEulerAngles = localAngel;
            }

        }
    }
}