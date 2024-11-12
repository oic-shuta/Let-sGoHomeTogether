using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [SerializeField]
    private GameObject playerDekatuyo;

    [SerializeField]
    private GameObject playerChibiyowa;

    [SerializeField]
    private GameObject reSpawnPoint;

    //プレイヤーのスタート位置
    [SerializeField]
    private Vector3 startPos1;

    //プレイヤーのスタート位置
    [SerializeField]
    private Vector3 startPos2;

    //プレイヤー達のライフ
    [SerializeField]
    public int playerLife;
    private void Start()
    {
        playerDekatuyo.transform.position = startPos1;

        playerChibiyowa.transform.position = startPos2;

        playerLife = 6;
    }

    private void Update()
    {
        PlayerContinue();
    }

    //コンテニュー
    private void PlayerContinue()
    {
        //ライフが0になったら
        if(playerLife <= 0)
        {
            PlayerSpawn();
            
            playerLife = 6;
        }
    }
    private void PlayerSpawn()
    {
        playerChibiyowa.transform.position = reSpawnPoint.transform.position;
        playerDekatuyo.transform.position = reSpawnPoint.transform.position;
    }
}
