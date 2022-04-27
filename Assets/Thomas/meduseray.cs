using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meduseray : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject, 0.5f);
        }
    }

}
