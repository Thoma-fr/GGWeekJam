using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
   // public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        //speed = (speed + (speed * 4f) * Time.deltaTime);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
}
