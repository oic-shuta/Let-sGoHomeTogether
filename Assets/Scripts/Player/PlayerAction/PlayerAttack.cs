using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [Header("アニメーション")]
    private Animator anim;

    private string aniMotion = "ani_Light";

    private string otoutoMotion = "otouto_Attack";

    private PlayerController playerController;

    private PlayerCarryObject carry;

    [Header("プレイヤーの攻撃")]
    //攻撃判定
    [Tooltip("攻撃当たり判定範囲　右")]
    [SerializeField]
    public GameObject attackPlayerJudgmentRight;

    [Tooltip("攻撃当たり判定範囲　左")]
    [SerializeField]
    public GameObject attackPlayerJudgmentLeft;

    //攻撃タイマー
    [Tooltip("攻撃している時間")]
    [SerializeField]
    private float attackingTime = 0;

    private float attackTimer = 0;

    //攻撃してるかフラグ
    [Tooltip("現在攻撃しているか")]
    [SerializeField]
    public bool attackPlayer = false;

    [Tooltip("クールタイム")]
    [SerializeField]
    private float Timer;

    [SerializeField]
    private float endTime;

    [SerializeField]
    private int Count;

    private void Start()
    {
        anim = GetComponent<Animator>();

        playerController = GetComponent<PlayerController>();

        carry = GetComponent<PlayerCarryObject>();

        attackPlayerJudgmentRight.SetActive(false);

        attackPlayerJudgmentLeft.SetActive(false);
    }

    private void Update()
    {
        AttackTime();
    }

    //プレイヤーの攻撃
    private void AttackPlayer()
    {
        Attack();

        attackTimer += Time.deltaTime;

        //攻撃判定の時間
        if (attackingTime < attackTimer && attackPlayer )
        {
            attackPlayer = false;
        }
    }

    private void Attack()
    {

        //キーボード
        if (Input.GetKeyDown("e") && !attackPlayer && !carry.onCarry &&
            playerController.playerDekatuyo && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
            Timer = 0;
        }
        else if (Input.GetKeyDown("e") && !attackPlayer &&
            !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
            Timer = 0;
        }

        //コントローラ
        if (Input.GetKeyDown("joystick button 5") && !attackPlayer && !carry.onCarry &&
            playerController.playerDekatuyo && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
            Timer = 0;
        }
        else if(Input.GetKeyDown("joystick button 5") && !attackPlayer &&
                 !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
            Timer = 0;
        }
        Animation();
    }
    private void Animation()
    {
        if (playerController.playerDekatuyo)
        {
            DekatuyoAnimaSet();
        }
        else if (!playerController.playerDekatuyo)
        {
            ChibiyowaAnimaSet();
        }
    }

    private void DekatuyoAnimaSet()
    {
        if (attackPlayer && Count < 1)
        {
            anim.SetTrigger(otoutoMotion);
            Count++;
        }
    }

    private void ChibiyowaAnimaSet()
    {
        if (attackPlayer && Count<1)
        {
            anim.SetTrigger(aniMotion);
            Count++;
        }
    }
    private void AttackTime()
    {
        Timer += Time.deltaTime;
        if(Timer > endTime)
        {
            Count = 0;
            AttackPlayer();
        }
    }
}
