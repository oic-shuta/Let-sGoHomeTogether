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
        playerDekatuyo.transform.position = startPos1;

        playerChibiyowa.transform.position = startPos2;

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
            
            playerLife = 6;
        }
    }
    private void PlayerSpawn()
    {
        playerChibiyowa.transform.position = reSpawnPoint.transform.position;
        playerDekatuyo.transform.position = reSpawnPoint.transform.position;
    }
}
