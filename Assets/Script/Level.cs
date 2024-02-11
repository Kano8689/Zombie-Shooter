using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public GameObject lvlObj, homeObj;
    public Button[] allLevel;
    public Sprite[] winImg;
    public GameObject fill, empty;
    public GameObject[] starParent;
    int lvlno, maxlvl;
    // Start is called before the first frame update
    void Start()
    {
        lvlno = PlayerPrefs.GetInt("LevelNo", 1);
        maxlvl = PlayerPrefs.GetInt("MaxLevel", 1);

        //lvlno = 4;
        for (int i = 0; i < maxlvl; i++)
        {
            allLevel[i].interactable = true;
            allLevel[i].GetComponent<Image>().sprite = winImg[i];
        }

        for (int i = 1; i < maxlvl; i++)
        {
            int star = PlayerPrefs.GetInt("Star_" + i);
            for (int j = 1; j <= star; j++)
            {
                Instantiate(fill, starParent[(i - 1)].transform);
            }
            for (int j = 1; j <= (3 - star); j++)
            {
                Instantiate(empty, starParent[(i-1)].transform);
            }
            print(i + " = " + star);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onSelectLevel(int n)
    {
        PlayerPrefs.SetInt("LevelNo", n);

        SceneManager.LoadScene("Play");
    }

    public void onClickLevelBtn()
    {
        homeObj.SetActive(false);
        lvlObj.SetActive(true);
    }
    public void onClickPlay()
    {
        SceneManager.LoadScene("Play");
    }
}
