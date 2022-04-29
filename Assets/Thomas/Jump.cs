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
        if (jump || Input.GetKeyDown(KeyCode.Z))
        {
            rb.AddForce(Vector2.up * jumpforce);
            jump = false;

        }
        if (down || Input.GetKeyDown(KeyCode.S))
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
            case 2:
                hearth1.GetComponent<Animator>().SetTrigger("Death");
                Destroy(hearth1,3f); 
                break;
                case 1:
                hearth2.GetComponent<Animator>().SetTrigger("Death");
                Destroy(hearth2,3f) ; break;
            case 0:
                GameManager.Instance.GameOver();
                hearth3.GetComponent<Animator>().SetTrigger("Death");
                Destroy(hearth3,3f ); break;
            default:
                break;
        }
    }
}
