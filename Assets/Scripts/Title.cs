using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    Button StartButton;
    Button EndButton;

    void Start()
    {
        StartButton = GameObject.Find("/Canvas/StartButton").GetComponent<Button>();
        EndButton   = GameObject.Find("/Canvas/EndButton").GetComponent<Button>();

        StartButton.Select();
    }

    void Update()
    {
        
    }
}
