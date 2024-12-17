using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawObject : MonoBehaviour
{
    private SE sound;

    [SerializeField]
    private GameObject seesaw;

    [SerializeField]
    private GameObject maxRotate;

    [SerializeField]
    private GameObject minRotate;

    [SerializeField]
    private GameObject seesawPos;

    private void Start()
    {

        sound = GetComponent<SE>();
        seesaw = this.gameObject;
    }
    private void FixedUpdate()
{
        SeesawRotate();

        seesaw.transform.position = seesawPos.transform.position;
    }

    private void SeesawRotate()
    {
        if(seesaw.transform.rotation.z < minRotate.transform.rotation.z)
        {
            sound.SoundEffct();
            seesaw.transform.rotation = minRotate.transform.rotation;
        }
        else if(seesaw.transform.rotation.z > maxRotate.transform.rotation.z)
        {
            sound.SoundEffct();
            seesaw.transform.rotation = maxRotate.transform.rotation;
        }
        this.gameObject.transform.rotation = seesaw.transform.rotation;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // sound.SoundEffct();
        }
    }
}
