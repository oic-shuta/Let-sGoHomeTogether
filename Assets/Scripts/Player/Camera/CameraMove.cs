using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private CameraTarget cameraTarget;

    [Header("�J����")]
    public Vector3 cameraPos;

    public Camera cameraObject;

    //�J�����̍���
    [Tooltip("�J�����̍���")]
    [SerializeField]
    private float cameraHight;

    //�J�����̉��s
    [Tooltip("�J�����̉��s")]
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
