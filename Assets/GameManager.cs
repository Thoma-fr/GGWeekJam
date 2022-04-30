using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Animator animCurtains;
    public GameObject canvasMainMenu;
    private GameObject goToStock;

    public float timerBeforeend;
    private float timeToReplace;
    public string sceneName;

    public bool istimed;
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
        if(panelPause != null)
            panelPause.SetActive(false);

        if (istimed)
        {
            StartCoroutine(waitforEnd(timerBeforeend));
        }

        if (canvasMainMenu != null)
        {
            //canvasMainMenu.SetActive(false);
            StartCoroutine(OpenCurtainsMainMenu());
        }
    }

    private IEnumerator OpenCurtainsMainMenu()
    {
        animCurtains.SetTrigger("Open");
        yield return new WaitForSeconds(4f);
        canvasMainMenu.SetActive(true);
    }

    private IEnumerator waitforEnd(float timer)
    {
        yield return new WaitForSeconds(timer);
        animCurtains.SetTrigger("Close");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator SkipCinematic()
    {
        animCurtains.SetTrigger("Close");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName);
    }
    void Update()
    {
        if (!isPaused)
        {
            timeToReplace += Time.deltaTime;
        }

        if(canPause && panelPause != null)
            Pause();

        if(panelPause == null && Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(SkipCinematic());
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) // input to change on Escape
        {
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        StopAllCoroutines();
        if (GameObject.FindObjectOfType<Jump>())
        {
            goToStock = GameObject.FindObjectOfType<Jump>().gameObject.transform.parent.gameObject;
            goToStock.SetActive(false);
        }

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
            GameObject.FindObjectOfType<TimerManager>().timerTxt.enabled = false;
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
        if(sceneName == "cinematicminigame1")
            StartCoroutine(waitforEnd(timerBeforeend - timeToReplace));

        if (goToStock != null)
        {
            goToStock.SetActive(true); // can't find the gameobject cause it isn't active
        }

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
            GameObject.FindObjectOfType<TimerManager>().timerTxt.enabled = true;

        }

        isPaused = !isPaused;
        panelPause.SetActive(false);
        animCurtains.SetTrigger("Open");
    }
}
