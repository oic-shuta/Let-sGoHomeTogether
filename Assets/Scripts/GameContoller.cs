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
    private Vector3 startPos1;

    [SerializeField]
    private Vector3 startPos2;
    private void Start()
    {
        playerDekatuyo.transform.position = startPos1;

        playerChibiyowa.transform.position = startPos2;
    }
}
