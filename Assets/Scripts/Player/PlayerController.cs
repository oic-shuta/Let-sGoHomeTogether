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


    //現在の操作キャラ
    [Header("プレイヤー情報")]
    [Tooltip("操作キャラの切り替え")]
    [SerializeField]
    public PlayerType moveType = PlayerType.NULL;

    [Tooltip("プレイヤーのライフ")]
    [SerializeField]
    public int Life = 0;

    //プレイヤーの速度
    [Tooltip("移動速度")]
    [SerializeField]
    public float playerSpeed = 0;

    //プレイヤーのジャンプ力
    [Tooltip("ジャンプ力")]
    [SerializeField]
    public float playerJumpForce = 0;

    //プレイヤージャンプ時の減速
    [Tooltip("ジャンプ時の減速量")]
    [SerializeField]
    private float playerJumpSpeed = 0.4f;

    [SerializeField]
    private float playerCarryJump = 0.5f;

    [Tooltip("プレイヤーの向いている方向")]
    [SerializeField]
    public bool playerDirection = true;

    //切り替え時の向いている方向
    [SerializeField]
    private bool changeDirection = true;

    //どのキャラが動くかフラグ
    [Tooltip("どのキャラを操作してるか")]
    public bool playerChange = true;

    //どのキャラが攻撃するか
    [Tooltip("どのタイプの攻撃をするか：0 = でかつよ　1 = ちびよわ")]
    public int playerAttackType = -1;

    //プレイヤーが地面にいるかフラグ
    [Tooltip("地面にいるかどうかフラグ")]
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

    //プレイヤー切り替え
    public void ChangePlayer()
    {
        if (Input.GetKeyDown("q") || Input.GetKeyDown("joystick button 3") )
        {
            changeDirection = playerDirection;
            playerChange = !playerChange;
        }
    }

    //キャラごとの動き
    public void PlayerMoveType()
    {
        //でかつよのステータス
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
        //ちびよわのステータス
        else if (moveType == PlayerType.Chibiyowa && playerChange == false)
        {
            playerSpeed = 5;
            playerJumpForce = 300;
            playerAttackType = 1;
        }
        else //操作キャラ以外は動かないようにする
        {
            playerSpeed = 0;
            playerJumpForce = 0;
            isOnGround = true;
            playerAttackType = -1;
            playerDirection = changeDirection;
        }

        //向いてる方向に攻撃
        if (!playerDirection)//左方向
        {
            playerAttack.attackPlayerJudgmentLeft.SetActive(playerAttack.attackPlayer);
            playerAttack.attackPlayerJudgmentRight.SetActive(false);
        }
        else if (playerDirection)//右方向
        {
            playerAttack.attackPlayerJudgmentRight.SetActive(playerAttack.attackPlayer);
            playerAttack.attackPlayerJudgmentLeft.SetActive(false);
        }

        //ジャンプ時の移動速度低下
        if (!isOnGround)
        {
            playerSpeed -= playerSpeed * playerJumpSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //地面判定
        if (collision.CompareTag("Ground"))
        {
            isOnGround = true;      //地面にいる
        }
    }
}
