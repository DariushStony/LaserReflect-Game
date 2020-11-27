using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTest : MonoBehaviour
{
    Vector3 startDragDir;
    Vector3 currentDragDir;
    Quaternion initialRotation;
    float angleFromStart;
    void OnMouseDown()
    {
        startDragDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        initialRotation = transform.rotation;
    }
    void OnMouseDrag()
    {
        currentDragDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //gives you the angle in degrees the mouse has rotated around the object since starting to drag
        angleFromStart = Vector3.Angle(startDragDir, currentDragDir);
        transform.rotation = initialRotation;
        transform.Rotate(0.0f, angleFromStart, 0.0f);
    }

}
