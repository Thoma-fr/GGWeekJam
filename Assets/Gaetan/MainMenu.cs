using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void StartSceneByIndex(int p_index)
    {
        SceneManager.LoadScene(p_index);
    }

    public void StartSceneByName(string p_name)
    {
        SceneManager.LoadScene(p_name);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
