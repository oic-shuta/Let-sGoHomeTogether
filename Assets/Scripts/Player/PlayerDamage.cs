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

    [Tooltip("敵に当たってるか")]
    [SerializeField]
    public bool enemyHit = false;

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

    //プレイヤーのイラスト
    [SerializeField]
    private GameObject playerSprite;

    //ダメージ受けた時のカラーとアルファ値
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
        //敵との接触判定
        if (collision.CompareTag("Enemy") && !enemyHit)
        {
            enemyHit = true;

            playerInvincible = true;

            damageAnim.SetTrigger(motionName);
        }
    }

    //無敵時間
    private void InvincibleTime()
    {
        if (enemyHit)
        {
            Damage();
            //無敵時間
            invincibleStartTime += 1 * Time.deltaTime;
            blinkTimeStart += 1 * Time.deltaTime;
            if (invincibleStartTime > invincibleEndTime) //無敵時間終了
            {
                enemyHit = false;
                playerBlink = false;
                invincibleStartTime = 0;
                playerInvincible = false;
            }

            if(blinkTimeStart > blinkTimeEnd)//点滅間隔
            {
                blinkTimeStart = 0;
                
                playerBlink = !playerBlink;
            }
            PlayerBlink();　
        }
    }
    
    //ライフ減少
    private void Damage()
    {
        if (enemyHit && invincibleStartTime <= 0)
        {
            gameContoller.playerLife--;
        }
    }

    //点滅する
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
