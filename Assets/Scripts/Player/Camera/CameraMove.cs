using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private CameraTarget cameraTarget;

    [Header("カメラ")]
    public Vector3 cameraPos;

    public Camera cameraObject;

    //カメラの高さ
    [Tooltip("カメラの高さ")]
    [SerializeField]
    private float cameraHight;

    //カメラの奥行
    [Tooltip("カメラの奥行")]
    [SerializeField]
    private float cameraDepth;

    private void Start()
    {
        cameraObject = GetComponent<Camera>();

        cameraPos = cameraObject.transform.position;
    }

    private void LateUpdate()
    {
        cameraTarget.CameraChange();
    }

    public void MoveCamara()
    {
        cameraPos = cameraTarget.targetObject.transform.position;

        cameraPos.y = cameraHight;

        cameraPos.z = cameraDepth;
    }
}
