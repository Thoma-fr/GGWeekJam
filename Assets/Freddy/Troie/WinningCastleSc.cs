using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningCastleSc : MonoBehaviour
{
    private List<GameObject> castlePiece = new List<GameObject>();

    public GameObject winningTrigger;

    // Start is called before the first frame update
    void Start()
    {
        castlePiece.AddRange(GameObject.FindGameObjectsWithTag("CastlePiece"));

    }
    private IEnumerator waitforEnd()
    {

        GameManager.Instance.animCurtains.SetTrigger("Close");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Meduse");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            if (castlePiece.Count == 3)
            {
                castlePiece[2].GetComponent<Rigidbody2D>().velocity = Vector2.up * 5.0f;
                castlePiece.Remove(castlePiece[2]);
            }
            else if (castlePiece.Count == 2)
            {
                castlePiece[1].GetComponent<Rigidbody2D>().velocity = Vector2.right * 5.0f;
                castlePiece.Remove(castlePiece[1]);
            }
            else if (castlePiece.Count == 1)
            {
                castlePiece[0].GetComponent<Rigidbody2D>().velocity = Vector2.right * 3.0f;
                castlePiece.Remove(castlePiece[0]);
                RockBehaviour.canBeHurt = false;
                winningTrigger.GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
}
