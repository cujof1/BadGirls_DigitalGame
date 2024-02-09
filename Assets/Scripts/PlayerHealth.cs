using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    int health;
    public int maxHealth;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            GameManager.Instance.OnPLayerKilled();
            Destroy(gameObject);
        }
    }

    public void DamagePlayer(int damage)
    {
        health -= damage;

        UIManager.Instance.UpdateHealthBar(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Crystals")
        {
            Destroy(collision.gameObject);

            if (health + 1 > maxHealth) return;

            health++;

            UIManager.Instance.UpdateHealthBar(health);
        }
    }
}
