using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Effekseer;

public class Enemy : MonoBehaviour
{
    CircleCollider2D circleCollider;
    Rigidbody2D rbody2D;             // Rigidbody2D���`
    float speed = 3f;                // �ړ����x���i�[����ϐ�
    Transform playerTr;
    
    Collider2D col;
    private Animator anim = null;
    private bool isover;
    private EnemySE EnemySE;
    [SerializeField]
    private EffekseerEmitter effect;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        col = GetComponent<CapsuleCollider2D>();
        circleCollider = col.GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        isover = false;
        EnemySE = GetComponent<EnemySE>();
    }

    // Update is called once per frame
    void Update()
    {

        //anim.SetBool("run", true);

        if(circleCollider.bounds.Contains(playerTr.position))
        {
            //�v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
            if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            {
                return;
            }

            // �ǂ��Ă��鏈��
            Vector2 scale = transform.localScale;

            if (playerTr.position.x > rbody2D.position.x)
            {
                EnemySE.Wolfwalk();
                scale.x = -1; // �E����
                speed = 3;
            }
            else if (playerTr.position.x < rbody2D.position.x)
            {
                EnemySE.Wolfwalk();
                scale.x = 1; // ������
                speed = -3;
            }

            rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);
        }

        if (isover == true)
        {
            effect.Play();
            EnemySE.Wolfdown();
            anim.SetBool("down", true);
            Stop();
            Destroy(gameObject);

        } 

    }

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "WeaponAttack")
        {
            isover = true;   
        }

        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("run", false);
            Stop();
        }
    }



}
