using Effekseer.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using Effekseer;
using Unity.VisualScripting;

public class WoodObject : MonoBehaviour
{
    [Tooltip("ƒTƒEƒ“ƒh")]
    [SerializeField]
    private SE AttackSound;

    [SerializeField]
    private SE breakSound;

    [SerializeField]
    private SE downSound;

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
        AttackSound = GetComponent<SE>();
    }

    private void Update()
    {
        DownWood();
    }

    private void DownWood()
    {
        if(down)
        {
            breakSound.SoundEffct();
            down = false;
            this.gameObject.transform.position = posWood.transform.position;
        }

        if (change)
        {
            coll.SetActive(false);

            downWood.SetActive(true);

            this.gameObject.SetActive(false);

            downSound.SoundEffct();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponAttack"))
        {
            AttackSound.SoundEffct();
            emitter.Play();
            down = true;
        }

        if (collision.CompareTag("WoodChange"))
        {
            change = true;
        }
    }


}
