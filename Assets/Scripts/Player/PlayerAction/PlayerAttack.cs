using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

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
        playerController = GetComponent<PlayerController>();

        attackPlayerJudgmentRight.SetActive(false);

        attackPlayerJudgmentLeft.SetActive(false);
    }

    //プレイヤーの攻撃
    public void AttackPlayer()
    {
        playerController.PlayerMoveType();

        if (Input.GetKeyDown("e") && attackPlayer == false &&
            playerController.playerChange == true && playerController.playerAttackType == 0
            || Input.GetKeyDown("joystick button 5") && attackPlayer == false &&
            playerController.playerChange == true && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
        }
        else if (Input.GetKeyDown("e") && attackPlayer == false && 
            playerController.playerChange == false && playerController.playerAttackType == 1
            || Input.GetKeyDown("joystick button 5") && attackPlayer == false &&
            playerController.playerChange == false && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
        }

        attackTimer += Time.deltaTime;

        //攻撃判定の時間
        if (attackingTime < attackTimer && attackPlayer == true)
        {
            attackPlayer = false;
        }
    }
}
