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
        //�i�ޕ����ƌ����Ă����
        if (Input.GetKey("d") && Input.GetKey("a"))
        {
            playerDirectionSpeedX = 0;
        }
        else if (Input.GetKey("a") || Input.GetKey("left")) //������
        {
            playerController.playerDirection = false;

            playerDirectionSpeedX = Input.GetAxis("Horizontal");
        }
        else if (Input.GetKey("d") || Input.GetKey("right")) //�E����
        {
            playerController.playerDirection = true;

            playerDirectionSpeedX = Input.GetAxis("Horizontal");
        }
        else { playerDirectionSpeedX = 0; }
    }

    //�v���C���[�W�����v
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
