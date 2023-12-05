using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPhysics : MonoBehaviour
{
    Rigidbody2D rb; //einai to diko moy rigit body poy orizw
    public float speed =5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            rb.velocity += new Vector2(5, 0);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            rb.velocity += new Vector2(-5, 0);
        }
    }
}
