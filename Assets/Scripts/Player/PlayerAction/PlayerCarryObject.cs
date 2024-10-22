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
            //�I�u�W�F�N�g�̑O�ɓ����蔻����o��������
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
