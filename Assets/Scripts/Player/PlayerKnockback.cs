using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField]
    private PlayerDamage damage;

    private PlayerAttack attack;

    private Transform enemyPos = null;

    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    public bool knockBack = false;

    [SerializeField]
    public float backPos;

    [SerializeField]
    private float Timer;

    [SerializeField]
    private float TimerStart = 0;

    [SerializeField]
    public bool Invincible;

    private void Start()
    {

        attack = GetComponent<PlayerAttack>();

        playerPos = this.gameObject.transform;

    }
    private void Update()
    {
        Invincible = damage.playerInvincible;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&& !Invincible)
        {
            enemyPos = collision.transform;

            TimerStart = 0;
        }
    }
    public void KnockBackMove()
    {
        if (knockBack)
        {
            if (enemyPos.position.x < playerPos.position.x)
            {
                backPos = 0.3f;
            }
            else if (enemyPos.position.x > playerPos.position.x)
            {
                backPos = -0.3f;
            }
            KnockBackTime();
        }
    }

    private void KnockBackTime()
    {
        TimerStart += Time.deltaTime;
       if (Timer < TimerStart)
       {
            knockBack = false;

            enemyPos = null;
       }
       
    }
}
