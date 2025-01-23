using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerCarryObject : MonoBehaviour
{
    private Rigidbody2D rig2D;

    private Animator anim;

    private PlayerController playerController;

    private PlayerSE SE;

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

    private Vector3 carryPos = Vector3.zero;

    [SerializeField]
    private float objectX ,objectY;

    [SerializeField]
    private bool not = false;

    [SerializeField]
    private GameObject noHand;

    [SerializeField]
    private float carryX;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        anim = GetComponent<Animator>();

        SE = GetComponent<PlayerSE>();

        objectY = -0.3f;
    }

    private void Update()
    {
        if(carryObject.name == "None")
        {
            not = true;
        }
        if (playerController.playerDekatuyo)
        {
            CarryObject();

            CarryPos();
        }

        if(onCarry)
        {
            CarryAnim();
        }
        else if(!onCarry)
        {
            CarryAnimEnd();
        }
    }

    private void CarryObject()
    {
        //キーボード
        if (Input.GetKeyDown("space") && !onCarry && objectTouch　&& playerController.isOnGround)
        {
            onCarry = true;
            carryObject.transform.parent = this.gameObject.transform;
            carryPos = carryObject.transform.position;
            rig2D = carryObject.GetComponent<Rigidbody2D>();
            carryObject.layer = 6;
            SE.CarrySound();
        }
        else if (Input.GetKeyDown("space") && onCarry)
        {
            onCarry = false;
            rig2D.bodyType = RigidbodyType2D.Dynamic;
            rig2D = null;
            carryObject.layer = 7;
            carryObject.transform.parent = null;
            SE.CarryOutSound();
        }

        //コントローラ
        if(Input.GetKeyDown("joystick button 3") && !onCarry && objectTouch && playerController.isOnGround)
        {
            onCarry = true;
            carryObject.transform.parent = this.gameObject.transform;
            carryPos = carryObject.transform.position;
            rig2D = carryObject.GetComponent<Rigidbody2D>();
            carryObject.layer = 6;
        }
        else if(Input.GetKeyDown("joystick button 3") && onCarry)
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
            objectX = carryX;
        }
        else if(!playerController.playerDirection)
        {
            objectX = -carryX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!not)
        {
            if (collision.CompareTag("CarryObject"))
            {
                objectTouch = true;
                carryObject = collision.gameObject;
            }
            else if (collision.CompareTag("CarryOutObject"))
            {
                objectTouch = false;
                carryObject = noHand;
            }
        }
    }

    private void CarryAnim()
    {
        anim.SetBool("otouto_Carry", true);
    }

    private void CarryAnimEnd()
    {
        anim.SetBool("otouto_Carry", false);
    }
}
