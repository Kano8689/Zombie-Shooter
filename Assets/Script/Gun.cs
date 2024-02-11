using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject Bullet, gunPoint;
    public GameObject[] bulleteDispImg;
    LineRenderer line;
    internal int n;
    internal int cnt;
    float Angle;
    int star = 0;
    internal int score = 0;
    Play p;
    // Start is called before the first frame update
    void Start()
    {
        p = FindAnyObjectByType<Play>();
        //Instant = this;
        line = GetComponent<LineRenderer>();
        n = bulleteDispImg.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 gunPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        line.SetPosition(0, gunPoint.transform.position);
        line.SetPosition(1, mousePos);

        Vector2 offSet = new Vector2(mousePos.x - gunPos.x, mousePos.y - gunPos.y);
        Angle = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Angle);

        if (Input.GetMouseButtonUp(0))
        {
            bulletFire();
        }
        //bulletFire();
    }


    void bulletFire()
    {

        if (n>0)
        {
            Destroy(bulleteDispImg[n - 1]);
            n--;
        }
        //print("blt = " + n);

        Vector2 Direction = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        GameObject g = Instantiate(Bullet, gunPoint.transform.position, Quaternion.Euler(0f,0f, Angle));
        g.GetComponent<Rigidbody2D>().AddForce(Direction * 1500);
        Destroy(g, 3f);
        cntStar();
        if (n == 0)
        {
            StartCoroutine(Hold());
        }
    }

    public void cntStar()
    {
        score = n * 500;
        if (n == 4)
        {
            star = 3;
        }
        if (n == 3)
        {
            star = 2;
        }
        if (n <= 2)
        {
            star = 1;
        }
        PlayerPrefs.SetInt("Star", star);
        //print("star=" + star);
    }
    IEnumerator Hold()
    {
        yield return new WaitForSeconds(5f);

        p.playObj.SetActive(false);
        p.looserObj.SetActive(true);
    }
}
