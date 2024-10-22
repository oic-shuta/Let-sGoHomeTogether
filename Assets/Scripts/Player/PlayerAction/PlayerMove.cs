using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private Rigidbody2D rigidBody2D;

    [Tooltip("�����Ă����")]
    [SerializeField]
    public float playerDirectionSpeedX = 0;

    [Tooltip("�R���g���[���X�e�B�b�N�����ɓ|���Ă�")]
    [SerializeField]
    private bool joystickLeft = false;

    [Tooltip("�R���g���[���X�e�B�b�N���E�ɓ|���Ă�")]
    [SerializeField]
    private bool joystickRight = false;

    [SerializeField]
    private float stickDeadZone = 0.0f;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    //�v���C���[�̉��ړ�
    public void MovePlayer()
    {
        PlayerDirection();

        playerController.PlayerMoveType();

        Vector3 movePos = new Vector3(playerDirectionSpeedX, 0, 0) * playerController.playerSpeed * Time.deltaTime;
        this.transform.position += movePos;

    }

    //�����Ă�����w��
    public void PlayerDirection()
    {
        //�R���g���[���ł̈ړ�����
        float x = Input.GetAxis("Horizontal");
        if (x > stickDeadZone)
        {
            joystickRight = true;
            joystickLeft = false;
            Debug.Log(x);
            Debug.Log("�E");
        }
        else if (x < -stickDeadZone)
        {
            joystickLeft = true;
            joystickRight = false;
            Debug.Log(x);
            Debug.Log("��");
        }
        else
        {
            joystickRight= false;
            joystickLeft= false;
        }

        //�i�ޕ����ƌ����Ă����
        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            playerDirectionSpeedX = 0;
        }
        else if (Input.GetKey("a") || joystickLeft) //������
        {
            playerController.playerDirection = false;

            playerDirectionSpeedX = -1;
        }
        else if (Input.GetKey("d") || joystickRight) //�E����
        {
            playerController.playerDirection = true;

            playerDirectionSpeedX = 1;
        }
        else { playerDirectionSpeedX = 0; }
    }

    //�v���C���[�W�����v
    public void JumpPlayer()
    {
        playerController.PlayerMoveType();
        if (Input.GetKeyDown("w") && playerController.isOnGround ||
                Input.GetKeyDown("joystick button 0") && playerController.isOnGround)
        {
            this.rigidBody2D.AddForce(transform.up * playerController.playerJumpForce);
            playerController.isOnGround = false;
        }
    }
}
