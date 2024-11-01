using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [Tooltip("無敵状態")]
    [SerializeField]
    private bool playerInvincible = false;

    [Tooltip("無敵中時間")]
    [SerializeField]
    private float invincibleTimeStart = 0;

    [Tooltip("無敵終了タイム")]
    [SerializeField]
    private float invincibleTimerEnd = 0;

    [Tooltip("無敵時の点滅")]
    [SerializeField]
    public bool playerBlink = false;

    [SerializeField]
    private float blinkTimeStart = 0;

    [Tooltip("点滅間隔")]
    [SerializeField]
    private float blinkTimeEnd = 0;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        InvincibleTimer();
    }

    //敵に当たった時ライフを減らす
    //無敵付与
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    //ライフが0になったら死ぬ
    public void PlayerDead()
    {

    }

    //無敵時間
    private void InvincibleTimer()
    {
        if (playerInvincible)   
        {
            //無敵時間
            invincibleTimeStart += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleTimeStart > invincibleTimerEnd)
            {
                playerInvincible = false;
                playerBlink = false;
                invincibleTimeStart = 0;
            }

            if(blinkTimeStart > blinkTimeEnd)//点滅間隔
            {
                blinkTimeStart = 0;
                
                playerBlink = !playerBlink;
            }
            
        }
    }
}
