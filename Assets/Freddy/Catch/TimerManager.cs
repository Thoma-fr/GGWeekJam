using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;

    public float timer = 30f;

    public bool timerRunning = true;
    private bool gameOver = false;
    private bool timerDone = true;


    private Animator animCurtains;
    private void Start()
    {
        animCurtains = GetComponent<Animator>();
        animCurtains.SetTrigger("Open");
    }

    private void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;
        }

        if(timer < 10f)
        {
            if(timer > 0)
            {
                timerTxt.text = "00:0" + ((int)timer).ToString();
            } else
            {
                timerRunning = false;
                timer = 0f;
                if(timer == 0f && timerDone)
                {
                    gameOver = true;
                    timerDone = false;
                }
            }
        } else
        {
            timerTxt.text = "00:" + ((int)timer).ToString();
        }
        if (gameOver)
        {
            gameOver = false;
            GameManager.Instance.GameOver();
        }
    }
}
