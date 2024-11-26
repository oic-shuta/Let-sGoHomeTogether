using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rig2D;

    [SerializeField]
    private GameObject coll;


    [SerializeField]
    private GameObject downWood;

    [SerializeField]
    private bool down = false;


    [SerializeField]
    private bool change = false;

    [SerializeField]
    private GameObject woodPos;

    private void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();


        rig2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        TEST();
    }

    private void TEST()
    {
        if(down)
        {

            rig2D.bodyType = RigidbodyType2D.Dynamic;
            down = false;
            this.gameObject.transform.position = woodPos.transform.position;
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

            rig2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }


}
