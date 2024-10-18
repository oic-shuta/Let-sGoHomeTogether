using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [Header("�v���C���[�̍U��")]
    //�U������
    [Tooltip("�U�������蔻��͈́@�E")]
    [SerializeField]
    public GameObject attackPlayerJudgmentRight;

    [Tooltip("�U�������蔻��͈́@��")]
    [SerializeField]
    public GameObject attackPlayerJudgmentLeft;

    //�U���^�C�}�[
    [Tooltip("�U�����Ă��鎞��")]
    [SerializeField]
    private float attackingTime = 0;

    private float attackTimer = 0;

    //�U�����Ă邩�t���O
    [Tooltip("���ݍU�����Ă��邩")]
    [SerializeField]
    public bool attackPlayer = false;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        attackPlayerJudgmentRight.SetActive(false);

        attackPlayerJudgmentLeft.SetActive(false);
    }

    //�v���C���[�̍U��
    public void AttackPlayer()
    {
        playerController.PlayerMoveType();

//        if (Input.GetKeyDown("e") && attackPlayer == false && moveType == PlayerType.Chibiyowa && playerChange == true)
        if (Input.GetKeyDown("e") && attackPlayer == false &&
            playerController.playerChange == true && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
        }
//        else if (Input.GetKeyDown("e") && attackPlayer == false && moveType == PlayerType.Dekatsuyo && playerChange == false)
        else if (Input.GetKeyDown("e") && attackPlayer == false && 
            playerController.playerChange == false && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
        }

        attackTimer += Time.deltaTime;

        //�U������̎���
        if (attackingTime < attackTimer && attackPlayer == true)
        {
            attackPlayer = false;
        }
    }
}
