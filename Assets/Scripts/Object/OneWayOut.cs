using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayOut : MonoBehaviour
{
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("deta");
            this.gameObject.SetActive(false);
        }
    }
}

