using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftRight : MonoBehaviour
{
    private Rigidbody2D playerRgbd;
    public GameObject pivotPoint;
    private Animator playerAnim;

    public List<GameObject> soldiersList;
    public List<GameObject> soldiersList2;
    public List<GameObject> soldiersList3;

    public GameObject baton1;
    public GameObject baton2;
    public GameObject baton3;

    public List<GameObject> heartsList;

    public Vector2 punchPower;

    public float speedPlayer = 2f;

    public static bool canCollide = false;
    private bool canHit = true;
    private bool isDead = false;

    private void Start()
    {
        playerRgbd = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && canHit)
        {
            canCollide = true;
            playerAnim.SetTrigger("Rotate");
            StartCoroutine(ReloadHit());
        }

        if(heartsList.Count == 0 && !isDead)
        {
            isDead = true;
            GameManager.Instance.GameOver();
        }
    }

    private IEnumerator ReloadHit()
    {
        canHit = false;
        yield return new WaitForSeconds(1.5f);
        canHit = true;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            playerRgbd.velocity = Vector2.left * speedPlayer;
            //transform.position = new Vector3(transform.position.x - speedPlayer * 0.01f, transform.position.y, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRgbd.velocity = Vector2.right * speedPlayer;

            //transform.position = new Vector3(transform.position.x + speedPlayer * 0.01f, transform.position.y, 0);
        }
    }

}
