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

    [Tooltip("ñ≥ìGèÛë‘")]
    [SerializeField]
    public bool playerInvincible = false;

    [Tooltip("ñ≥ìGíÜéûä‘")]
    [SerializeField]
    private float invincibleStartTime = 0;

    [Tooltip("ñ≥ìGèIóπÉ^ÉCÉÄ")]
    [SerializeField]
    private float invincibleEndTime = 0;

    [Tooltip("ñ≥ìGéûÇÃì_ñ≈")]
    [SerializeField]
    public bool playerBlink = false;

    [SerializeField]
    private float blinkTimeStart = 0;

    [Tooltip("ì_ñ≈ä‘äu")]
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

    //ÉâÉCÉtÇ™0Ç…Ç»Ç¡ÇΩÇÁéÄÇ 
    public void PlayerDead()
    {
        Debug.Log("éÄÇÒÇæ");
    }

    //ñ≥ìGéûä‘
    private void InvincibleTime()
    {
        if (playerController.enemyHit)
        {
            Damage();
            //ñ≥ìGéûä‘
            invincibleStartTime += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleStartTime > invincibleEndTime)
            {
                playerController.enemyHit = false;
                playerBlink = false;
                invincibleStartTime = 0;
            }

            if(blinkTimeStart > blinkTimeEnd)//ì_ñ≈ä‘äu
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
