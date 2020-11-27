using UnityEngine;
using UnityEngine.UI;

//This is for Levels
//All of Levels
public class Levels_Sound_Volume_Controller : MonoBehaviour
{
    //First of all we must Get ThemeMusic GameObject and SFX_Sound Effect
    public GameObject ThemeMusic;
    public GameObject SFX_Sound_Effect;

    //Get Sound Volume Slider
    public Slider soundVolume_Silder;

    //Private AudioSource
    //Gonna Get AudioSource Component from ThemeMusic and SFX_Sound_Effect
    private AudioSource ThemeMusic_AS;
    private AudioSource SFX_Sound_Effect_AS;

    //Pause Page and Setting Page 
    public GameObject SettingPage;
    public GameObject PausePage;


    // Start is called before the first frame update
    void Start()
    {
        //Get Sound Sound_Volume from
        soundVolume_Silder.value = Static_Variables.sound_Volume;

        //First Get Audio Sources
        ThemeMusic_AS = ThemeMusic.GetComponent<AudioSource>();
        SFX_Sound_Effect_AS = SFX_Sound_Effect.GetComponent<AudioSource>();

        //Then Feed AudioSources
        ThemeMusic_AS.volume = soundVolume_Silder.value;
        SFX_Sound_Effect_AS.volume = soundVolume_Silder.value;
    }

    // Update is called once per frame
    void Update()
    {
        //Do it Every Time it Changed
        ThemeMusic_AS.volume = soundVolume_Silder.value;
        SFX_Sound_Effect_AS.volume = soundVolume_Silder.value;
    }

    public void BackToPausePage_Button()
    {
        SettingPage.SetActive(false);
        //PausePage.SetActive(true);

        SaveAndLoad.Save_Sound(soundVolume_Silder);
    }

}
