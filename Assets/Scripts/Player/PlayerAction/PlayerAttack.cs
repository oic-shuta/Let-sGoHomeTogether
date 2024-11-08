using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effekseer;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private EffekseerEmitter emitter;

    [SerializeField]
    private PlayerController playerController;

    [Header("ƒvƒŒƒCƒ„[‚ÌUŒ‚")]
    //UŒ‚”»’è
    [Tooltip("UŒ‚“–‚½‚è”»’è”ÍˆÍ@‰E")]
    [SerializeField]
    public GameObject attackPlayerJudgmentRight;

    [Tooltip("UŒ‚“–‚½‚è”»’è”ÍˆÍ@¶")]
    [SerializeField]
    public GameObject attackPlayerJudgmentLeft;

    //UŒ‚ƒ^ƒCƒ}[
    [Tooltip("UŒ‚‚µ‚Ä‚¢‚éŠÔ")]
    [SerializeField]
    private float attackingTime = 0;

    private float attackTimer = 0;

    //UŒ‚‚µ‚Ä‚é‚©ƒtƒ‰ƒO
    [Tooltip("Œ»İUŒ‚‚µ‚Ä‚¢‚é‚©")]
    [SerializeField]
    public bool attackPlayer = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        attackPlayerJudgmentRight.SetActive(false);

        attackPlayerJudgmentLeft.SetActive(false);
    }

    //ƒvƒŒƒCƒ„[‚ÌUŒ‚
    public void AttackPlayer()
    {
        playerController.PlayerMoveType();

        if (Input.GetKeyDown("e") && attackPlayer == false &&
            playerController.playerDekatuyo == true && playerController.playerAttackType == 0
            || Input.GetKeyDown("joystick button 5") && attackPlayer == false &&
            playerController.playerDekatuyo == true && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
            emitter.Play();
        }
        else if (Input.GetKeyDown("e") && attackPlayer == false && 
            playerController.playerDekatuyo == false && playerController.playerAttackType == 1
            || Input.GetKeyDown("joystick button 5") && attackPlayer == false &&
            playerController.playerDekatuyo == false && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
        }

        attackTimer += Time.deltaTime;

        //UŒ‚”»’è‚ÌŠÔ
        if (attackingTime < attackTimer && attackPlayer == true)
        {
            attackPlayer = false;
        }
    }
}
