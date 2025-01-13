using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private Goal goal;

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

    [SerializeField]
    private PlayerController playerController1;

    [SerializeField]
    private PlayerController playerController2;

    [SerializeField]
    private Image player;

    [SerializeField]
    private Sprite ani;

    [SerializeField]
    private Sprite otouto;

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

        if (playerController1.playerDekatuyo || playerController2.playerDekatuyo)
        {
            player.sprite = otouto;
        }
        else if(!playerController1.playerDekatuyo || !playerController2.playerDekatuyo)
        {
            player.sprite = ani;
        }

        if (goal.ChibiGoal)
        {
            player.sprite = otouto;
        }
        else if(goal.DekaGoal)
        {
            player.sprite = ani;
        }
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
