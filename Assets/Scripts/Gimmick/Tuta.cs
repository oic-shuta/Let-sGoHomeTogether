using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuta : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Switch _switch;

    [SerializeField] private Transform TutaEndPos;　 //移動終了位置
    [SerializeField] private Transform TutaDest;     //移動する方向
    [SerializeField] private float TutaSpeed;   　   //ツタの移動速度

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
        //プレイヤーがツタに乗ったら
        if (gameObject.CompareTag("Tuta") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Tutamove", true);

            Debug.Log("ツタに乗ったよ！");

        }
    }
}
