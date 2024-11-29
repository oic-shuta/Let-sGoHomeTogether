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

    //�ړ��J�n�ʒu
    [SerializeField] private Transform strat;

    //�ړ��I���ʒu
    [SerializeField] private Transform right;
    [SerializeField] private Transform left;

    //�ړ��������
    [SerializeField] private Transform dest;

    
    [SerializeField] private bool on = false;

    //�ړ����x
    [SerializeField] private float speed;
    private void Start()
    {
        attackColl = this.gameObject;

        dest = right;
    }

    void Update()
    {
        //�I���̊Ԉړ�����
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

    //�ړ�����
    private void UpdateMove()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,
                dest.position, speed * Time.deltaTime);
    }
}
