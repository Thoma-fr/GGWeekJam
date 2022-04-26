using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerMeduse : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * speed);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * speed);
        }
    }
}
