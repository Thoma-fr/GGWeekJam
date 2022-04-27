using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour
{
    public float power;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Arm") && PlayerLeftRight.canCollide == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.right * power;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            int randWay = Random.Range(0, 2);
            if(randWay == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(2, 3, 0); 
            } else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-2, 3, 0);
            }
            gameObject.GetComponent<Collider2D>().enabled = false;

            if (GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList.Count != 0)
            {
                for (int i = 0; i < GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList.Count; i++)
                {
                    Destroy(GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList[i]);
                }
                GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList.Clear();

                GameObject.FindObjectOfType<PlayerLeftRight>().heartsList[2].SetActive(false);
                GameObject.FindObjectOfType<PlayerLeftRight>().heartsList.RemoveAt(2);

            }

            else if (GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList.Count == 0 && GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList2.Count != 0)
            {
                for (int i = 0; i < GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList2.Count; i++)
                {
                    Destroy(GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList2[i]);
                }
                GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList2.Clear();

                GameObject.FindObjectOfType<PlayerLeftRight>().heartsList[1].SetActive(false);
                GameObject.FindObjectOfType<PlayerLeftRight>().heartsList.RemoveAt(1);

            }

            else if (GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList2.Count == 0 && GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList3.Count != 0)
            {
                for (int i = 0; i < GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList3.Count; i++)
                {
                    Destroy(GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList3[i]);
                }
                GameObject.FindObjectOfType<PlayerLeftRight>().soldiersList3.Clear();

                GameObject.FindObjectOfType<PlayerLeftRight>().heartsList[0].SetActive(false);
                GameObject.FindObjectOfType<PlayerLeftRight>().heartsList.Clear();

            }
        }
    }
}
