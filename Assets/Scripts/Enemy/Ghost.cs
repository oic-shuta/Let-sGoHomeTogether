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
            //�v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
            if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            {
                return;
            }

            //Player�Ɍ������Ĉړ�����
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(playerTr.position.x, playerTr.position.y),
                speed * Time.deltaTime);
        }
        
        if(isover == true)
        {
            anim.SetBool("down",true);
            Stop();
            Destroy(gameObject);
        }
    }

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ڐG�����I�u�W�F�N�g��tag����WeaponLight�̏ꍇ��
        if (collision.gameObject.tag == "WeaponLight")
        {
            // Ghost�I�u�W�F�N�g����������
            isover = true;
        }
    }
}
