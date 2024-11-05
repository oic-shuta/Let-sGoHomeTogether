using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
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

        playerController.PlayerMoveType();

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


        //進む方向と向いてる方向
        if (Input.GetKey("d") && Input.GetKey("a") )
        {
            playerDirectionSpeedX = 0;
        }
        else if (Input.GetKey("a") || joystickLeft) //左方向
        {
            playerController.playerDirection = false;

            playerDirectionSpeedX = -1;
        }
        else if (Input.GetKey("d") || joystickRight) //右方向
        {
            playerController.playerDirection = true;

            playerDirectionSpeedX = 1;
        }
        else { playerDirectionSpeedX = 0; }
    }

    //プレイヤージャンプ
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
