using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private GameObject key;

    [SerializeField]
    private GameContoller game;

    private void Start()
    {
        key = this.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            game.haveKey = true;
            key.SetActive(false);
        }
    }
}
