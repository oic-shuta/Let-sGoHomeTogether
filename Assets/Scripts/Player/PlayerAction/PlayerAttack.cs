using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effekseer;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private EffekseerEmitter emitter;

    [SerializeField]
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

        attackPlayerJudgmentRight.SetActive(false);

        attackPlayerJudgmentLeft.SetActive(false);
    }

    //プレイヤーの攻撃
    public void AttackPlayer()
    {
        playerController.PlayerMoveType();

        Attack();

        attackTimer += Time.deltaTime;

        //攻撃判定の時間
        if (attackingTime < attackTimer && attackPlayer )
        {
            attackPlayer = false;
            Animation();
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
            emitter.Play();
            Animation();
        }
        else if (Input.GetKeyDown("e") && !attackPlayer &&
            !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
            Animation();
        }

        //コントローラ
        if (Input.GetKeyDown("joystick button 5") && !attackPlayer && !carry.onCarry &&
            playerController.playerDekatuyo && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
            emitter.Play();
            Animation();
        }
        else if(Input.GetKeyDown("joystick button 5") && !attackPlayer &&
                 !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
            Animation();
        }
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
            anim.SetBool("otouto_Attack", true);
        }
        else if (!attackPlayer)
        {
            anim.SetBool("otouto_Attack", false);
        }
    }

    private void ChibiyowaAnimaSet()
    {
        if (attackPlayer)
        {
            anim.SetBool("ani_Light", true);
        }
        else if (!attackPlayer)
        {
            anim.SetBool("ani_Light", false);
        }
    }
}
