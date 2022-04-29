using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RunEndZone : MonoBehaviour
{
    
    
    public string sceneName;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(waitForLoad());
        }
        if (other.CompareTag("PNJ"))
        {
            GameManager.Instance.GameOver();
        }
    }
    private IEnumerator waitForLoad()
    {
        
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
