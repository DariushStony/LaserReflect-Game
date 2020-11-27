using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public Button[] level_Buttons;

    //----------------------------------------- UI Pages ---------------------------------------------
    public GameObject mainPage;
    public GameObject levelsPage;
    public GameObject settingPage;
    //public GameObject championPage;
    //public GameObject playPage;
    public GameObject LoadingPage;
    //public GameObject SeasonPage;
    //public GameObject[] Season1_LevelSheet_Pages;

    //----------------------------------------- UI Elements -------------------------------------------
    public Slider LoadingSlider;
    public Text LoadingText;
    public Text HighScore;
    public Slider musicVolume;
    public Slider sfxVolume;

    //This Text Array must equal with LEVEL_NUMBERS - 1 because LEVEL_NUMBERS is qual with game scene numbers
    //And Level Texts Must eual with Game Levels that start from index 1 in level_Time in Static_Variables Class
    //So Level Texts = LEVEL_NUMBERS-1
    public Text[] Levels = new Text[Static_Variables.LEVEL_NUMBERS - 1];


    //This Image Array Must Show Wich Level Is UnLock and wich one is Not.
    //And This Array must 2 times less than LEVEL_NUMBERS because of Scene Index 0
    //And Because level1 is free to Play
    public GameObject[] levels_Button = new GameObject[Static_Variables.LEVEL_NUMBERS - 2];
    public Sprite baseBlue_Sprite;
    public Sprite topBlue_Sprite;
    public Sprite baseRed_Sprite;
    public Sprite topRed_Sprite;

    //Warning Image And Warning Animation
    public GameObject warningImage;
    public Text warningText;

    //--------------------------------------------------------------------------------------------------

    //Private Variables
    //private readonly Datas data = SaveAndLoad.Load();

    //private bool Is = true;

    // Start is called before the first frame update
    void Start()
    {
        MakeNULL_File();
        Load_Show_GameData();
        Initialize_Static_Variables();
        ShowLevelExpiry();
        Load_Sound_Volume();

        //Deactivate Pages 
        LoadingPage.SetActive(false);
        //SeasonPage.SetActive(false);
        //for (int i = 0; i < Season1_LevelSheet_Pages.Length; i++)
        //    Season1_LevelSheet_Pages[0].SetActive(false);
    }

    void Update()
    {
        //This Function Gonna Listen to level buttons 
        //and when client click on one of them load Related level
        //Levels_Loader();
    }

    void MakeNULL_File()
    {
        Datas data = SaveAndLoad.Load();

        if (data == null)
        {
            //Timer time = new Timer();
            //time.RealTime = 0;

            Timer time = new Timer
            {
                RealTime = 0.0000f
            };

            SaveAndLoad.Save(time);
        }
    }

    void Load_Show_GameData()
    {
        float tmp = 1000000f;
        Datas data = SaveAndLoad.Load();

        //This for gonna show game Level Records 
        for (int i = 1; i < Static_Variables.LEVEL_NUMBERS; i++)
        {
            float RealTime = data._Time[i];
            float Minutes = ((int)RealTime / 60);
            float Seconds = (RealTime % 60);

            if (RealTime == 0)
            {
                Levels[i - 1].text = "None";
            }

            else
            {
                Levels[i - 1].text = "0:" + Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
            }
        }





        //This for game set HighScore of Client to tmp and then show it 
        //and int to check if all the level equal to zero make HighScore equal to zero
        int j = 0;
        for (int i = 1; i < Static_Variables.LEVEL_NUMBERS; i++)
        {
            if (data._Time[i] < tmp && data._Time[i] != 0)
            {
                tmp = data._Time[i];
            }

            else
            {
                j++;
            }
        }

        if (j == (Static_Variables.LEVEL_NUMBERS - 1))
        {
            HighScore.text = "0:0:0";
        }

        else
        {
            float REALTIME = tmp;
            float MINUNTES = ((int)REALTIME / 60);
            float SECONDS = (REALTIME % 60);

            HighScore.text = "0:" + MINUNTES.ToString("f0") + ":" + SECONDS.ToString("f0");
        }
    }

    void Initialize_Static_Variables()
    {
        Datas data = SaveAndLoad.Load();

        SoundData soundData = SaveAndLoad.Load_Sound();


        //This for Gonna Initialize static Variables to work with it in whole game
        for (int i = 0; i < Static_Variables.LEVEL_NUMBERS; i++)
        {
            Static_Variables.level_Time[i] = data._Time[i];
        }

        Static_Variables.currentLevelIndex = data.LevelIndex + 1;

        Static_Variables.sound_Volume = soundData.SoundVolume;
    }

    void ShowLevelExpiry()
    {
        Datas data = SaveAndLoad.Load();

        //The Index Start from 2 because Level One is free to Play ByDefault
        for (int i = 2; i < Static_Variables.LEVEL_NUMBERS; i++)
        {
            if (data._Time[i - 1] == 0)
            {
                //lockUnLock[i - 2].GetComponent<Image>().sprite = LockImage;
                levels_Button[i - 2].GetComponentInChildren<Button>().transition = Selectable.Transition.ColorTint;
                levels_Button[i - 2].GetComponentInChildren<Button>().image.sprite = topRed_Sprite;
                levels_Button[i - 2].GetComponent<Image>().sprite = baseRed_Sprite;
            }

            else
            {
                //lockUnLock[i - 2].GetComponent<Image>().sprite = UnLockImage;
                //levels_Button[i - 2].transform.parent.GetComponentInChildren<Image>().sprite = topBlue_Sprite;
                //test.GetComponent<Image>().sprite = topBlue_Sprite;
                //Sprite s = levels_Button[i - 2].GetComponentInChildren<Image>().sprite;
                levels_Button[i - 2].GetComponentInChildren<Button>().image.sprite = topBlue_Sprite;
                levels_Button[i - 2].GetComponent<Image>().sprite = baseBlue_Sprite;
            }
        }
    }

    void Load_Sound_Volume()
    {
        musicVolume.value = Static_Variables.sound_Volume;

        sfxVolume.value = Static_Variables.sound_Volume;
    }

    bool ReturnPreviousLevel_Time(int index)
    {
        Datas data = SaveAndLoad.Load();

        if (data._Time[index - 1] > 0)
        {
            return true;
        }

        else
        {
            return false;
        }

        //return (data._Time[index - 1] > 0 ? 1 : (data._Time[index - 1] == 0) ? 0 : 0);
    }

    /*public void Levels_Loader()
    {
        for (int i = 0; i < level_Buttons.Length; i++)
        {
            level_Buttons[i].onClick.AddListener(() =>
            {

                LevelSheet_Page.SetActive(false);
                //Application.LoadLevel(2);
                StartCoroutine(LoadAsynchronously(i + 1));

            });
        }
    }*/

    //This Function Active Seasons Page
    public void StartGame_Button()
    {
        //SeasonPage.SetActive(true);
        //StartCoroutine(LoadAsynchronously(1));
        StartCoroutine(LoadAsynchronously(Static_Variables.currentLevelIndex));
    }

    //This Function Active Levels Page
    public void LevelsPage_Button()
    {
        mainPage.SetActive(false);
        levelsPage.SetActive(true);
    }

    public void LevelsLoader_Button(int sceneIndex)
    {
        if (ReturnPreviousLevel_Time(sceneIndex) || sceneIndex == 1)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }

        else
        {
            //Nothing :) :|
            //Something Like Play Sound Effect that Shows you can't play this level
        }
    }

    //This Function is For Seasons Buttons
    //public void Seasons_Buttons(int index)
    //{
    //    switch (index)
    //    {
    //        //Active Season1 Levels
    //        case 0:
    //            Season1_LevelSheet_Pages[0].SetActive(true);
    //            break;
    //        //Active Season2 Levels
    //        case 1:
    //            //Season2_LevelSheet_Pages[0].SetActive(true);
    //            break;
    //        //Active Season3 Levels
    //        case 2:
    //            //Season3_LevelSheet_Pages[0].SetActive(true);
    //            break;
    //    }
    //}

    //public void GameLevels_Loader(int sceneIndex)
    //{
    //    if (sceneIndex == 1)
    //    {
    //        StartCoroutine(LoadAsynchronously(sceneIndex));
    //    }

    //    else
    //    {
    //        if (ReturnPreviousLevel_Time(sceneIndex))
    //        {
    //            //SeasonPage.SetActive(false);
    //            //for (int i = 0; i < Season1_LevelSheet_Pages.Length; i++)
    //            //    Season1_LevelSheet_Pages[0].SetActive(false);

    //            StartCoroutine(LoadAsynchronously(sceneIndex));
    //        }

    //        else
    //        {
    //            StartCoroutine(WarningController(2.30f, sceneIndex));
    //        }
    //    }
    //}

    //public IEnumerator WarningController(float t, int levelIndex)
    //{
    //    warningText.text = "Sorry!You Should Finishe Level" + (levelIndex - 1) + " Before";
    //    warningImage.SetActive(true);
    //    warningImage.GetComponent<Animator>().SetBool("level_Lock", true);

    //    yield return new WaitForSeconds(t);

    //    warningImage.GetComponent<Animator>().SetBool("level_Lock", false);
    //    warningImage.SetActive(false);
    //}

    //This Function Active Next Page And Deactivate Current Page 
    public void NextSheet_Button(int index)
    {
        ////Deactivate Current LevelSheet
        //Season1_LevelSheet_Pages[index].SetActive(false);

        ////Active Next LevelSheet => index + 1
        //Season1_LevelSheet_Pages[index + 1].SetActive(true);

    }

    //This Function Active Previous Page And Deactivate Current Page
    //public void PreviousSheet_Button(int index)
    //{
    //    //Deactivate Current LevelSheet
    //    Season1_LevelSheet_Pages[index].SetActive(false);

    //    //Active Previous LevelSheet => index - 1
    //    Season1_LevelSheet_Pages[index - 1].SetActive(true);
    //}


    public void SettingPage_Button()
    {
        settingPage.SetActive(true);
        mainPage.SetActive(false);
    }

    public void BackToMainPage_Button()
    {
        //SeasonPage.SetActive(false);
        //for (int i = 0; i < Season1_LevelSheet_Pages.Length; i++)
        //    Season1_LevelSheet_Pages[i].SetActive(false);

        settingPage.SetActive(false);
        levelsPage.SetActive(false);
        //championPage.SetActive(false);
        //playPage.SetActive(false);
        mainPage.SetActive(true);

        SaveAndLoad.Save_Sound(musicVolume);

        //StartCoroutine(JustWait(0.25f));
    }

    public void OpenURL(string url)
    {
        Application.OpenURL("https://www.ravistech.ir");
    }

    public void ExitGame_Button()
    {
        //Is = false;
        Application.Quit();
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

