using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCarryObject : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private Rigidbody2D rig2D;

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


    [SerializeField]
    private float x;

    //持った時のオブジェクトの位置
    [Tooltip("プレイヤーが持ってるときのオブジェクトの位置(プレイヤーが基準)")]
    [SerializeField]
    private Vector3 carrPos = Vector3.zero;

    //プレイヤーが持ち上げた時の高さ(プレイヤーの位置を差し引いた)
    [SerializeField]
    private float carryObjectY = 0;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        rig2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        CarryObject();
        CarryColliderDirection();
        CarryObjectPos();
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
            Debug.Log("持った");
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

    //持った時にオブジェクトを浮かせる
    private void CarryObjectPos()
    {
        //プレイヤーが持っている時
        if (carryObject)
        {
            Debug.Log("i");
            rig2D.bodyType = RigidbodyType2D.Static;　　//落下しないタイプに変更
            this.gameObject.layer = 6;
            //右を向いてるときにプレイヤーの右に行く
            if (playerController.playerDirection)
            {
                Debug.Log("u");
                gameObject.transform.position = new Vector3
                    (x * transform.position.x, (carrPos.y + carryObjectY) + transform.position.y, carrPos.z);
            }
            //左を向いてるときにプレイヤーの左に行く
            else if (!playerController.playerDirection)
            {
                gameObject.transform.position = new Vector3
                    (-x * transform.position.x, (carrPos.y + carryObjectY) + transform.position.y, carrPos.z);
            }
        }
        //プレイヤーがオブジェクトを離したとき
        else if (!carryObject)
        {
            rig2D.bodyType = RigidbodyType2D.Dynamic;　  //落下するタイプに変更

            this.gameObject.layer = 7;
        }
    }

}
