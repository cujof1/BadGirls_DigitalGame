using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float jumpSpeed;
    public GameObject crouchColliderObj;
    public Sprite crouchSprite;
    public AudioSource walkingSoundSource;

    public AudioClip jumpSFX;
    public float jumpSFXVolume;

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
        if (Input.GetKeyDown(KeyCode.Mouse0)) jump = true;
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            sr.enabled = false;
            //transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

            bc.enabled = false;
            crouchColliderObj.SetActive(true);
        }
        else
        {
            sr.enabled = true;
            //sr.sprite = cachedPlayerSprite;

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
            AudioSource.PlayClipAtPoint(jumpSFX, transform.position, jumpSFXVolume);

            jump = false;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            return;
        }

        if (v.x == 0f) walkingSoundSource.Pause();
        else walkingSoundSource.UnPause();

        rb.velocity = new Vector2(v.x * Time.fixedDeltaTime, rb.velocity.y) ;
    }
}
