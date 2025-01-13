using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour
{
    [SerializeField]
    private Result result;

    [SerializeField]
    private GameObject playerDekatuyo;

    [SerializeField]
    private GameObject playerChibiyowa;

    [SerializeField]
    public GameObject reSpawnPoint;

    [SerializeField]
    public bool haveKey = false;

    [SerializeField]
    private GameObject ItemIcon;

    //�v���C���[�̃X�^�[�g�ʒu
    [SerializeField]
    private Vector3 startPos1;

    //�v���C���[�̃X�^�[�g�ʒu
    [SerializeField]
    private Vector3 startPos2;

    //�v���C���[�B�̃��C�t
    [SerializeField]
    public int playerLife;
    private void Start()
    {
        PlayerStartPos();

        playerLife = 6;

        ItemIcon.SetActive(false);
    }

    private void Update()
    {
        PlayerContinue();

        if(haveKey)
        {
            ItemIcon.SetActive(true);
        }
    }

    //�R���e�j���[
    private void PlayerContinue()
    {
        //���C�t��0�ɂȂ�����
        if(playerLife <= 0)
        {
            PlayerSpawn();
            
            result.GameOver = true;
        }
    }
    private void PlayerSpawn()
    {
        if (reSpawnPoint == null)
        {
            result.GameOver = true;
        }
        else
        {
            playerChibiyowa.transform.position = reSpawnPoint.transform.position;
            playerDekatuyo.transform.position = reSpawnPoint.transform.position;
        }
    }

    public void PlayerFallOut()
    {
        playerLife--;
        if (reSpawnPoint == null)
        {
            PlayerStartPos();
        }
        else
        {
            PlayerSpawn();
        }
    } 

    private void PlayerStartPos()
    {
        playerDekatuyo.transform.position = startPos1;

        playerChibiyowa.transform.position = startPos2;
    }
}
