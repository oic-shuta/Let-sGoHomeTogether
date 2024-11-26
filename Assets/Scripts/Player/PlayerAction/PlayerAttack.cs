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
        anim = GetComponent<Animator>();

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
            Animation();
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
            Animation();
        }
        else if (Input.GetKeyDown("e") && !attackPlayer &&
            !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
            Animation();
        }

        //�R���g���[��
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
