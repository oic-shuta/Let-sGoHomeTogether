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

    //�I�u�W�F�N�g���^��ł��Ԃ�
    [Tooltip("�I�u�W�F�N�g���^��ł���")]
    [SerializeField]
    public  bool carryObject = false;

    [Tooltip("�I�u�W�F�N�g�ɐG��Ă���")]
    [SerializeField]
    private bool playerObjectConTach = false;

    //�G��Ă���I�u�W�F�N�g
    [Tooltip("�G���Ă���I�u�W�F�N�g")]
    [SerializeField]
    private GameObject playerCarryObject = null;

    //�I�u�W�F�N�g�����������ɍ��E�����蔻���t����
    [SerializeField]
    private GameObject carryColliderLeft = null;
    
    [SerializeField]
    private GameObject carryColliderRight = null;


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
            if (collision.CompareTag("CarryObject"))        //����I�u�W�F�N�g�ɐG������
            {
                playerObjectConTach = true;
                playerCarryObject = collision.gameObject;   //�G�����I�u�W�F�N�g
            }
            else if (collision.CompareTag("CarryOutObject") ) //����I�u�W�F�N�g���痣�ꂽ
            {
                playerObjectConTach = false;
                playerCarryObject = null;                   //�G�ꂽ�I�u�W�F�N�g��������
            }
        }
        
    }

    private void CarryObject()
    {
        if (playerController.playerChange == false)     //���т�푀��̎��I�u�W�F�N�g�����ĂȂ�
        {
            return;
        }
        else if (Input.GetKeyDown("space") && !carryObject && playerController.isOnGround && playerObjectConTach
            || Input.GetKeyDown("joystick button 2") && !carryObject && playerController.isOnGround && playerObjectConTach)
        {
            Debug.Log("������");
            playerCarryObject.transform.parent = this.gameObject.transform;       //�I�u�W�F�N�g�̐e���v���C���[�Ɉڂ�
            carryObject = true;
        }
        else if (Input.GetKeyDown("space") && carryObject
            || Input.GetKeyDown("joystick button 2") && carryObject)
        {
            playerCarryObject.transform.parent = null;           //�I�u�W�F�N�g�̐e�����ɖ߂�
            carryObject = false;
            Debug.Log("������");
        }
    }
    //�I�u�W�F�N�g���v���C���[�̐��ʂɗ�������w��
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

    //���������ɃI�u�W�F�N�g�𕂂�����
    private void CarryObjectPos()
    {
        //�v���C���[�������Ă��鎞
        if (carryObject)
        {
            Debug.Log("i");
            rig2D.bodyType = RigidbodyType2D.Static;�@�@//�������Ȃ��^�C�v�ɕύX
            this.gameObject.layer = 6;
            //�E�������Ă�Ƃ��Ƀv���C���[�̉E�ɍs��
            if (playerController.playerDirection)
            {
                Debug.Log("u");
                gameObject.transform.position = new Vector3
                    (x * transform.position.x, (carrPos.y + carryObjectY) + transform.position.y, carrPos.z);
            }
            //���������Ă�Ƃ��Ƀv���C���[�̍��ɍs��
            else if (!playerController.playerDirection)
            {
                gameObject.transform.position = new Vector3
                    (-x * transform.position.x, (carrPos.y + carryObjectY) + transform.position.y, carrPos.z);
            }
        }
        //�v���C���[���I�u�W�F�N�g�𗣂����Ƃ�
        else if (!carryObject)
        {
            rig2D.bodyType = RigidbodyType2D.Dynamic;�@  //��������^�C�v�ɕύX

            this.gameObject.layer = 7;
        }
    }

}
