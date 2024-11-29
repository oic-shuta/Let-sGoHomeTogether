using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CircleCollider2D circleCollider;
    Rigidbody2D rbody2D;             // Rigidbody2Dを定義
    float speed = 3f;                // 移動速度を格納する変数
    Transform playerTr;
    
    Collider2D col;
    private Animator anim = null;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        col = GetComponent<CapsuleCollider2D>();
        circleCollider = col.GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("run", false);

        if(circleCollider.bounds.Contains(playerTr.position))
        {
            // 追ってくる処理をここで書く
            Vector2 scale = transform.localScale;

            //プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
            if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            {
                return;
            }

            if (playerTr.position.x > scale.x)
            {
                scale.x = 1; // 右向き
                speed = 3;
            }
            else if (playerTr.position.x < scale.x)
            {
                scale.x = -1; // 左向き
                speed = -3;
            }


            transform.localScale = scale;
            rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);
        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触したオブジェクトのtag名がWeaponAttackの場合は
        if (collision.gameObject.tag == "WeaponAttack")
        {
            // Wolfオブジェクトを消去する
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("run", true);
        }
    }

}
