using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LaserCreater : MonoBehaviour
{
    private int counter = 1;

    //public Laser Details
    public LineRenderer lr;
    public GameObject Explosion;
    //Number of Boxes
    public int Boxes;
    public int dist;
    public string reftag;
    public int limit = 100;
    public string wintag;

    //Private Laser Elements
    private int verti = 1;
    private bool iactive = true;
    private Vector2 currot;
    private Vector2 curpos;


    // Use this for initialization
    void Start()
    {
        Boxes = GameObject.FindGameObjectsWithTag("Box").Length;
        lr.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Boxes = GameObject.FindGameObjectsWithTag("Box").Length;
        DrawLaser();
        CheckBoxes();
    }


    void CheckBoxes()
    {
        if (Boxes == 0)
        {
            if (counter == 1)
            {
                counter++;

                iactive = false;

                Timer.CheckIsLevelFinished();

                ThemeMusic._AudioSource_Music.Stop();

                Sound_SFX.SFX_AudioSource.Play();

                LevelUIController.RunEvent();
            }
        }
    }

    void DrawLaser()
    {
        verti = 1;
        iactive = true;
        currot = transform.right;
        curpos = transform.position;
        lr.SetVertexCount(1);
        lr.SetPosition(0, transform.position);

        while (iactive)
        {
            verti++;
            RaycastHit2D hit = Physics2D.Raycast(curpos, currot, dist);
            hit.point = hit.point - (currot / 10000);
            lr.SetVertexCount(verti);

            if (Physics2D.Raycast(curpos, currot, dist))
            {
                curpos = hit.point;
                currot = Vector2.Reflect(currot, hit.normal);
                lr.SetPosition(verti - 1, hit.point);

                if (hit.transform.gameObject.tag != reftag)
                {
                    //Debug.Log(System.Environment.StackTrace);
                    iactive = false;

                    if (hit.transform.gameObject.tag == wintag)
                    {
                        Destroy(hit.transform.gameObject);
                        Instantiate(Explosion, hit.transform.position,hit.transform.rotation);
                        //Instantiate(Explosion);
                        //Explosion.transform.position = hit.transform.position;
                        //Destroy(Explosion, 1.0f);

                        Boxes--;
                        //if (Boxes == 0)
                        //{
                        //    iactive = false;

                        //    Timer.CheckIsLevelFinished();

                        //    ThemeMusic._AudioSource_Music.Stop();

                        //    Sound_SFX.SFX_AudioSource.Play();

                        //    LevelUIController.RunEvent();
                        //}
                    }

                    if (hit.transform.gameObject.tag == "ScalableObstacle")
                    {
                        if (hit.transform.childCount > 0)
                        {
                            Transform[] children = new Transform[hit.transform.childCount];

                            int i = 0;
                            foreach (Transform T in hit.transform)
                            {
                                children[i++] = T;
                            }

                            hit.transform.DetachChildren();
                            //Hard Code
                            hit.transform.localScale += new Vector3(0.003f, 0, 0);

                            foreach (Transform T in children)
                            {
                                T.transform.localPosition += new Vector3(0.015f, 0, 0);
                            }

                            foreach (Transform T in children)
                            {
                                T.parent = hit.transform;
                            }
                        }

                        else
                        {
                            hit.transform.localScale += new Vector3(0.003f, 0, 0);
                        }

                    }


                    if (hit.transform.gameObject.tag == "RedButton")
                    {
                        //-----------------------------Hard Code-------------------------------------
                        //if (SceneManager.GetActiveScene().buildIndex == 19)
                        //{
                        GameObject[] objects = GameObject.FindGameObjectsWithTag("AnimatedObstacle");
                        GameObject glass = GameObject.FindGameObjectWithTag("Glass");
                        glass.GetComponent<EdgeCollider2D>().enabled = false;

                        GameObject[] animObstacles = new GameObject[objects.Length + 1];
                        for (int i = 0; i < objects.Length; i++)
                        {
                            animObstacles[i] = objects[i];
                        }

                        animObstacles[objects.Length] = hit.transform.gameObject;

                        foreach (GameObject g in animObstacles)
                        {
                            g.GetComponent<Animator>().SetBool("isHit", true);
                        }
                        //}
                    }


                    if (Boxes == 0)
                    {
                        if (counter == 1)
                        {
                            counter++;

                            iactive = false;

                            Timer.CheckIsLevelFinished();

                            ThemeMusic._AudioSource_Music.Stop();

                            Sound_SFX.SFX_AudioSource.Play();

                            LevelUIController.RunEvent();
                        }
                    }

                }
            }

            else
            {
                iactive = false;
                lr.SetPosition(verti - 1, curpos + 100 * currot);
            }

            if (verti > limit)
            {
                iactive = false;
            }
        }
    }

}

