using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPos : MonoBehaviour
{
    [SerializeField]
    private PlayerAttack attack;

    [SerializeField]
    private PlayerController controller;

    [SerializeField]
    private GameObject attackColl;

    //移動開始位置
    [SerializeField] private Transform strat;

    //移動終了位置
    [SerializeField] private Transform right;
    [SerializeField] private Transform left;

    //移動する方向
    [SerializeField] private Transform dest;

    
    [SerializeField] private bool on = false;

    //移動速度
    [SerializeField] private float speed;
    private void Start()
    {
        attackColl = this.gameObject;

        dest = right;
    }

    void Update()
    {
        //オンの間移動する
        if (on)
        {
            UpdateMove();        
        }

        if (controller.playerDirection)
        {
            dest = right;
        }
        else if(!controller.playerDirection)
        {
            dest = left;
        }

        var dist = Vector3.Distance(dest.position,this.transform.position);

        if (!attack.attackPlayer)
        {
            attackColl.transform.position = strat.position;
        }
    }

    //移動処理
    private void UpdateMove()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,
                dest.position, speed * Time.deltaTime);
    }
}
