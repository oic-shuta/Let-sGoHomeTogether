using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCarryObject : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Rigidbody2D rigidBody;

    //オブジェクトを運んでる状態か
    [Tooltip("オブジェクトを運んでる状態")]
    [SerializeField]
    public  bool carryObject = false;

    [Tooltip("オブジェクトに触れてる状態")]
    [SerializeField]
    private bool playerObjectConTach = false;

    //触れているオブジェクト
    [Tooltip("触っているオブジェクト")]
    [SerializeField]
    private GameObject playerCarryObject = null;

    //オブジェクトを持った時に左右当たり判定を付ける
    [SerializeField]
    private GameObject carryColliderLeft = null;
    
    [SerializeField]
    private GameObject carryColliderRight = null;


    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        CarryObject();
        CarryColliderDirection();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(carryObject == false)
        {
            if (collision.CompareTag("CarryObject"))        //特定オブジェクトに触ったら
            {
                playerObjectConTach = true;
                playerCarryObject = collision.gameObject;   //触ったオブジェクト
            }
            else if (collision.CompareTag("CarryOutObject") ) //特定オブジェクトから離れた
            {
                playerObjectConTach = false;
                playerCarryObject = null;                   //触れたオブジェクトを初期化
            }
        }
        
    }

    private void CarryObject()
    {
        if (playerController.playerChange == false)     //ちびよわ操作の時オブジェクトを持てない
        {
            return;
        }
        else if (Input.GetKeyDown("space") && !carryObject && playerController.isOnGround && playerObjectConTach
                 || Input.GetKeyDown("joystick button 2") && !carryObject && playerController.isOnGround && playerObjectConTach)
        {
            playerCarryObject.transform.parent = this.gameObject.transform;       //オブジェクトの親をプレイヤーに移す
            carryObject = true;
        }
        else if (Input.GetKeyDown("space") && carryObject
                 || Input.GetKeyDown("joystick button 2") && carryObject)
        {
            playerCarryObject.transform.parent = null;           //オブジェクトの親を元に戻す
            carryObject = false;
            Debug.Log("離した");
        }
    }

    //オブジェクトがプレイヤーの正面に来る方向指定
    private void CarryColliderDirection()
    {
        if (carryObject)
        {
            //オブジェクトの前に当たり判定を出現させる
            if (playerController.playerDirection)
            {
                carryColliderRight.SetActive(true);
                carryColliderLeft.SetActive(false);
            }
            else if (!playerController.playerDirection)
            {
                carryColliderRight.SetActive(false);
                carryColliderLeft.SetActive(true);
            }
        }
        else if (!carryObject)
        {
            carryColliderRight.SetActive(false);
            carryColliderLeft.SetActive(false);
        } 
    }

}
