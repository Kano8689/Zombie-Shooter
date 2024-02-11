using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Bounce : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        float y = velocity.y;
        Vector2 vel = rb.velocity;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(y, vel.x) * 180 / (float)Mathf.PI, new Vector3(0f, 0f, 1.1f));
    }
}
