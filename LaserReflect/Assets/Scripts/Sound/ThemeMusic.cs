
using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    //This is for Level Main Music 
    public AudioClip[] AudioClips_ThemeMusic;
    public static AudioSource _AudioSource_Music;

    // Start is called before the first frame update
    void Start()
    {
        _AudioSource_Music = GetComponent<AudioSource>();

        _AudioSource_Music.clip = AudioClips_ThemeMusic[Random.Range(0, AudioClips_ThemeMusic.Length)];

        _AudioSource_Music.Play();

    }
}
