using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() == null) return;

        GameManager.Instance.OnReachedEndOfLevel();
        gameObject.SetActive(false);
    }
}
