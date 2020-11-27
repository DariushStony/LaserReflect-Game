//using UnityEngine;

//public class test : MonoBehaviour
//{
//    private Vector3 v3 = new Vector3(0, 0, 0);
//    private Vector3 u = new Vector3(0, 1, 0);
//    private float anlge;

//    private Transform g;
//    private bool IS = false;

//    // Start is called before the first frame update
//    void Start()
//    {
//        u = new Vector3(0, transform.localPosition.y, 0);
//    }


//    void Update()
//    {
//        if (true)
//        {
//            if (true)
//            {
//                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//                RaycastHit hit;


//                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
//                {

//                    if (hit.collider.tag == "ref")
//                    {
//                        if (!IS)
//                        {
//                            IS = true;
//                        }

//                        else
//                        {
//                            g.GetComponent<Animator>().SetBool("IsTouch", false);
//                        }

//                        g = hit.transform;
//                        GameObject s = hit.transform.gameObject;
//                        g.GetComponent<Animator>().SetBool("IsTouch", true);
//                        //u = new Vector3(0, s.transform.localPosition.y, 0);
//                    }
//                }

//                if (true)
//                {

//                    {

//                        v3 = Input.mousePosition;
//                        v3.z = g.transform.position.z;
//                        v3 = Camera.main.ScreenToWorldPoint(v3);
//                        v3 = v3 - new Vector3(g.transform.position.x, 0);
//                        v3.z = 0;

//                        int sign = Vector3.Cross(u, v3).z < 0 ? -1 : 1;

//                        anlge = sign * Vector3.Angle(u, v3);

//                        u = v3;

//                        g.transform.Rotate(Vector3.forward, anlge);

//                    }
//                }

//            }
//        }
//    }

//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Vector3 v3 = new Vector3(0, 0, 0);
    public Vector3 u = new Vector3(0, 1, 0);
    public float anlge;

    // Start is called before the first frame update
    void Start()
    {
        //u = new Vector3(0, transform.localPosition.y, 0);
        u = Quaternion.Euler(0,0, transform.rotation.eulerAngles.z ) * u;
        
        Debug.Log("World:" + transform.position.y);
        Debug.Log("Local:" + transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        {

            v3 = Input.mousePosition;
            v3.z = transform.position.z;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3 = v3 - new Vector3(transform.position.x, 0);
            v3.z = 0;

            int sign = Vector3.Cross(u, v3).z < 0 ? -1 : 1;

            anlge = sign * Vector3.Angle(u, v3);

            u = v3;

            transform.Rotate(Vector3.forward, anlge);

        }
    }
}


