using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [Header("アニメーション")]
    private Animator anim;

    [SerializeField]
    private string aniMotion = "ani_Light";

    [SerializeField]
    private string otoutoMotion = "otouto_Attack";

    private PlayerController playerController;

    [SerializeField]
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

    private void Start()
    {
        anim = GetComponent<Animator>();

        playerController = GetComponent<PlayerController>();

        carry = GetComponent<PlayerCarryObject>();

        attackPlayerJudgmentRight.SetActive(false);

        attackPlayerJudgmentLeft.SetActive(false);
    }

    //プレイヤーの攻撃
    public void AttackPlayer()
    {
        Attack();

        attackTimer += Time.deltaTime;

        //攻撃判定の時間
        if (attackingTime < attackTimer && attackPlayer )
        {
            Animation();
            attackPlayer = false;
        }
    }

    private void Attack()
    {

        //キーボード
        if (Input.GetKeyDown("e") && !attackPlayer && !carry.onCarry &&
            playerController.playerDekatuyo && playerController.playerAttackType == 0)
        {
            //Animation();
            attackPlayer = true;
            attackTimer = 0;
        }
        else if (Input.GetKeyDown("e") && !attackPlayer &&
            !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            //Animation();
            attackPlayer = true;
            attackTimer = 0;
        }

        //コントローラ
        if (Input.GetKeyDown("joystick button 5") && !attackPlayer && !carry.onCarry &&
            playerController.playerDekatuyo && playerController.playerAttackType == 0)
        {
            //Animation();
            attackPlayer = true;
            attackTimer = 0;
        }
        else if(Input.GetKeyDown("joystick button 5") && !attackPlayer &&
                 !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
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
        if (attackPlayer)
        {
            anim.SetBool(otoutoMotion, true);
        }
        else if (!attackPlayer)
        {
            anim.SetBool(otoutoMotion, false);
        }
    }

    private void ChibiyowaAnimaSet()
    {
        if (attackPlayer)
        {
            anim.SetBool(aniMotion, true);
        }
        else if (!attackPlayer)
        {
            anim.SetBool(aniMotion, false);
        }
    }
}
