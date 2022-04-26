using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public int jumpforce;
    public bool jump;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpforce);
            jump = false;
        }
            
        
    }
}