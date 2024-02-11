using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie_Movement : MonoBehaviour
{
    float speed = 0.003f;
    Animator animator;
    int[] winList = { 3, 4, 5, 2, 2, 3, 3, 7, 3, 20 };
    int lvlno, maxlvl;
    int star;
    int n;
    internal int score = 0;
    Play p;
    Gun g;
    
    // Start is called before the first frame update
    void Start()
    {
        p = FindAnyObjectByType<Play>();
        g = FindAnyObjectByType<Gun>();
        n = g.n;
        lvlno = PlayerPrefs.GetInt("LevelNo", 1);
        maxlvl = PlayerPrefs.GetInt("MaxLevel", 1);

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Zombie")
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }

        Win();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leftWall")
        {
            speed = 0.003f;
            //this.GetComponent<SpriteRenderer>().flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (collision.gameObject.tag == "rightWall")
        {
            speed = -0.003f;
            //this.GetComponent<SpriteRenderer>().flipX = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            speed = 0f;
            this.animator.SetTrigger("isDie");
            //collision.gameObject.tag = "dieZombie";
            g.cnt++;
            score += 300;
            //print(g.cnt);
        }

        //Win();
    }

    void Win()
    {
        lvlno = PlayerPrefs.GetInt("LevelNo", 1);

        if (g.cnt == winList[lvlno - 1])
        {
            star = PlayerPrefs.GetInt("Star");
            //print("star===" + star);
            PlayerPrefs.SetInt("Star_" + lvlno, star);

            lvlno++;

            if (maxlvl <= lvlno)
            {
                PlayerPrefs.SetInt("MaxLevel", lvlno);
            }
            PlayerPrefs.SetInt("LevelNo", lvlno);

            StartCoroutine(Hold());
        }
    }

    IEnumerator Hold()
    {
        yield return new WaitForSeconds(3f);

        p.playObj.SetActive(false);
        p.winObj.SetActive(true);
    }

}
