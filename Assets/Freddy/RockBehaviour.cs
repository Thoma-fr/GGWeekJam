using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    public float power;
    private bool canShoot = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Arm") && PlayerLeftRight.canCollide == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.right * power;
            Debug.Log("Hit!");
        }
    }
}
