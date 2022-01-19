using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Header("Sliders")]
    public Slider GeneralAudio;
    public Slider SFXAudio;
    public Slider MusicAudio;

    void Awake()
    {
        GeneralAudio.value = PlayerPrefs.GetFloat("GeneralVolume", 1.0f);
        SFXAudio.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        MusicAudio.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
    }

    public void SetGeneralVolume(float volume)
    {
        PlayerPrefs.SetFloat("GeneralVolume", volume);
        audioMixer.SetFloat("General", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
}
