using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasoru : MonoBehaviour
{
    [SerializeField]
    private GameObject casoruDeka;

    [SerializeField]
    private GameObject casoruChibi;

    [SerializeField]
    private PlayerController controllerDeka;

    [SerializeField]
    private PlayerController controllerChibi;

    private void Update()
    {
        if (controllerDeka.playerDekatuyo || controllerChibi.playerDekatuyo)
        {
            casoruDeka.SetActive(true);
            casoruChibi.SetActive(false);
        }
        else if (!controllerDeka.playerDekatuyo || !controllerChibi.playerDekatuyo)
        {
            casoruDeka.SetActive(false);
            casoruChibi.SetActive(true);
        }
    }
}
