using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public int jumpforce;
    public bool jump;
    public bool down;
    public int life = 3;
    public GameObject hearth1, hearth2, hearth3;
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
        if (down)
        {
            rb.AddForce(Vector2.up * -(jumpforce*2));
            down = false;
        }  
        
    }
    public void takeDamage()
    {
        life--;
        switch (life)
        {
            case 2: Destroy(hearth1 ); break;
                case 1: Destroy(hearth2 ); break;
            case 0: Destroy(hearth3 ); break;
            default:
                break;
        }
    }
}
