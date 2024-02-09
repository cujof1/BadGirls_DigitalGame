using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Transform projectilesSpawnPoint;

    public GameObject bulletProjectile;
    public Vector2 bulletProjectileForce;

    public float projectileDelay = 5;

    public float timer = 0;

    public int damage;

    public AudioClip projectileSFX;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > projectileDelay)
        {
            GameObject projectileInstance = Instantiate(bulletProjectile, projectilesSpawnPoint.position, Quaternion.identity);

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(bulletProjectileForce);

            AudioSource.PlayClipAtPoint(projectileSFX, transform.position);

            timer = 0f;
        }
    }
}
