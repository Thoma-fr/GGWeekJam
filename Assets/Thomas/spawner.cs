using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject bullet;
    public GameObject upBullet;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawncourou());
        StartCoroutine(spawncourou2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator spawncourou()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        GameObject newBullet= Instantiate(bullet,transform.position,transform.rotation);
        StartCoroutine(spawncourou());
    }
    public IEnumerator spawncourou2()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        GameObject newBullet = Instantiate(upBullet, spawnPoint2.position, transform.rotation);
        StartCoroutine(spawncourou2());
    }
}
