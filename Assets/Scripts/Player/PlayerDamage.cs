using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [Tooltip("–³“Gó‘Ô")]
    [SerializeField]
    private bool playerInvincible = false;

    [Tooltip("–³“G’†ŠÔ")]
    [SerializeField]
    private float invincibleTimeStart = 0;

    [Tooltip("–³“GI—¹ƒ^ƒCƒ€")]
    [SerializeField]
    private float invincibleTimerEnd = 0;

    [Tooltip("–³“G‚Ì“_–Å")]
    [SerializeField]
    public bool playerBlink = false;

    [SerializeField]
    private float blinkTimeStart = 0;

    [Tooltip("“_–ÅŠÔŠu")]
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

    //“G‚É“–‚½‚Á‚½ƒ‰ƒCƒt‚ğŒ¸‚ç‚·
    //–³“G•t—^
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && playerInvincible == false)
        {
            playerController.Life--;
            playerInvincible = true;
        }
    }

    //ƒ‰ƒCƒt‚ª0‚É‚È‚Á‚½‚ç€‚Ê
    public void PlayerDead()
    {
        if(playerController.Life <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    //–³“GŠÔ
    private void InvincibleTimer()
    {
        if (playerInvincible)   
        {
            //–³“GŠÔ
            invincibleTimeStart += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleTimeStart > invincibleTimerEnd)
            {
                playerInvincible = false;
                playerBlink = false;
                invincibleTimeStart = 0;
            }

            if(blinkTimeStart > blinkTimeEnd)//“_–ÅŠÔŠu
            {
                blinkTimeStart = 0;
                
                playerBlink = !playerBlink;
            }
            
        }
    }
}
