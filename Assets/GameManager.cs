using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool istimed;
    public float timerBeforeend;
    public static GameManager Instance { get { return instance; } }

    private Animator animCurtains;

    private bool isPaused = false;
    private bool canPause = true;

    public GameObject panelPause;
    private List<GameObject> rocksSpawned = new List<GameObject>();
    public SpawnRocks spawnManager;

    private Vector2 stockVelocity;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
   

    private void Start()
    {
        animCurtains = GetComponent<Animator>();
        panelPause.SetActive(false);
        if (istimed)
        {
            StartCoroutine(waitforEnd());
        }
    }
    private IEnumerator waitforEnd()
    {
        yield return new WaitForSeconds(timerBeforeend);
        animCurtains.SetTrigger("Close");

    }
    void Update()
    {
        if(canPause)
            Pause();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPaused) // input to change on Escape
        {
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        StopAllCoroutines();
        if (GameObject.FindGameObjectWithTag("Rock"))
        {
            rocksSpawned.AddRange(GameObject.FindGameObjectsWithTag("Rock"));
            for (int i = 0; i < rocksSpawned.Count; i++)
            {
                stockVelocity = rocksSpawned[i].GetComponent<Rigidbody2D>().velocity;
                rocksSpawned[i].GetComponent<Rigidbody2D>().gravityScale = 0;
                rocksSpawned[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        if(spawnManager != null)
            spawnManager.gameObject.SetActive(false);

        if (GameObject.FindObjectOfType<TimerManager>())
        {
            GameObject.FindObjectOfType<TimerManager>().timerRunning = false;
        }
        isPaused = !isPaused;
        StartCoroutine(MenuDisplay());
        animCurtains.SetTrigger("Close");
    }

    private IEnumerator MenuDisplay()
    {
        yield return new WaitForSeconds(2.6f);
        panelPause.SetActive(true);
    }

    private IEnumerator WaitBeforeSpawningAgain()
    {
        yield return new WaitForSeconds(4f);
        spawnManager.SpawnRockAtPosition();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        canPause = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        canPause = false;
        animCurtains.SetTrigger("Close");
        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(4.0f);
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        if (GameObject.FindGameObjectWithTag("Rock"))
        {
            for (int i = 0; i < rocksSpawned.Count; i++)
            {
                rocksSpawned[i].GetComponent<Rigidbody2D>().gravityScale = 0.6f;
                rocksSpawned[i].GetComponent<Rigidbody2D>().velocity = stockVelocity;
            }
        }
        rocksSpawned.Clear();

        if(spawnManager != null)
        {
            spawnManager.gameObject.SetActive(true);
            StartCoroutine(WaitBeforeSpawningAgain());
        }

        if (GameObject.FindObjectOfType<TimerManager>())
        {
            GameObject.FindObjectOfType<TimerManager>().timerRunning = true;
        }
        
        isPaused = !isPaused;
        panelPause.SetActive(false);
        animCurtains.SetTrigger("Open");
    }
}
