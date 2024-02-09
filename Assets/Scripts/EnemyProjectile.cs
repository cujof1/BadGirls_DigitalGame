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
        PlayerHealth possiblePlayerHealthComp = null;
        possiblePlayerHealthComp = collision.gameObject.GetComponent<PlayerHealth>();
        if (possiblePlayerHealthComp == null) possiblePlayerHealthComp = collision.gameObject.transform.parent.GetComponent<PlayerHealth>();

        if (possiblePlayerHealthComp != null)
        {
            possiblePlayerHealthComp.DamagePlayer(damage);
            Destroy(gameObject);
        }
    }
}
