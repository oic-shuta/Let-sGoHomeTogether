using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    //�ړ��J�n�ʒu
    [SerializeField] private Transform strat;

    //�ړ��I���ʒu
    [SerializeField] private Transform end;

    //�ړ��������
    [SerializeField] private Transform dest;

    
    [SerializeField] private bool on = false;

    //�ړ����x
    [SerializeField] private float speed;
    private void Start()
    {
        dest = end;
    }

    void Update()
    {
        //�I���̊Ԉړ�����
        if (on)
        {
            UpdateMove();        
        }

        var dist = Vector3.Distance(this.transform.position, dest.position);

        //�ړ����������ύX���ăI�t�ɂ���
        if (dist < 0.1)
        {
            dest = (dest == end) ? strat : end;
            on = false;
        }

    }

    //�ړ�����
    private void UpdateMove()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,
                dest.position, speed * Time.deltaTime);
    }

}
