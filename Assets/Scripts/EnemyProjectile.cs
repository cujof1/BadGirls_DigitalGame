using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float timeout = 5;

    float timer = 0;

    public int damage;

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
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Destroy(gameObject);
        }
    }
}
