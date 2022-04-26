using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftRight : MonoBehaviour
{
    public float speedPlayer = 2f;
    // Update is called once per frame
    void Update()
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
