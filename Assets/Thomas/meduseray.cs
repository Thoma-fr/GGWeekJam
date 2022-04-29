using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meduseray : MonoBehaviour
{
    public GameObject statue;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject newStatue= Instantiate(statue, other.gameObject.transform.position,other.gameObject.transform.rotation);
            GameManager.Instance.GameOver();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("PNJ"))
        {
            GameObject newStatue = Instantiate(statue, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Destroy(other.gameObject);
        }
    }

}
