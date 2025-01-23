using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSE : MonoBehaviour
{
    [SerializeField]
    private AudioSource Source;

    [SerializeField]
    private AudioClip SE; 

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wolf"))
        {
            Source.PlayOneShot(SE);
        }
    }
}
