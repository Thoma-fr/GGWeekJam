using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRgbd;

    private List<GameObject> puppetsList = new List<GameObject>();
    private GameObject puppetTaken;

    private Vector2 previousUpPos;
    public Animator animator;
    public float playerSpeed = 2f;
    public float downSpeed = 5f;
    public float maxDistance = 5f;

    private bool canMove = true;
    private bool comingUp = false;
    private bool atHisMAxHeight = false;
    private bool hasCollided = false;

    void Start()
    {
        playerRgbd = GetComponent<Rigidbody2D>();
        previousUpPos = transform.position;
        puppetsList.AddRange(GameObject.FindGameObjectsWithTag("Puppet"));
        animator.GetComponent<Animator>();
        animator.SetBool("catching", false);
    }

    void Update()
    {
        if(canMove)
            Move();

        if (Input.GetKey(KeyCode.S) && !comingUp)
        {
            canMove = false;
            animator.SetBool("catching", true);
            playerRgbd.velocity = Vector2.down * downSpeed;
            if(transform.position.y <= -maxDistance)
            {
                comingUp = true;
            }
        }

        if (comingUp)
        {
            if(puppetTaken == null)
            {
                playerRgbd.velocity = Vector2.up * downSpeed;
                if (transform.position.y >= previousUpPos.y)
                {
                    comingUp = false;
                    canMove = true;
                    atHisMAxHeight = false;
                }
            } else
            {
                if (!atHisMAxHeight)
                {
                    playerRgbd.velocity = Vector2.up * downSpeed;
                    if (transform.position.y >= previousUpPos.y + 3f)
                    {
                        StartCoroutine(GetRidOfPuppet());
                        atHisMAxHeight = true;
                    }
                }
                else
                {
                    playerRgbd.velocity = Vector2.down * downSpeed;
                    if (transform.position.y <= previousUpPos.y)
                    {
                        comingUp = false;
                        canMove = true;
                        atHisMAxHeight = false;
                    }
                }
            }
        }

        if(puppetsList.Count == 0 && transform.position.y >= previousUpPos.y)
        {
            Victory();
        }
    }

    private IEnumerator GetRidOfPuppet()
    {
        puppetTaken.transform.parent = null;
        puppetTaken.GetComponent<Rigidbody2D>().velocity = Vector2.up * downSpeed;
        yield return new WaitForSeconds(2f);
        Destroy(puppetTaken);
        puppetTaken = null;
        hasCollided = false;
    }

    private void Move()
    {
        animator.SetBool("catching",false);
        if (Input.GetKey(KeyCode.Q))
        {
            if(transform.position.x > -7)
            {
                playerRgbd.velocity = Vector2.left * playerSpeed;
            } else
            {
                playerRgbd.velocity = Vector2.zero;
            }
        } 
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 8)
            {
                playerRgbd.velocity = Vector2.right * playerSpeed;
            }
            else
            {
                playerRgbd.velocity = Vector2.zero;
            }
        }
    }

    private void Victory()
    {
        GameObject.FindObjectOfType<TimerManager>().timerRunning = false;
        StartCoroutine(LoadCinematique());
    }

    private IEnumerator LoadCinematique()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("CinematiqueEnd");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided)
        {
            if (collision.gameObject.CompareTag("Puppet"))
            {
                puppetsList.Remove(puppetTaken);
                int i = 0;
                foreach(GameObject puppet in puppetsList)
                {
                    if(puppet == null)
                    {
                        i++;
                    }
                }
                if(i + 1 == puppetsList.Count)
                {
                    puppetsList.Clear();
                }
                puppetTaken = collision.gameObject;
                puppetTaken.GetComponent<MovePuppets>().isMoving = false;
                puppetTaken.transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z);
                puppetTaken.transform.parent = transform;
                comingUp = true;
                hasCollided = true;
            }
        }
        
    }
}
