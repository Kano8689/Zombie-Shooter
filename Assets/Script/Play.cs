using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject[] allLevel;
    int lvlno;
    public GameObject playObj, looserObj, winObj;
    Gun g;
    // Start is called before the first frame update
    void Start()
    {
         g = FindAnyObjectByType<Gun>();

        lvlno = PlayerPrefs.GetInt("LevelNo", 1);
        for (int i = 0; i < 10; i++)
        {
            allLevel[i].SetActive(false);
        }
        allLevel[lvlno - 1].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Check()
    {
        if (g.n == 0)
        {
            playObj.SetActive(false);
            looserObj.SetActive(true);
        }
    }
}
