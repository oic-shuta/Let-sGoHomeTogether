using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    [Tooltip("����ʍs�I�u�W�F�N�g")]
    [SerializeField]
    private GameObject boxObject;

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxObject.SetActive(true);
        }
    }
}
