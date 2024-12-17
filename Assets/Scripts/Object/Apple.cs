using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SE getSound;

    private GameObject apple;

    [SerializeField]
    private GameContoller game;


    private void Start()
    {
        apple = this.gameObject;

        getSound = GetComponent<SE>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            getSound.SoundEffct();

            apple.SetActive(false);

            LifeUp();
        }
    }

    private void LifeUp()
    {
        if(game.playerLife < 6)
        {
            game.playerLife += 1;
        }
    }
}
