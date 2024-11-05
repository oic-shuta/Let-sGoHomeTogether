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

    [SerializeField]
    private GameObject playerSprite;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        InvincibleTime();
    }

    //���C�t��0�ɂȂ����玀��
    public void PlayerDead()
    {
        Debug.Log("����");
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
            if (invincibleStartTime > invincibleEndTime)
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
            PlayerBlink();
        }
    }
    
    private void Damage()
    {
        if (playerController.enemyHit && invincibleStartTime == 0)
        {
            gameContoller.playerLife--;
        }

        if(gameContoller.playerLife <= 0)
        {
            PlayerDead();
        }
    }

    private void PlayerBlink()
    {
        if (playerBlink)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = Color.black ;
        }
        else if (!playerBlink)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
