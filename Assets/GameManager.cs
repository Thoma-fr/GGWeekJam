using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    private bool isPaused = false;
    private Animator animCurtains;

    private void Start()
    {
        animCurtains = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPaused) // input to change on Escape
        {
            //Time.timeScale = 0;
            isPaused = !isPaused;
            animCurtains.SetTrigger("Close");
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            Time.timeScale = 1;
            isPaused = !isPaused;
            animCurtains.SetTrigger("Open");
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
