using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;

public class SceneManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject SettingsObject;

    public Slider VolumeSlider;
    public static float Volume;
    void Start()
    {
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
        SettingsObject.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsObject.SetActive(false);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title Screen", LoadSceneMode.Single);
    }

    void Update()
    {
        
    }
}
