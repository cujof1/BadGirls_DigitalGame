using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeout = 5; 
    
    float timer = 0;

    public float damage;

    void Update()
    {
        timer += Time.deltaTime; 
        
        if (timer > timeout)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
