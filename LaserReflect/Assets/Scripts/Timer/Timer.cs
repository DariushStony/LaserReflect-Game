using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //this is gonna disable and enable Event System to Preventing Problems in Timer RealTime
    public GameObject eventSystem;

    //This is for Hand Animation in Level One to Train Player
    public GameObject hand_Animation_Page;
    public GameObject Hand;
    private Animator _Animator;

    //This Boolean gonna Help Us to Check for Pausing , Finishing , Time Stoping etc.
    public static bool HelpChecker = true;

    //This int show our Current LevelIndex in Build-Setting
    public int LevelIndex;

    //These are for UI 
    public Text Time_Text;
    public GameObject NewRecord_Text;
    public GameObject GoodJob_Text;

    //These two float for counting Time 
    private float StartTime;
    public float RealTime;

    //This Bool is for Checking that is Level Finished Or Not
    public static bool FinishedLevel = false;

    //We gonna Find MianCamera to Find Rotate Code from it 
    private GameObject MainCamera;

    //bool for Coroutine
    bool Is = false;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem.SetActive(false);

        LevelIndex = SceneManager.GetActiveScene().buildIndex;

        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (LevelIndex == 1)
        {
            MainCamera.GetComponent<Rotate>().enabled = false;
        }

        StartCoroutine(HelpHand());
    }

    // Update is called once per frame
    void Update()
    {
        if (!FinishedLevel && HelpChecker == false)
        {
            MainCamera.GetComponent<Rotate>().enabled = true;

            RealTime = Time.time - StartTime;

            float Minutes = ((int)RealTime / 60);
            float Hours = ((int)Minutes / 60);
            Minutes = Minutes - Hours * 60;
            float Seconds = (RealTime % 60);
            string Sec = Seconds.ToString("f0");

            Time_Text.text = Hours + ":" + Minutes + ":" + Sec;
        }

        else
        {
            if (FinishedLevel == true)
            {
                if (Static_Variables.level_Time[LevelIndex] == 0 && Is)
                {
                    GoToSaving();
                }

                if (RealTime <= Static_Variables.level_Time[LevelIndex] && Is)
                {
                    GoToSaving();
                }
            }

            else
            {
                ResumeTimer(ref StartTime);
            }

        }

    }

    private void ResumeTimer(ref float _startTime)
    {
        float _realTime = RealTime;

        _startTime = Time.time - _realTime;
    }

    public static void CheckIsLevelFinished()
    {
        FinishedLevel = true;
    }

    private void GoToSaving()
    {
        SaveAndLoad.Save(this);
    }


    IEnumerator HelpHand()
    {
        if (LevelIndex == 1)
        {
            _Animator = Hand.GetComponent<Animator>();

            //for (int i = 0; i < 2; i++)
            //{
                yield return new WaitForSeconds(2.45f);

                //if (i == 0)
                //{
                //    _Animator.SetBool("RightToUp", false);
                //}
            //}

            eventSystem.SetActive(true);

            hand_Animation_Page.SetActive(false);

            HelpChecker = false;

            StartTime = Time.time;
            FinishedLevel = false;
            Is = true;
        }
        else
        {
            eventSystem.SetActive(true);
            HelpChecker = false;
            StartTime = Time.time;
            FinishedLevel = false;
            MainCamera.GetComponent<Rotate>().enabled = true;
            Is = true;

            yield return new WaitForSeconds(0);
        }
    }
}
