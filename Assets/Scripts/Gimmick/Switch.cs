using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //�X�C�b�`�̕ϐ�
    public GameObject TutaSwitch;   �@//�c�^�M�~�b�N�̃X�C�b�`
    public GameObject WallSwitch;     //�ǂ������M�~�b�N�̃X�C�b�`
    public GameObject FloorSwitch;    //�����\��������X�C�b�`

    //�X�C�b�`�̎��ʕϐ�
    int i = 0;

    //�v���C���[�̍��W������ϐ�
    public GameObject Player;

    //�M�~�b�N�̕ϐ�
    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Floor;

    //�ǂ̈ړ���
    Vector3 UpMove = new Vector3(0, 5, 0);
    Vector3 DownMove = new Vector3(0, -5, 0);


    private void Start()
    {
        TutaSwitch = GameObject.FindGameObjectWithTag("TutaSwitch");
        WallSwitch = GameObject.FindGameObjectWithTag("WallSwitch");
        FloorSwitch = GameObject.FindGameObjectWithTag("FloorSwitch");

        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        int a = 1;

        //�v���C���[���c�^�X�C�b�`����������
        if (gameObject.CompareTag("TutaSwitch") && collision.gameObject.CompareTag("Player"))
        {
            i = 1;
            Debug.Log("�c�^�X�C�b�`����������I");
        }
        //�v���C���[���ǃX�C�b�`����������
        else if (gameObject.CompareTag("WallSwitch") && collision.gameObject.CompareTag("Player"))
        {
            i = 2;
            Debug.Log("�ǃX�C�b�`����������I");

            
            //�ǂ���Ɉړ�
            Wall.transform.Translate(UpMove);
        }
        //�v���C���[������X�C�b�`����������
        else if (gameObject.CompareTag("FloorSwitch") && collision.gameObject.CompareTag("Player"))
        {
            i = 3;
            Debug.Log("����X�C�b�`����������I");

            //�����\��
            Floor.SetActive(true);
        }
    }
   
    //����̃X�C�b�`���痣�ꂽ��������\���ɂ���
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.CompareTag("FloorSwitch") && collision.gameObject.CompareTag("Player"))
        {
            Floor.SetActive(false);
        }
        else if (gameObject.CompareTag("WallSwitch") && collision.gameObject.CompareTag("Player"))
        {
            Wall.transform.Translate(DownMove);
        }
    }
}
