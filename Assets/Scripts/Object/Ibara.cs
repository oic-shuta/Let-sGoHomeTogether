using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ibara : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[����ɂ���������
        if (gameObject.CompareTag("Ibara") && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("��ɓ���������I");

        }
    }
}
