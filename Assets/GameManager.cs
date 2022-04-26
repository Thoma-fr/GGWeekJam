using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPaused;
    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0;
            isPaused = !isPaused;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Time.timeScale = 1;
            isPaused = !isPaused;
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
