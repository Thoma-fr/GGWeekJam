using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRgbd;

    private List<GameObject> puppetsList = new List<GameObject>();
    private GameObject puppetTaken;

    private Vector2 previousUpPos;

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
    }

    void Update()
    {
        if(canMove)
            Move();

        if (Input.GetKey(KeyCode.E) && !comingUp)
        {
            canMove = false;
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
        if (Input.GetKey(KeyCode.Q))
        {
            playerRgbd.velocity = Vector2.left * playerSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRgbd.velocity = Vector2.right * playerSpeed;
        }
    }

    private void Victory()
    {
        Debug.Log("Bravo!");
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
                Debug.Log(i);
                if(i + 1 == puppetsList.Count)
                {
                    puppetsList.Clear();
                }
                puppetTaken = collision.gameObject;
                puppetTaken.transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z);
                puppetTaken.transform.parent = transform;
                comingUp = true;
                hasCollided = true;
            }
        }
        
    }
}
