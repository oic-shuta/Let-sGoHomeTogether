using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Camera subCamera;

    [SerializeField]
    private GameObject cameraOutLeft;
    [SerializeField]
    private GameObject cameraOutRight;

    private void Start()
    {
        mainCamera.rect = new Rect(1, 1, 1, 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown("b"))
        {
             mainCamera.rect = new Rect(0.5f, 0f, 0.5f, 1f);
             subCamera.rect = new Rect(0f, 0f, 0.5f, 1f);
        }
        if(Input.GetKeyDown("c"))
        {
            mainCamera.rect = new Rect(1, 1, 1, 1);
            subCamera = Camera.main;
        }
    }



}
