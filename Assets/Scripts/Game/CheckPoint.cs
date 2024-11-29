using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private GameContoller gameController;


    [SerializeField]
    private GameObject chaeckPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.reSpawnPoint = this.gameObject;
            chaeckPoint.GetComponent<SpriteRenderer>().color = Color.red;
            this.gameObject.SetActive(false);
        }
    }
}
