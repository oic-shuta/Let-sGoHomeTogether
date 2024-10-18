using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [Tooltip("���G���")]
    [SerializeField]
    private bool playerInvincible = false;

    [Tooltip("���G������")]
    [SerializeField]
    private float invincibleTimeStart = 0;

    [Tooltip("���G�I���^�C��")]
    [SerializeField]
    private float invincibleTimerEnd = 0;

    [Tooltip("���G���̓_��")]
    [SerializeField]
    public bool playerBlink = false;

    [SerializeField]
    private float blinkTimeStart = 0;

    [Tooltip("�_�ŊԊu")]
    [SerializeField]
    private float blinkTimeEnd = 0;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        playerController.Life = 2;
    }

    private void Update()
    {
        InvincibleTimer();
    }

    //�G�ɓ������������C�t�����炷
    //���G�t�^
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && playerInvincible == false)
        {
            playerController.Life--;
            playerInvincible = true;
        }
    }

    //���C�t��0�ɂȂ����玀��
    public void PlayerDead()
    {
        if(playerController.Life <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    //���G����
    private void InvincibleTimer()
    {
        if (playerInvincible)   
        {
            //���G����
            invincibleTimeStart += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleTimeStart > invincibleTimerEnd)
            {
                playerInvincible = false;
                playerBlink = false;
                invincibleTimeStart = 0;
            }

            if(blinkTimeStart > blinkTimeEnd)//�_�ŊԊu
            {
                blinkTimeStart = 0;
                
                playerBlink = !playerBlink;
            }
            
        }
    }
}
