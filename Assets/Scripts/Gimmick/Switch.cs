using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Animator animator;

    //ギミックの変数
    [SerializeField] private GameObject Floor;

    public bool wallon = false;           //壁スイッチのフラグ
    public bool tutaon = false;           //ツタスイッチのフラグ


    //スイッチの変数
    public GameObject TutaSwitch;   　//ツタギミックのスイッチ
    public GameObject WallSwitch;     //壁を上下に移動させるスイッチ
    public GameObject FloorSwitch;    //足場を表示させるスイッチ

    int i = 0;                        //スイッチの識別変数


    //プレイヤーの座標を入れる変数
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
        //プレイヤーがツタスイッチを押したら
        if (gameObject.CompareTag("TutaSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush",true);

            i = 1;
            Debug.Log("ツタスイッチを押したよ！");

            tutaon = true;
        }
        //プレイヤーが壁スイッチを押したら
        else if (gameObject.CompareTag("WallSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", true);

            i = 2;
            Debug.Log("壁スイッチを押したよ！");

            wallon = true;
        }
        //プレイヤーが足場スイッチを押したら
        else if (gameObject.CompareTag("FloorSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", true);

            i = 3;
            Debug.Log("足場スイッチを押したよ！");

            //足場を表示
            Floor.SetActive(true);
        }
    }
   
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.CompareTag("WallSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", false);
        }

        //足場のスイッチから離れた時足場を非表示にする
        if (gameObject.CompareTag("FloorSwitch") && collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Switchpush", false);

            Floor.SetActive(false);
        }
        
    }

    
}
