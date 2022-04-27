using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private Animator animCurtains;

    private bool isPaused = false;
    private bool canPause = true;

    public GameObject panelGameOver;
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
        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
    }

    // Update is called once per frame
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

        spawnManager.gameObject.SetActive(false);
        isPaused = !isPaused;
        panelPause.SetActive(true);
        animCurtains.SetTrigger("Close");
    }

    private IEnumerator WaitBeforeSpawningAgain()
    {
        yield return new WaitForSeconds(4f);
        spawnManager.SpawnRockAtPosition();
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        panelGameOver.SetActive(false);
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
        panelGameOver.SetActive(true);
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
        spawnManager.gameObject.SetActive(true);
        StartCoroutine(WaitBeforeSpawningAgain());
        isPaused = !isPaused;
        panelPause.SetActive(false);
        animCurtains.SetTrigger("Open");
    }
}
