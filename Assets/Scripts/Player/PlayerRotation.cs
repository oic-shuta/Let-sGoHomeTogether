using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRotation : MonoBehaviour
{

    //�X���I�u�W�F�N�g
    [SerializeField]
    private GameObject rotationObject = null;

    [SerializeField]
    private GameObject playerSprite = null;
    private void Start()
    {
        playerSprite = this.gameObject;
    }
    private void Update()
    {
        playerSprite.transform.rotation = rotationObject.transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Seesaw"))//�V�[�\�[�ɏ���������̌X���𓾂�
        {
            rotationObject = collision.gameObject;
        }
        else//����ȊO���Ƃ܂������ɂ���
        {
            rotationObject = collision.gameObject;
        }
    }
}
