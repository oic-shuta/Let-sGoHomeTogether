using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void Update()
    {
        PlayerContinue();
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
        playerChibiyowa.transform.position = reSpawnPoint.transform.position;
        playerDekatuyo.transform.position = reSpawnPoint.transform.position;
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
