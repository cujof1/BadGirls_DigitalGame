using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicPigGames;

public class Enemy : MonoBehaviour
{
    public MagicPigGames.ProgressBar healthBar;

    public float maxHealth;
    float health;

    public GameObject tankTree;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health < 0)
        {
            Instantiate(tankTree, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

        public void Damage(float damage)
    {
        health -= damage;

        healthBar.SetProgress(health / maxHealth);
    }
}
