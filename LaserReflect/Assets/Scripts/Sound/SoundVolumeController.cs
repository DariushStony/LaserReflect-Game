using UnityEngine;
using UnityEngine.UI;

//This Code Is for Scene with Index 0 that means MainMenu
//MainMenu
public class SoundVolumeController : MonoBehaviour
{
    //First of All Get Audio Source Component
    private AudioSource audioSource;

    //Sound Volume Silder
    public Slider volumeSlider;

    //Pages
    public GameObject SettingPage;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        SoundData SD = SaveAndLoad.Load_Sound();
        if (SD != null)
        {
            volumeSlider.value = SD.SoundVolume;
        }

        audioSource.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void BackToStartPage_Button()
    {
        SettingPage.SetActive(false);

        SaveAndLoad.Save_Sound(volumeSlider);
    }

}
