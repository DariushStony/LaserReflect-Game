using UnityEngine;

public class TestRotate : MonoBehaviour
{
    public float rotateSpeed = 0.05f;
    public Transform OurMirror;
    public Vector2 vec = new Vector2();
    public Sprite d;
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.touchCount == 1)
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //        RaycastHit hit;

    //        Touch touch = Input.GetTouch(0);

    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
    //        {
    //            if (hit.collider.tag == "ref" && touch.phase == TouchPhase.Began)
    //            {
    //                OurMirror = hit.transform;
    //            }
    //        }

    //        if (touch.phase != TouchPhase.Ended)
    //        {
    //            OurMirror.RotateAroundLocal(Vector3.back, touch.deltaPosition.x * rotateSpeed * Mathf.Deg2Rad);
    //        }
    //    }
    //}


    //private void OnMouseDrag()
    //{
    //    float X = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
    //    float Y = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

    //    OurMirror.RotateAround(Vector3.back, Y + X);

    //}


    //float rotationSpeed = 10.0f;
    //float lerpSpeed = 1.0f;

    //private Vector3 speed = new Vector3();
    //private Vector3 avgSpeed = new Vector3();
    //private bool dragging = false;
    //private Vector3 targetSpeedX = new Vector3();

    //void OnMouseDown()
    //{
    //    dragging = true;
    //}

    //void Update()
    //{

    //    if (Input.GetMouseButton(0) && dragging)
    //    {
    //        speed = new Vector3(-Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    //        //avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 5);
    //    }
    //    else
    //    {
    //        if (dragging)
    //        {
    //            speed = avgSpeed;
    //            dragging = false;
    //        }
    //        //var i = Time.deltaTime * lerpSpeed;
    //        //speed = Vector3.Lerp(speed, Vector3.zero, i);
    //    }

    //    //transform.Rotate(Camera.main.transform.up * speed.x * rotationSpeed, Space.World);
    //    transform.Rotate(Camera.main.transform.forward * (speed.x + speed.y) * rotationSpeed, Space.World);

    //}

    //float pointerY;
    //float f_lastX = 0.0f;
    //float f_difX = 0.5f;
    //float f_steps = 0.0f;
    //int i_direction = 1;
    //void Start()
    //{
    //    pointerY = Input.GetAxis("Mouse Y");
    //}
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        f_difX = 0.0f;
    //    }
    //    else if (Input.touchCount > 0)
    //    {
    //        pointerY = Input.touches[0].deltaPosition.y;
    //        f_difX = Mathf.Abs(f_lastX - pointerY);
    //        var touch = Input.GetTouch(0);
    //        if (touch.position.x > Screen.width / 2)
    //        {
    //            // Right
    //            if (f_lastX < Input.GetAxis("Mouse Y"))
    //            {
    //                i_direction = 1;
    //                transform.Rotate(Vector3.forward, f_difX * Time.deltaTime);
    //            }
    //            if (f_lastX > Input.GetAxis("Mouse Y"))
    //            {
    //                i_direction = -1;
    //                transform.Rotate(Vector3.forward, -f_difX * Time.deltaTime);
    //            }
    //        }
    //        else if (touch.position.x < Screen.width / 2)
    //        {
    //            // Left
    //            if (f_lastX < Input.GetAxis("Mouse Y"))
    //            {
    //                i_direction = -1;
    //                transform.Rotate(Vector3.forward, -f_difX * Time.deltaTime);
    //            }
    //            if (f_lastX > Input.GetAxis("Mouse Y"))
    //            {
    //                i_direction = 1;
    //                transform.Rotate(Vector3.forward, f_difX * Time.deltaTime);
    //            }
    //        }
    //        f_lastX = -pointerY;
    //        f_difX = 500f;
    //        Debug.Log(f_difX);
    //    }
    //    else
    //    {
    //        if (f_difX > 0.5f) f_difX -= 1f;
    //        if (f_difX < 0.5f) f_difX += 1f;
    //        transform.Rotate(Vector3.forward, f_difX * i_direction * Time.smoothDeltaTime);
    //    }
    //}


    //private void Update()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
    //    {
    //        OurMirror = hit.transform;
    //        vec = hit.point;



    //    }


    //    OurMirror.LookAt(Input.mousePosition);

    //}



}

