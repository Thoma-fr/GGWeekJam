using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance { get { return instance; } }

    public float speedPlayer = 0.1f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speedPlayer, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speedPlayer, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = new Vector3(transform.position.x - speedPlayer, transform.position.y, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speedPlayer, transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Button is working = Space");
        }
    }
}
