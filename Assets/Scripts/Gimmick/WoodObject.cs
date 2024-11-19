using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rig2D;

    [SerializeField]
    private GameObject wood;

    [SerializeField]
    private GameObject downWood;

    [SerializeField]
    private bool down = false;

    private void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();

        wood = this.gameObject;
    }

    private void Update()
    {
        TEST();
    }

    private void TEST()
    {
        if(down)
        {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponAttack"))
        {
            down = true;
        }
    }


}
