using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private SE getSound;

    private GameObject key;

    [SerializeField]
    private GameContoller game;

    private void Start()
    {
        key = this.gameObject;

        getSound = GetComponent<SE>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            getSound.SoundEffct();
            game.haveKey = true;
            key.SetActive(false);
        }
    }
}
