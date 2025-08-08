using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Canvas canvas;
    public Canvas SettingsScreen;
    

    public Slider VolumeSlider;
    public static float Volume;
    void Start()
    {
        SettingsScreen.enabled = false;
        SetVolume(Volume);
    }
    public void SetVolume(float value)
    {
        float newVolume = AudioListener.volume;
        newVolume = value;
        AudioListener.volume = newVolume;
        Volume = newVolume;
    }
    public void OpenSettings()
    {
        SettingsScreen.enabled = true;
    }
    public void CloseSettings()
    {
        SettingsScreen.enabled = false;
    }

    void Update()
    {
        
    }
}
