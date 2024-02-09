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

    public AudioClip bouquetShootSFX;
    [Range(0, 1)] public float bouquetShootVolume;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        if (UIManager.Instance != null) UIManager.Instance.UpdateTreesCountDisplay(collectedTrees);
        else FindObjectOfType<UIManager>().UpdateTreesCountDisplay(collectedTrees);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
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
                UIManager.Instance.UpdateTreesCountDisplay(collectedTrees);
            }


            AudioSource.PlayClipAtPoint(bouquetShootSFX, transform.position, bouquetShootVolume);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
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

            UIManager.Instance.UpdateTreesCountDisplay(collectedTrees);
        }
    }
}
