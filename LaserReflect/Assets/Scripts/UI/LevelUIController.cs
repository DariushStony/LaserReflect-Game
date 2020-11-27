using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelUIController : MonoBehaviour
{

    //public static float[] Level_Time = new float[6];

    //public delegate void laserFinishedLevel();
    //public static event laserFinishedLevel justHitted;
    public static event Action justHitted;

    //UI Pages and UI Elements
    public GameObject levelFinishedPage;
    public GameObject PausePage;
    public GameObject LoadingPage;
    public GameObject SettingPage;
    public Slider LoadingSlider;
    public Text LoadingText;
    public Slider musicVolume;

    //Level Animation clip and Animation Component
    public AnimationClip levelFinishedPage_AnimationClip;
    private Animation levelFinishedPage_Animation;

    //This fuction add Finished Level to justHitted Event and after finishing level remove form it
    private void OnEnable()
    {
        justHitted += FinishLevel_Anim;
    }

    private void OnDisable()
    {
        justHitted -= FinishLevel_Anim;
    }

    // Start is called before the first frame update
    void Start()
    {
        PausePage.SetActive(false);
        LoadingPage.SetActive(false);

        SoundData soundData = SaveAndLoad.Load_Sound();
        musicVolume.value = soundData.SoundVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Level UI Functions
    public void NextLevel_Button(int SceneIndex)
    {
        SceneIndex = (SceneManager.GetActiveScene().buildIndex + 1);

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }

        StartCoroutine(LoadAsynchronously(SceneIndex));
    }

    public void RePlayLevel_Button()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(LoadAsynchronously(SceneIndex));
    }

    public void GoToMainMenu_Button()
    {
        SceneManager.LoadScene(0);
        StartCoroutine(LoadAsynchronously(0));
    }

    public void Pause_Button()
    {
        PausePage.SetActive(true);
        Timer.HelpChecker = true;
    }

    public void Setting_Button()
    {
        SettingPage.SetActive(true);
        PausePage.SetActive(false);
        SoundData soundData = SaveAndLoad.Load_Sound();
        musicVolume.value = soundData.SoundVolume;
    }

    public void Continue_Button()
    {
        PausePage.SetActive(false);
        Timer.HelpChecker = false;
    }

    public void BackTo_Pause_Page()
    {
        SettingPage.SetActive(false);
        PausePage.SetActive(true);
        SaveAndLoad.Save_Sound(musicVolume);
    }

    public void Cross_Button()
    {
        PausePage.SetActive(false);
        SettingPage.SetActive(false);
        Timer.HelpChecker = false;
        SaveAndLoad.Save_Sound(musicVolume);
    }

    //____________________________________________________________________________________


    //This function play finished level animation
    public void FinishLevel_Anim()
    {
        levelFinishedPage.SetActive(true);
        levelFinishedPage_Animation.clip = levelFinishedPage_AnimationClip;
        levelFinishedPage_Animation.Play();
    }

    //This event start when laser hit portal box 
    public static void RunEvent()
    {
        justHitted();
    }


    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingPage.SetActive(true);

        while (!operation.isDone)
        {
            float Progress = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingSlider.value = Progress;
            LoadingText.text = "Loading... " + (Progress * 100f) + "%";

            yield return null;
        }
    }

}
