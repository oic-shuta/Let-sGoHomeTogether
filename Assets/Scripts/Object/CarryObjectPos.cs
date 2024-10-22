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

    //���������̃I�u�W�F�N�g�̈ʒu
    [Tooltip("�v���C���[�������Ă�Ƃ��̃I�u�W�F�N�g�̈ʒu(�v���C���[���)")]
    [SerializeField]
    private Vector3 carrPos = Vector3.zero;

    //�v���C���[�������グ�����̍���(�v���C���[�̈ʒu������������)
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

    //���������ɃI�u�W�F�N�g�𕂂�����
    private void CarryObjectPos()
    {
        //�v���C���[�������Ă��鎞
        if (playerCarry.carryObject)
        {
            rig2D.bodyType = RigidbodyType2D.Static;�@�@//�������Ȃ��^�C�ɕύX
            this.gameObject.layer = 6;                  
            //�E�������Ă�Ƃ��Ƀv���C���[�̉E�ɍs��
            if (playerController.playerDirection)               
            {
                gameObject.transform.position = new Vector3
                    (x + playerObject.transform.position.x, (carrPos.y + carryObjectY) + playerObject.transform.position.y, carrPos.z);
            }
            //���������Ă�Ƃ��Ƀv���C���[�̍��ɍs��
            else if (!playerController.playerDirection)
            {
                gameObject.transform.position = new Vector3
                    (-x + playerObject.transform.position.x, (carrPos.y + carryObjectY) + playerObject.transform.position.y, carrPos.z);
            }
        }
        //�v���C���[���I�u�W�F�N�g�𗣂����Ƃ�
        else if (!playerCarry.carryObject)
        {
            rig2D.bodyType = RigidbodyType2D.Dynamic;�@  //��������^�C�v�ɕύX

            this.gameObject.layer = 7;
        }
    }
}
