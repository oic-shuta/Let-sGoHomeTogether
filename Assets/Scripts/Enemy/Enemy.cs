using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rbody2D;             // Rigidbody2Dを定義
    float speed = 3f;                // 移動速度を格納する変数
    Transform playerTr;
    

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        //プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
        {
            return;
        }

        if (playerTr.position.x >  scale.x)
        {
            scale.x = 1; // 右向き
            speed = 3;
        }else if(playerTr.position.x < scale.x)
        {
            scale.x = -1; // 左向き
            speed = -3;
        }


        transform.localScale = scale;
        rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触したオブジェクトのtag名がWeaponAttackの場合は
        if (collision.gameObject.tag == "WeaponAttack")
        {
            // Wolfオブジェクトを消去する
            Destroy(this.gameObject);
        }
    }

}
