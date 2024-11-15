using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //スイッチの変数
    public GameObject TutaSwitch;   　//ツタギミックのスイッチ
    public GameObject WallSwitch;     //壁が動くギミックのスイッチ
    public GameObject FloorSwitch;    //足場を表示させるスイッチ

    //スイッチの識別変数
    int i = 0;

    //プレイヤーの座標を入れる変数
    public GameObject Player;

    //ギミックの変数
    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Floor;

    //壁の移動量
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

        //プレイヤーがツタスイッチを押したら
        if (gameObject.CompareTag("TutaSwitch") && collision.gameObject.CompareTag("Player"))
        {
            i = 1;
            Debug.Log("ツタスイッチを押したよ！");
        }
        //プレイヤーが壁スイッチを押したら
        else if (gameObject.CompareTag("WallSwitch") && collision.gameObject.CompareTag("Player"))
        {
            i = 2;
            Debug.Log("壁スイッチを押したよ！");

            
            //壁が上に移動
            Wall.transform.Translate(UpMove);
        }
        //プレイヤーが足場スイッチを押したら
        else if (gameObject.CompareTag("FloorSwitch") && collision.gameObject.CompareTag("Player"))
        {
            i = 3;
            Debug.Log("足場スイッチを押したよ！");

            //足場を表示
            Floor.SetActive(true);
        }
    }
   
    //足場のスイッチから離れた時足場を非表示にする
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
