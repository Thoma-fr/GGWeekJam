using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadsceneacte1 : MonoBehaviour
{
    public GameObject Player;
    public int timer;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForLoad());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator waitForLoad()
    {
        yield return new WaitForSeconds(timer);
        if(Player!=null)
        {
            Player.GetComponent<Jump>().enabled = false;
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
