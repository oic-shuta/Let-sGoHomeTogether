using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private PlayerController controller;

    //傾くオブジェクト
    [SerializeField]
    private GameObject rotationObject = null;

    [SerializeField]
    private GameObject playerSprite = null;

    [SerializeField]
    private bool rotateOn = false;
    private void Start()
    {
        playerSprite = this.gameObject;
    }
    private void Update()
    {
        PlayerRotate();
    }

    private void PlayerRotate()
    {
        if (!controller.isOnGround)
        {
            rotateOn = false;
        }
        if (rotateOn)
        {
            playerSprite.transform.rotation = rotationObject.transform.rotation;
        }
        else if(!rotateOn)
        {
            playerSprite.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seesaw"))//シーソーに乗った時その傾きを得る
        {
            rotationObject = collision.gameObject;
            rotateOn = true;
        }
        else//それ以外だとまっすぐにする
        {
            rotateOn = false;
        }
    }
}
