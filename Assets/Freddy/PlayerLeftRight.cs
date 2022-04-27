using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftRight : MonoBehaviour
{
    public Rigidbody2D leftArmRb;
    public Rigidbody2D rightArmRb;

    public List<GameObject> soldiersList;
    public List<GameObject> soldiersList2;
    public List<GameObject> soldiersList3;

    public List<GameObject> heartsList;

    public Vector2 punchPower;

    public float speedPlayer = 2f;

    public static bool canCollide = false;
    private bool canHit = true;

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.E) && canHit)
        {
            canCollide = true;
            leftArmRb.AddForce(punchPower, ForceMode2D.Impulse);
            rightArmRb.AddForce(punchPower, ForceMode2D.Impulse);
            StartCoroutine(ReloadHit());
        }

        if(heartsList.Count == 0)
        {
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
            transform.position = new Vector3(transform.position.x - speedPlayer * 0.01f, transform.position.y, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speedPlayer * 0.01f, transform.position.y, 0);
        }
    }

}
