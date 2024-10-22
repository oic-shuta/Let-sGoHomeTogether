using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    private Rigidbody2D rigidBody2D;

    [Tooltip("向いてる方向")]
    [SerializeField]
    public float playerDirectionSpeedX = 0;

    [Tooltip("コントローラスティックを左に倒してる")]
    [SerializeField]
    private bool joystickLeft = false;

    [Tooltip("コントローラスティックを右に倒してる")]
    [SerializeField]
    private bool joystickRight = false;

    [SerializeField]
    private float stickDeadZone = 0.0f;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        rigidBody2D = GetComponent<Rigidbody2D>();
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
        //コントローラでの移動処理
        float x = Input.GetAxis("Horizontal");
        if (x > stickDeadZone)
        {
            joystickRight = true;
            joystickLeft = false;
            Debug.Log(x);
            Debug.Log("右");
        }
        else if (x < -stickDeadZone)
        {
            joystickLeft = true;
            joystickRight = false;
            Debug.Log(x);
            Debug.Log("左");
        }
        else
        {
            joystickRight= false;
            joystickLeft= false;
        }

        //進む方向と向いてる方向
        if (Input.GetKey("d") && Input.GetKey("a"))
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
            this.rigidBody2D.AddForce(transform.up * playerController.playerJumpForce);
            playerController.isOnGround = false;
        }
    }
}
