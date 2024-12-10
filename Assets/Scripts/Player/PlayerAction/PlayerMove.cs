using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private PlayerKnockback knockback;

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
        anim = GetComponent<Animator>();

        knockback = GetComponent<PlayerKnockback>();

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

        if (!knockback.knockBack)
        {
            //�i�ޕ����ƌ����Ă����
            if (Input.GetKey("d") && Input.GetKey("a"))
            {
                AnimaEnd();
                playerDirectionSpeedX = 0;
            }
            else if (Input.GetKey("a") || joystickLeft) //������
            {
                Animation();

                playerController.playerDirection = false;

                playerDirectionSpeedX = -1;
            }
            else if (Input.GetKey("d") || joystickRight) //�E����
            {
                Animation();

                playerController.playerDirection = true;

                playerDirectionSpeedX = 1;
            }
            else
            {
                AnimaEnd();
                playerDirectionSpeedX = 0;
            }
        }
        else if (knockback.knockBack)
        {
            knockback.KnockBackMove();

            playerDirectionSpeedX += knockback.backPos;
        }

    }

    //�v���C���[�W�����v
    public void JumpPlayer()
    {
        
        if (Input.GetKeyDown("w") && playerController.isOnGround ||
            Input.GetKeyDown("joystick button 0") && playerController.isOnGround)
        {
            this.rig2D.AddForce(transform.up * playerController.playerJumpForce);
            playerController.isOnGround = false;
        }
    }

    private void Animation()
    {
        if (playerController.playerDekatuyo)
        {
            anim.SetBool("otouto_Walk", true);
        }
        else if (!playerController.playerDekatuyo)
        {
            anim.SetBool("ani_Walk", true);
        }
    }

    private void AnimaEnd()
    {
        anim.SetBool("otouto_Walk", false);
        anim.SetBool("ani_Walk", false);
    }
}
