using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using Effekseer;
using Unity.VisualScripting;

public class WoodObject : MonoBehaviour
{
    private WoodSE SE;

    [SerializeField]
    private EffekseerEmitter emitter;

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
        SE = GetComponent<WoodSE>();
    }

    private void Update()
    {
        DownWood();
    }

    private void DownWood()
    {
        if(down)
        {
            SE.BreakWood();
            down = false;
            this.gameObject.transform.position = posWood.transform.position;
        }

        if (change)
        {
            coll.SetActive(false);

            downWood.SetActive(true);

            this.gameObject.SetActive(false);

            SE.DownWood();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponAttack"))
        {
            SE.DamageWood();
            emitter.Play();
            down = true;
        }

        if (collision.CompareTag("WoodChange"))
        {
            change = true;
        }
    }


}
