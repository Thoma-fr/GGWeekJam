using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerMeduse : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public int speed;
    public bool canmove;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canmove = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Roof")
        {
            StartCoroutine(movetime());
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)&& canmove)
        {
            rb.AddForce(Vector2.up * 600);
            rb.AddForce(Vector2.left * speed);
            canmove = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && canmove)
        {
            rb.AddForce(Vector2.up * 600);
            rb.AddForce(Vector2.right * (speed+100));
            canmove = false;
        }
    }
    private IEnumerator movetime()
    {
        yield return new WaitForSeconds(0.1f);
        canmove = true;
    }
}
