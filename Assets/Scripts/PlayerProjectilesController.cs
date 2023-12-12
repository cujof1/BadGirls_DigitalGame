using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectilesController : MonoBehaviour
{
    public bool selectedProjectileIsTree = false;

    //Preafabs
    public GameObject bouquetProjectile;
    public GameObject treeProjectile;

    //References
    public Transform projectilesSpawnPoint;

    //Variables
    public Vector2 bouquetProjectileForce;
    public Vector2 treeProjectileForce;

    //Cached
    PlayerMovement playerMovement;
    int collectedTrees;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (selectedProjectileIsTree == false)
            {
                GameObject bouquetProjectileInstance = Instantiate(bouquetProjectile, projectilesSpawnPoint.position, Quaternion.identity);
                bouquetProjectileInstance.GetComponent<Rigidbody2D>().AddForce(bouquetProjectileForce);
            }
            else if (selectedProjectileIsTree == true && collectedTrees > 0)
            {
                GameObject treeProjectileInstance = Instantiate(treeProjectile, projectilesSpawnPoint.position, Quaternion.identity);
                treeProjectileInstance.GetComponent<Rigidbody2D>().AddForce(treeProjectileForce);
                collectedTrees--;
            }
            
        }

        if (Input.GetButtonDown("Fire3"))
        {
            if (selectedProjectileIsTree == false) selectedProjectileIsTree = true;
            else selectedProjectileIsTree = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TreeCollectable")
        {
            Destroy(collision.gameObject);
            collectedTrees++;
        }
    }
}
