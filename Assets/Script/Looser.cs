using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Looser : MonoBehaviour
{
    public GameObject win, looser;
    //public GameObject fill, empty, starParent;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickRetry()
    {
        SceneManager.LoadScene("Play");
    }

    public void onClickNext()
    {
        SceneManager.LoadScene("Play");
    }

    public void onClickMainMenu()
    {
        SceneManager.LoadScene("Home");
    }

    
}
