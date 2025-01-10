using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll : MonoBehaviour
{
    public bool deadGhost;

    public bool deadWolf;

    private void Start()
    {
        deadGhost = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaeponLight"))
        {
            deadGhost = true;
        }
        if (collision.CompareTag("WeaponAttack"))
        {
            deadWolf = true;
        }
    }
}
