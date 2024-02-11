using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject fill, empty, starParent;
    public Text scoreBoard;
    int star = 0;
    int score = 0;
    Gun g;
    Zombie_Movement zm;
    // Start is called before the first frame update
    void Start()
    {
        g = FindAnyObjectByType<Gun>();
        zm = FindAnyObjectByType<Zombie_Movement>();
        star = PlayerPrefs.GetInt("Star");
        //print(g.score);
        //print(zm.score);
        score = g.score + zm.score;
        scoreBoard.text = "" + score;
        putStar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void putStar()
    {
        for (int i = 1; i <= star; i++)
        {
            Instantiate(fill, starParent.transform);
        }
        for(int i = 1; i <= (3 - star); i++)
        {
            Instantiate(empty, starParent.transform);
        }
    }
}
