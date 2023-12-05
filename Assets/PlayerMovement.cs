using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float jumpSpeed;
    public GameObject crouchColliderObj;

    public Sprite crouchSprite;

    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D bc;
    bool jump;
    Sprite cachedPlayerSprite;
    float horizontalVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

        cachedPlayerSprite = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        horizontalVelocity = Input.GetAxis("Horizontal") * walkSpeed;
        if (Input.GetButtonDown("Fire1")) jump = true;
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            sr.sprite = crouchSprite;

            bc.enabled = false;
            crouchColliderObj.SetActive(true);
        }
        else
        {
            sr.sprite = cachedPlayerSprite;

            bc.enabled = true;
            crouchColliderObj.SetActive(false);
        };
    }

    void FixedUpdate()
    {
        Vector2 v = rb.velocity;
        v.x = horizontalVelocity;

        if (jump)
        {
            rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            jump = false;
        }

        rb.velocity = new Vector2(v.x * Time.fixedDeltaTime, rb.velocity.y) ;
    }
}
