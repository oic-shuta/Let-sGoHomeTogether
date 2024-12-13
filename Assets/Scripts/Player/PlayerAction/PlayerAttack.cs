using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [Header("�A�j���[�V����")]
    private Animator anim;

    private string aniMotion = "ani_Light";

    private string otoutoMotion = "otouto_Attack";

    private PlayerController playerController;

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

    [Tooltip("�N�[���^�C��")]
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

    //�v���C���[�̍U��
    private void AttackPlayer()
    {
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
            Timer = 0;
        }
        else if (Input.GetKeyDown("e") && !attackPlayer &&
            !playerController.playerDekatuyo && playerController.playerAttackType == 1)
        {
            attackPlayer = true;
            attackTimer = 0;
            Timer = 0;
        }

        //�R���g���[��
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
