using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Effekseer;

public class Enemy : MonoBehaviour
{
    CircleCollider2D circleCollider;
    Rigidbody2D rbody2D;             // Rigidbody2Dを定義
    float speed = 3f;                // 移動速度を格納する変数
    Transform playerTr;

    Collider2D col;
    private Animator anim = null;
    private bool isover;

    //private EnemySE EnemySE;


    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        col = GetComponent<CapsuleCollider2D>();
        circleCollider = col.GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        isover = false;
        //EnemySE = GetComponent<EnemySE>();
    }

    // Update is called once per frame
    void Update()
    {

        //anim.SetBool("run", true);

        if (circleCollider.bounds.Contains(playerTr.position))
        {
            //プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
            if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            {
                return;
            }

            // 追ってくる処理
            Vector2 scale = transform.localScale;

            if (playerTr.position.x > rbody2D.position.x)
            {
                //EnemySE.Wolfwalk();
                scale.x = -1; // 右向き
                speed = 3;
            }
            else if (playerTr.position.x < rbody2D.position.x)
            {
                //EnemySE.Wolfwalk();
                scale.x = 1; // 左向き
                speed = -3;
            }

            rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);
        }

        if (isover == true)
        {
            StartCoroutine("Timer");
        }

    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WeaponAttack")
        {
            anim.SetBool("down", true);
            isover = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("run", false);
            Timer();
        }
    }
}
