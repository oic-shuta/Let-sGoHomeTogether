using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    [SerializeField]
    private GameContoller game;

    [SerializeField]
    private GameObject[] hp;

    private void Update()
    {
        PlayerUI();
    }

    private void PlayerUI()
    {
        for (int i = 0; game.playerLife > i; i++)
        {
            for (int j = 6; game.playerLife < j; j--)
            {
                hp[game.playerLife].SetActive(false);
            }
            hp[i].SetActive(true);
        }
    }
}
