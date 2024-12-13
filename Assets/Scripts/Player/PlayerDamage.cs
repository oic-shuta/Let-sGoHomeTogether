using EffekseerTool.Data;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private Animator damageAnim;

    [SerializeField]
    private string motionName;

    [SerializeField]
    private PlayerKnockback knokBack;

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameContoller gameContoller;

    [Tooltip("�G�ɓ������Ă邩")]
    [SerializeField]
    public bool enemyHit = false;

    [Tooltip("���G���")]
    [SerializeField]
    public bool playerInvincible = false;

    [Tooltip("���G������")]
    [SerializeField]
    private float invincibleStartTime = 0;

    [Tooltip("���G�I���^�C��")]
    [SerializeField]
    private float invincibleEndTime = 0;

    [Tooltip("���G���̓_��")]
    [SerializeField]
    public bool playerBlink = false;

    [SerializeField]
    private float blinkTimeStart = 0;

    [Tooltip("�_�ŊԊu")]
    [SerializeField]
    private float blinkTimeEnd = 0;

    //�v���C���[�̃C���X�g
    [SerializeField]
    private GameObject playerSprite;

    //�_���[�W�󂯂����̃J���[�ƃA���t�@�l
    [SerializeField]
    private Color blinkColor = new Color(0.2f, 0.2f, 0.2f, 0.7f);

    [SerializeField]
    private Color playerColor = new Color(1, 1, 1, 1);

    private void Start()
    {
        //playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        InvincibleTime();

        FallPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�G�Ƃ̐ڐG����
        if (collision.CompareTag("Enemy") && !enemyHit)
        {
            enemyHit = true;

            playerInvincible = true;

            damageAnim.SetTrigger(motionName);
        }
    }

    //���G����
    private void InvincibleTime()
    {
        if (enemyHit)
        {
            Damage();
            //���G����
            invincibleStartTime += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleStartTime > invincibleEndTime) //���G���ԏI��
            {
                enemyHit = false;
                playerBlink = false;
                invincibleStartTime = 0;
                playerInvincible = false;
            }

            if(blinkTimeStart > blinkTimeEnd)//�_�ŊԊu
            {
                blinkTimeStart = 0;
                
                playerBlink = !playerBlink;
            }
            PlayerBlink();�@
        }
    }
    
    //���C�t����
    private void Damage()
    {
        if (enemyHit && invincibleStartTime <= 0)
        {
            gameContoller.playerLife--;
        }
    }

    //�_�ł���
    private void PlayerBlink()
    {
        if (playerBlink)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = blinkColor;
        }
        else if (!playerBlink)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = playerColor;
        }
    }

    private void FallPlayer()
    {
        if (playerController.fallOut)
        {
            gameContoller.PlayerFallOut();

            playerController.fallOut = false;
        }
    }
}
