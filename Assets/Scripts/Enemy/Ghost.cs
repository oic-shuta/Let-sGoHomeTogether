using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Transform playerTr;
    [SerializeField] float speed = 2f;
    Rigidbody2D rbody2D;
    CircleCollider2D circleCollider2D;

    private bool isover;
    private Animator anim = null;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        circleCollider2D = GetComponent<CircleCollider2D>();
        isover = false;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (circleCollider2D.bounds.Contains(playerTr.position))
        {
            //プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
            if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            {
                return;
            }

            //Playerに向かって移動する
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }
        
        if(isover == true)
        {
            StartCoroutine("Stop");
        }
    }

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 接触したオブジェクトのtag名がWeaponLightの場合は
        if (collision.gameObject.tag == "WaeponLight")
        {
            anim.SetBool("down", true);
            // Ghostオブジェクトを消去する
            isover = true;
        }
    }
}
