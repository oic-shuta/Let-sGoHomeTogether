using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rig2D;

    [SerializeField]
    private GameObject seesawObject = null;

    [SerializeField]
    private GameObject CenterObject = null;

    [SerializeField]
    private GameObject Dekatuyo = null;

    [SerializeField]
    private GameObject Chibiyowa = null;

    [SerializeField]
    private GameObject BoxObject = null;

    private Vector3 playerPos = Vector3.zero;

    [SerializeField]
    private float seesawRota = 0;

    [SerializeField]
    private float maxRotation = 0;

    [SerializeField]
    private float minRotation = 0;

    [SerializeField]
    private bool rotationLeft = false;

    [SerializeField]
    private bool rotationRight = false;

    [SerializeField]
    private bool onPlayer = false;

    [SerializeField]
    private Vector3 seesawCenterLine = Vector3.zero;

    private void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();

        seesawObject = GetComponent<GameObject>();

        maxRotation = 20;

        minRotation = -20;

        seesawCenterLine = CenterObject.transform.position;
    }

    private void Update()
    {
        OnPlayerSeesaw();

        RotationSeesaw();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlayer = true;
            if(collision == Dekatuyo)
            {
                playerPos = Dekatuyo.transform.position;
            }
            else if(collision == Chibiyowa)
            { 
                playerPos = Chibiyowa.transform.position;
            }
        }
        else
        {
            onPlayer = false;
        }

    }

    private void RotationSeesaw()
    {
        if (rotationRight)
        {
            seesawObject.transform.rotation = new Quaternion(0,0,15,0);
        }
    }

    private void OnPlayerSeesaw()
    {
        if (onPlayer)
        {
            if(seesawCenterLine.x < playerPos.x)
            {
                rotationRight = true;
            }
            else if(seesawCenterLine.x > playerPos.x)
            {
                rotationLeft = true;
            }
        }
    }
}
