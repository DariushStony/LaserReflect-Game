using UnityEngine.UI;

[System.Serializable]

public class SoundData
{
    public float SoundVolume = 0.0f;

    public SoundData(Slider slider)
    {
        SoundVolume = slider.value;
        Static_Variables.sound_Volume = slider.value;
    }
}
