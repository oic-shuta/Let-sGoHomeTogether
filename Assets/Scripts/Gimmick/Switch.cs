using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;

    //�M�~�b�N�̕ϐ�
    [SerializeField] private GameObject Floor;

    public bool wallon = false;           //�ǃX�C�b�`�̃t���O
    public bool tutaon = false;           //�c�^�X�C�b�`�̃t���O


    //�X�C�b�`�̕ϐ�
    public GameObject TutaSwitch;   �@//�c�^�M�~�b�N�̃X�C�b�`
    public GameObject WallSwitch;     //�ǂ��㉺�Ɉړ�������X�C�b�`
    public GameObject FloorSwitch;    //�����\��������X�C�b�`

    int i = 0;                        //�X�C�b�`�̎��ʕϐ�


    //�v���C���[�̍��W������ϐ�
    public GameObject Player;


    private void Start()
    {
        animator = GetComponent<Animator>();

        TutaSwitch = GameObject.FindGameObjectWithTag("TutaSwitch");
        WallSwitch = GameObject.FindGameObjectWithTag("WallSwitch");
        FloorSwitch = GameObject.FindGameObjectWithTag("FloorSwitch");

        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[���c�^�X�C�b�`����������
        if (gameObject.CompareTag("TutaSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush",true);

            i = 1;
            Debug.Log("�c�^�X�C�b�`����������I");

            tutaon = true;
        }
        //�v���C���[���ǃX�C�b�`����������
        else if (gameObject.CompareTag("WallSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", true);

            i = 2;
            Debug.Log("�ǃX�C�b�`����������I");

            wallon = true;
        }
        //�v���C���[������X�C�b�`����������
        else if (gameObject.CompareTag("FloorSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", true);

            i = 3;
            Debug.Log("����X�C�b�`����������I");

            //�����\��
            Floor.SetActive(true);
        }
    }
   
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.CompareTag("WallSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", false);
        }

        //����̃X�C�b�`���痣�ꂽ��������\���ɂ���
        if (gameObject.CompareTag("FloorSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", false);

            Floor.SetActive(false);
        }
        
    }

    
}
