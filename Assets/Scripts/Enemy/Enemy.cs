using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rbody2D;             // Rigidbody2D���`
    float speed = 3f;                // �ړ����x���i�[����ϐ�
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

        //�v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
        {
            return;
        }

        if (playerTr.position.x >  scale.x)
        {
            scale.x = 1; // �E����
            speed = 3;
        }else if(playerTr.position.x < scale.x)
        {
            scale.x = -1; // ������
            speed = -3;
        }


        transform.localScale = scale;
        rbody2D.velocity = new Vector2(speed, rbody2D.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ڐG�����I�u�W�F�N�g��tag����WeaponAttack�̏ꍇ��
        if (collision.gameObject.tag == "WeaponAttack")
        {
            // Wolf�I�u�W�F�N�g����������
            Destroy(this.gameObject);
        }
    }

}
