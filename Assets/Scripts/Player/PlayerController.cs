using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerType
{
    NULL = -1,
    Dekatsuyo,
    Chibiyowa,
}
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rig2D = null;

    [SerializeField]
    private PlayerMove playerMove = null;

    [SerializeField]
    private PlayerAttack playerAttack = null;

    [SerializeField]
    private PlayerCarryObject playerCarry = null;


    //���݂̑���L����
    [Header("�v���C���[���")]
    [Tooltip("����L�����̐؂�ւ�")]
    [SerializeField]
    public PlayerType moveType = PlayerType.NULL;

    [Tooltip("�v���C���[�̃��C�t")]
    [SerializeField]
    public int Life = 0;

    //�v���C���[�̑��x
    [Tooltip("�ړ����x")]
    [SerializeField]
    public float playerSpeed = 0;

    //�v���C���[�̃W�����v��
    [Tooltip("�W�����v��")]
    [SerializeField]
    public float playerJumpForce = 0;

    //�v���C���[�W�����v���̌���
    [Tooltip("�W�����v���̌�����")]
    [SerializeField]
    private float playerJumpSpeed = 0.4f;

    [SerializeField]
    private float playerCarryJump = 0.5f;

    [Tooltip("�v���C���[�̌����Ă������")]
    [SerializeField]
    public bool playerDirection = true;

    //�؂�ւ����̌����Ă������
    [SerializeField]
    private bool changeDirection = true;

    //�ǂ̃L�������������t���O
    [Tooltip("�ǂ̃L�����𑀍삵�Ă邩")]
    public bool playerChange = true;

    //�ǂ̃L�������U�����邩
    [Tooltip("�ǂ̃^�C�v�̍U�������邩�F0 = �ł���@1 = ���т��")]
    public int playerAttackType = -1;

    //�v���C���[���n�ʂɂ��邩�t���O
    [Tooltip("�n�ʂɂ��邩�ǂ����t���O")]
    [SerializeField]
    public bool isOnGround = false;

    private void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();

        playerMove = GetComponent<PlayerMove>(); 

        playerAttack = GetComponent<PlayerAttack>();

        playerCarry = GetComponent<PlayerCarryObject>();
    }

    private void Update()
    {

        playerMove.MovePlayer();

        playerMove.JumpPlayer();

        playerAttack.AttackPlayer();

        ChangePlayer();

        TimeStop();
    }

    private void TimeStop()
    {
        if (Input.GetKeyDown("0"))
        {
            Debug.Log("stop");
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("9"))
        {
            Debug.Log("restrat");
            Time.timeScale = 1;
        }
    }

    //�v���C���[�؂�ւ�
    public void ChangePlayer()
    {
        if (Input.GetKeyDown("q") || Input.GetKeyDown("joystick button 3"))
        {
            changeDirection = playerDirection;
            playerChange = !playerChange;
        }
    }

    //�L�������Ƃ̓���
    public void PlayerMoveType()
    {
        //�ł���̃X�e�[�^�X
        if (moveType == PlayerType.Dekatsuyo && playerChange == true)
        {
            playerSpeed = 5;
            playerJumpForce = 1200;
            playerAttackType = 0;
            if(playerCarry.carryObject == true)
            {
                playerJumpForce *= playerCarryJump;
            }
        }
        //���т��̃X�e�[�^�X
        else if (moveType == PlayerType.Chibiyowa && playerChange == false)
        {
            playerSpeed = 5;
            playerJumpForce = 300;
            playerAttackType = 1;
        }
        else //����L�����ȊO�͓����Ȃ��悤�ɂ���
        {
            playerSpeed = 0;
            playerJumpForce = 0;
            isOnGround = true;
            playerAttackType = -1;
            playerDirection = changeDirection;
        }

        //�����Ă�����ɍU��
        if (!playerDirection)//������
        {
            playerAttack.attackPlayerJudgmentLeft.SetActive(playerAttack.attackPlayer);
            playerAttack.attackPlayerJudgmentRight.SetActive(false);
        }
        else if (playerDirection)//�E����
        {
            playerAttack.attackPlayerJudgmentRight.SetActive(playerAttack.attackPlayer);
            playerAttack.attackPlayerJudgmentLeft.SetActive(false);
        }

        //�W�����v���̈ړ����x�ቺ
        if (!isOnGround)
        {
            playerSpeed -= playerSpeed * playerJumpSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�n�ʔ���
        if (collision.CompareTag("Ground"))
        {
            isOnGround = true;      //�n�ʂɂ���
        }
    }
}