using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneManager : MonoBehaviour
{
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
    public void Level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level One", LoadSceneMode.Single);
    }
    public void Level2()
    {

    }
    public void Level3()
    {

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
}
