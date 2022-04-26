using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    public Transform startLineSpawn;
    public Transform endLineSpawn;

    public GameObject spawnRock;
    private GameObject cloneRock;

    public float punchPower;
    private void Start()
    {
        SpawnRockAtPosition();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startLineSpawn.position, endLineSpawn.position);
    }

    private void SpawnRockAtPosition()
    {
        Vector2 randomPos = new Vector2(Random.Range(startLineSpawn.position.x, endLineSpawn.position.x), startLineSpawn.position.y);
        cloneRock = Instantiate(spawnRock, randomPos, Quaternion.identity);
        float randomTime = Random.Range(1.2f, 2.1f);
        StartCoroutine(ShotRate(randomTime));
    }

    private IEnumerator ShotRate(float rate)
    {
        yield return new WaitForSeconds(rate);
        SpawnRockAtPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arm"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * punchPower;
            Debug.Log(gameObject);
        }
    }
}
