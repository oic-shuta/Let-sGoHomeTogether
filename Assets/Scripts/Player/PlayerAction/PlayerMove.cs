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

    [Tooltip("向いてる方向")]
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
    //プレイヤーの横移動
    public void MovePlayer()
    {
        PlayerDirection();

        Vector3 movePos = new Vector3(playerDirectionSpeedX, 0, 0) * playerController.playerSpeed * Time.deltaTime;
        this.transform.position += movePos;

    }

    //向いてる方向指定
    public void PlayerDirection()
    {
        //スティックの右または左に倒れてるか
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
            //進む方向と向いてる方向
            if (Input.GetKey("d") && Input.GetKey("a"))
            {
                AnimaEnd();
                playerDirectionSpeedX = 0;
            }
            else if (Input.GetKey("a") || joystickLeft) //左方向
            {
                Animation();

                playerController.playerDirection = false;

                playerDirectionSpeedX = -1;
            }
            else if (Input.GetKey("d") || joystickRight) //右方向
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

    //プレイヤージャンプ
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
