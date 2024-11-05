using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private Rigidbody2D rig2D;

    [Tooltip("�����Ă����")]
    [SerializeField]
    public float playerDirectionSpeedX = 0;

    [SerializeField]
    private bool joystickLeft = false;

    [SerializeField]
    private bool joystickRight = false;

    [SerializeField]
    private float deadZone = 0;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        rig2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
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
        //�X�e�B�b�N�̉E�܂��͍��ɓ|��Ă邩
        float x = Input.GetAxis("Horizontal");
        if(x < -deadZone)
        {
            joystickLeft = true;
            joystickRight = false;
        }
        else if(x > deadZone)
        {
             joystickRight= true;
             joystickLeft = false;
        }
        else
        {
            joystickLeft= false;
            joystickRight = false;
        }


        //�i�ޕ����ƌ����Ă����
        if (Input.GetKey("d") && Input.GetKey("a") )
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
            this.rig2D.AddForce(transform.up * playerController.playerJumpForce);
            playerController.isOnGround = false;
        }
    }
}
