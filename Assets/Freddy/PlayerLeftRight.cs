using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftRight : MonoBehaviour
{
    public Rigidbody2D leftArmRb;
    public Rigidbody2D rightArmRb;

    public Vector2 punchPower;

    public float speedPlayer = 2f;


    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.E))
        {
            leftArmRb.AddForce(punchPower, ForceMode2D.Impulse);
            rightArmRb.AddForce(punchPower, ForceMode2D.Impulse);
        }
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
