using UnityEngine;

public class Sound_SFX : MonoBehaviour
{
    public AudioClip SFX_Clip;
    public static AudioSource SFX_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        SFX_AudioSource = GetComponent<AudioSource>();
        SFX_AudioSource.clip = SFX_Clip;
    }
}
