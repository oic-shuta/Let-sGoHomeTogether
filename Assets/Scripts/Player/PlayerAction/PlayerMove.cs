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
        //進む方向と向いてる方向
        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            playerDirectionSpeedX = 0;
        }
        else if (Input.GetKey("a") || Input.GetKey("left")) //左方向
        {
            playerController.playerDirection = false;

            playerDirectionSpeedX = Input.GetAxis("Horizontal");
        }
        else if (Input.GetKey("d") || Input.GetKey("right")) //右方向
        {
            playerController.playerDirection = true;

            playerDirectionSpeedX = Input.GetAxis("Horizontal");
        }
        else { playerDirectionSpeedX = 0; }
    }

    //プレイヤージャンプ
    public void JumpPlayer()
    {
        playerController.PlayerMoveType();
        if (Input.GetKeyDown("w") && playerController.isOnGround ||
                Input.GetKeyDown("up") && playerController.isOnGround)
        {
            this.rigidBody2D.AddForce(transform.up * playerController.playerJumpForce);
            playerController.isOnGround = false;
        }
    }
}
