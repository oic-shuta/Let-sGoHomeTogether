using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCarryObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rig2D;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameObject carryObject;

    [SerializeField]
    private GameObject collisionObjectRight;
    
    [SerializeField]
    private GameObject collisionObjectLeft;

    [SerializeField]
    public bool onCarry = false;

    [SerializeField]
    private bool objectTouch = false;

    [SerializeField]
    private Vector3 carryPos = Vector3.zero;

    [SerializeField]
    private float objectX ,objectY;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        objectY = 0.5f;
    }

    private void Update()
    {
        CarryObject();

        CarryPos();
    }

    private void CarryObject()
    {
        if (Input.GetKeyDown("space") && !onCarry && objectTouch
            || Input.GetKeyDown("joystick button 3") && !onCarry && objectTouch)
        {
            onCarry = true;
            carryObject.transform.parent = this.gameObject.transform;
            carryPos = carryObject.transform.position;
            rig2D = carryObject.GetComponent<Rigidbody2D>();
            carryObject.layer = 6;
        }
        else if (Input.GetKeyDown("space") && onCarry 
            || Input.GetKeyDown("joystick button 3") && onCarry)
        {
            onCarry = false;
            rig2D.bodyType = RigidbodyType2D.Dynamic;
            rig2D = null;
            carryObject.layer = 7;
            carryObject.transform.parent = null;
        }
    }

    private void CarryPos()
    {
        CarryDirection();
        if (onCarry)
        {
            rig2D.bodyType = RigidbodyType2D.Kinematic;
            carryObject.transform.position = new Vector3
                (objectX + this.gameObject.transform.position.x,this.gameObject.transform.position.y + objectY, carryPos.z);
            if(objectX < 0)
            {
                collisionObjectLeft.SetActive(true);
                collisionObjectRight.SetActive(false);
            }
            else if(objectX > 0)
            {
                collisionObjectRight.SetActive(true);
                collisionObjectLeft.SetActive(false);
            }
        }
        else if (!onCarry)
        {
            collisionObjectLeft.SetActive(false);
            collisionObjectRight.SetActive(false);
        }
    }

    private void CarryDirection()
    {
        if (playerController.playerDirection)
        {
            objectX = 1;
        }
        else if(!playerController.playerDirection)
        {
            objectX = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CarryObject"))
        {
            objectTouch = true;
            carryObject = collision.gameObject;
        }
        else if (collision.CompareTag("CarryOutObject"))
        {
            objectTouch = false;
            carryObject = null;
        }
    }
}
