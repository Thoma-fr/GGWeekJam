using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public int runforce;
    //public 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector2.right * runforce);
            rb.AddForce(Vector2.right * runforce);
        }
    }
}
