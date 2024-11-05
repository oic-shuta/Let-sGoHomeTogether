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

    [Tooltip("無敵状態")]
    [SerializeField]
    public bool playerInvincible = false;

    [Tooltip("無敵中時間")]
    [SerializeField]
    private float invincibleStartTime = 0;

    [Tooltip("無敵終了タイム")]
    [SerializeField]
    private float invincibleEndTime = 0;

    [Tooltip("無敵時の点滅")]
    [SerializeField]
    public bool playerBlink = false;

    [SerializeField]
    private float blinkTimeStart = 0;

    [Tooltip("点滅間隔")]
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

    //ライフが0になったら死ぬ
    public void PlayerDead()
    {
        Debug.Log("死んだ");
    }

    //無敵時間
    private void InvincibleTime()
    {
        if (playerController.enemyHit)
        {
            Damage();
            //無敵時間
            invincibleStartTime += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleStartTime > invincibleEndTime)
            {
                playerController.enemyHit = false;
                playerBlink = false;
                invincibleStartTime = 0;
            }

            if(blinkTimeStart > blinkTimeEnd)//点滅間隔
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
