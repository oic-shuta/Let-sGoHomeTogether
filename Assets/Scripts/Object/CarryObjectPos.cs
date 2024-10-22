using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPos : MonoBehaviour
{
    [SerializeField]
    private PlayerCarryObject playerCarry;

    [SerializeField]
    private PlayerController playerController;
    
    [SerializeField]
    private Rigidbody2D rig2D;

    [SerializeField]
    private GameObject playerObject;

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
        rig2D = GetComponent<Rigidbody2D>();

        carrPos = this.gameObject.transform.position;

        //carryObjectY = 3.5f;
    }

    private void Update()
    {
        CarryObjectPos();
    }

    //持った時にオブジェクトを浮かせる
    private void CarryObjectPos()
    {
        //プレイヤーが持っている時
        if (playerCarry.carryObject)
        {
            rig2D.bodyType = RigidbodyType2D.Static;　　//落下しないタイに変更
            this.gameObject.layer = 6;                  
            //右を向いてるときにプレイヤーの右に行く
            if (playerController.playerDirection)               
            {
                gameObject.transform.position = new Vector3
                    (x + playerObject.transform.position.x, (carrPos.y + carryObjectY) + playerObject.transform.position.y, carrPos.z);
            }
            //左を向いてるときにプレイヤーの左に行く
            else if (!playerController.playerDirection)
            {
                gameObject.transform.position = new Vector3
                    (-x + playerObject.transform.position.x, (carrPos.y + carryObjectY) + playerObject.transform.position.y, carrPos.z);
            }
        }
        //プレイヤーがオブジェクトを離したとき
        else if (!playerCarry.carryObject)
        {
            rig2D.bodyType = RigidbodyType2D.Dynamic;　  //落下するタイプに変更

            this.gameObject.layer = 7;
        }
    }
}
