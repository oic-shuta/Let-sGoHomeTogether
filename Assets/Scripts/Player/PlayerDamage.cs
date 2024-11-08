using EffekseerTool.Data;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameContoller gameContoller;

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
    private Color damageColor = new Color(0.2f, 0.2f, 0.2f, 0.7f);

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        InvincibleTime();
    }

    //���G����
    private void InvincibleTime()
    {
        if (playerController.enemyHit)
        {
            Damage();
            //���G����
            invincibleStartTime += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleStartTime > invincibleEndTime) //���G���ԏI��
            {
                playerController.enemyHit = false;
                playerBlink = false;
                invincibleStartTime = 0;
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
        if (playerController.enemyHit && invincibleStartTime <= 0)
        {
            gameContoller.playerLife--;
        }
    }

    //�_�ł���
    private void PlayerBlink()
    {
        if (playerBlink)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = damageColor;
        }
        else if (!playerBlink)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
