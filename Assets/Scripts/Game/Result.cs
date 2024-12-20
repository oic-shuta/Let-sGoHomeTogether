using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private GameObject ResultImage;

    [SerializeField]
    public bool GameOver;

    [SerializeField]
    public bool GameCler;

    [SerializeField]
    private string message;

    [SerializeField]
    private Text resultMessage;

    private void Start()
    {
        ResultImage.SetActive(false);

        GameCler = false;

        GameOver = false;

        message = " ";
    }
    private void Update()
    {
        ResultMessage();

        RenderResult();
    }

    private void RenderResult()
    {
        if (GameCler || GameOver)
        {
            ResultImage.SetActive(true);

            Time.timeScale = 0;
        }
    }

    private void ResultMessage()
    {
        if(GameCler)
        {
            message = "ステージクリア";
        }
        else if(GameOver)
        {
            message = "ゲームオーバー";
        }
        resultMessage.text = message;
    }
}
