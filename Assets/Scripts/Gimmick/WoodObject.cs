using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class WoodObject : MonoBehaviour
{
    [SerializeField]
    private GameObject coll;

    [SerializeField]
    private GameObject downWood;

    [SerializeField]
    private bool down = false;

    [SerializeField]
    private bool change = false;

    [SerializeField]
    private GameObject posWood;

    private void Start()
    {
        
    }

    private void Update()
    {
        TEST();
    }

    private void TEST()
    {
        if(down)
        {
            down = false;
            this.gameObject.transform.position = posWood.transform.position;
        }

        if (change)
        {
            coll.SetActive(false);

            downWood.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponAttack"))
        {
            down = true;
        }

        if (collision.CompareTag("WoodChange"))
        {
            change = true;
        }
    }


}
