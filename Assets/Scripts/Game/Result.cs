using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private GameObject ResultImage;

    [SerializeField]
    public GameObject StopImage;

    [SerializeField]
    public bool GameOver;

    [SerializeField]
    public bool GameCler;

    [SerializeField]
    private string message;

    [SerializeField]
    private Text resultMessage;

    [SerializeField]
    private Text stopMessage;

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
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            StopImage.SetActive(true);

            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            StopImage.SetActive(false);

            Time.timeScale = 1;
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
        else
        {
            stopMessage.text = "ポーズ";
        }
        resultMessage.text = message;
    }
}
