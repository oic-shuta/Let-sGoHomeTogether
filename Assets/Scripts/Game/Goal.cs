using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private GameObject subCamera;

    [SerializeField]
    private GameContoller game;

    [SerializeField]
    private PlayerController playerDeka;

    [SerializeField] 
    private PlayerController playerChibi;

    [SerializeField]
    private GameObject Dekatuyo;

    [SerializeField]
    private GameObject Chibiyowa;

    [SerializeField]
    public bool inGoal;

    [SerializeField]
    private bool doorLock;

    [SerializeField]
    public bool ChibiGoal;

    [SerializeField]
    public bool DekaGoal;

    [SerializeField]
    private string nextScene;

    [SerializeField]
    private Result result;


    private void Start()
    {
        inGoal = false;

        ChibiGoal = false;

        DekaGoal = false;

        doorLock = true;
    }

    private void Update()
    {
        GameCler();
        NextScene();
    }
    private void PlayerGoal()
    {
        if (playerDeka.playerDekatuyo && !DekaGoal || playerChibi.playerDekatuyo && !DekaGoal)
        {
            Dekatuyo.SetActive(false);

            subCamera.SetActive(false);

            DekaGoal = true;
        }
        if (!playerDeka.playerDekatuyo && !ChibiGoal || !playerChibi.playerDekatuyo && !ChibiGoal)
        {
            Chibiyowa.SetActive(false);

            subCamera.SetActive(false);

            ChibiGoal = true;
        }
    }

    private void GameCler()
    {
        if(game.haveKey && Input.GetKeyDown("s")){
            if (doorLock)
            {
                doorLock = false;
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            }
            else if (!doorLock)
            {
                PlayerGoal();
            }

        }
    }
    private void NextScene()
    {
        if(ChibiGoal && DekaGoal)
        {
            result.GameCler = true;
        }
    }
}