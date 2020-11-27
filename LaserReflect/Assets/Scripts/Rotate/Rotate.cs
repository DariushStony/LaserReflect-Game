using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Vector3 v3 = new Vector3(0, 0, 0);
    private Vector3 u = new Vector3(0, 1, 0);
    private float anlge;

    private Transform g;
    private bool IS = false;

    // Start is called before the first frame update
    void Start()
    {
        //u = new Vector3(0, transform.localPosition.y, 0);
    }


    void Update()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            if (Input.touchCount == 1)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                Touch touchZero = Input.GetTouch(0);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {

                    if (hit.collider.tag == "ref" && touchZero.phase == TouchPhase.Began)
                    {
                        if (!IS)
                        {
                            IS = true;
                        }

                        else
                        {
                            g.GetComponent<Animator>().SetBool("IsTouch", false);
                        }

                        u = new Vector3(0, 1, 0);
                        g = hit.transform;
                        g.GetComponent<Animator>().SetBool("IsTouch", true);
                        u = Quaternion.Euler(0, 0, g.transform.rotation.eulerAngles.z) * u;
                    }
                }

                if (touchZero.phase != TouchPhase.Ended)
                {

                    {
                        u = new Vector3(0, 1, 0);
                        u = Quaternion.Euler(0, 0, g.transform.rotation.eulerAngles.z) * u;

                        //Debug.DrawLine(new Vector3(0, 0, 0), u, Color.blue);

                        v3 = touchZero.position;
                        v3.z = g.transform.position.z;
                        v3 = Camera.main.ScreenToWorldPoint(v3);
                        v3 = v3 - new Vector3(g.transform.position.x, g.transform.position.y);
                        v3.z = 0;

                        //Debug.DrawLine(new Vector3(0, 0, 0), v3, Color.red);

                        int sign = Vector3.Cross(u, v3).z < 0 ? -1 : 1;

                        anlge = sign * Vector3.Angle(u, v3);

                        u = v3;

                        g.transform.Rotate(Vector3.forward, anlge);

                    }
                }

            }
        }
    }

}

