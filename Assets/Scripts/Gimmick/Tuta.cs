using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuta : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Switch _switch;

    [SerializeField] private Transform TutaEndPos;�@ //�ړ��I���ʒu
    [SerializeField] private Transform TutaDest;     //�ړ��������
    [SerializeField] private float TutaSpeed;   �@   //�c�^�̈ړ����x

    void Start()
    {
        animator = GetComponent<Animator>();

        TutaDest = TutaEndPos;
    }

    void Update()
    {
        if (_switch.tutaon)
        {
            TutaMove();
        }
    }

    private void TutaMove()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,
            TutaDest.position, TutaSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[���c�^�ɏ������
        if (gameObject.CompareTag("Tuta") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Tutamove", true);

            Debug.Log("�c�^�ɏ������I");

        }
    }
}
