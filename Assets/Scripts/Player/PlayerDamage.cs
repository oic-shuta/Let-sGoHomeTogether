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
    private Color damageColor = new Color(0.2f, 0.2f, 0.2f, 0.7f);

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        InvincibleTime();
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
            if (invincibleStartTime > invincibleEndTime) //無敵時間終了
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
    
    //ライフ減少
    private void Damage()
    {
        if (playerController.enemyHit && invincibleStartTime <= 0)
        {
            gameContoller.playerLife--;
        }
    }

    //点滅する
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
