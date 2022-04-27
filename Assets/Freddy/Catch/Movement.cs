using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRgbd;

    private Vector2 previousUpPos;

    public float playerSpeed = 2f;
    public float downSpeed = 5f;
    public float maxDistance = 5f;

    private bool canMove = true;
    private bool comingUp = false;

    void Start()
    {
        playerRgbd = GetComponent<Rigidbody2D>();
        previousUpPos = transform.position;
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
            playerRgbd.velocity = Vector2.up * downSpeed;
            if (transform.position.y >= previousUpPos.y + 3f)
            {
                playerRgbd.velocity = Vector2.down * downSpeed;// pb to fix -> going up and down cause comingup=true
                if(transform.position.y <= previousUpPos.y)
                {
                    comingUp = false;
                    canMove = true;
                }
            }
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puppet"))
        {
            collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z);
            collision.gameObject.transform.parent = transform;
            comingUp = true;
        }
    }
}
