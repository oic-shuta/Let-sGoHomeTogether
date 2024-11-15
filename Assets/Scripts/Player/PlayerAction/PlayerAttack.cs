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

    [SerializeField]
    private PlayerCarryObject carry = null;

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

        Attack();

        attackTimer += Time.deltaTime;

        //�U������̎���
        if (attackingTime < attackTimer && attackPlayer )
        {
            attackPlayer = false;
        }
    }

    private void Attack()
    {
        //�L�[�{�[�h
        if (Input.GetKeyDown("e") && !attackPlayer && !carry.onCarry &&
              playerController.playerDekatuyo && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
            emitter.Play();
        }
        else if (Input.GetKeyDown("e") && !attackPlayer &&
            !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;

        }

        //�R���g���[��
        if (Input.GetKeyDown("joystick button 5") && !attackPlayer && !carry.onCarry &&
              playerController.playerDekatuyo && playerController.playerAttackType == 0)
        {
            attackPlayer = true;
            attackTimer = 0;
            emitter.Play();
        }
        else if (Input.GetKeyDown("joystick button 5") && !attackPlayer &&
                     !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
        }
    }
}
