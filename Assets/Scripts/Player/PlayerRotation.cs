using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRotation : MonoBehaviour
{

    //傾くオブジェクト
    [SerializeField]
    private GameObject rotationObject = null;

    [SerializeField]
    private GameObject playerSprite = null;
    private void Start()
    {
        playerSprite = this.gameObject;
    }
    private void Update()
    {
        playerSprite.transform.rotation = rotationObject.transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Seesaw"))//シーソーに乗った時その傾きを得る
        {
            rotationObject = collision.gameObject;
        }
        else//それ以外だとまっすぐにする
        {
            rotationObject = collision.gameObject;
        }
    }
}
