using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReLoad : MonoBehaviour
{
    [SerializeField]
    private GameContoller game;

    [SerializeField]
    private GameObject chaeckPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            game.reSpawnPoint = this.gameObject;
            chaeckPoint.GetComponent<SpriteRenderer>().color = Color.red;
            this.gameObject.SetActive(false);
        }
    }
}
