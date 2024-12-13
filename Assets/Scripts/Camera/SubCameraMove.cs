using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraMove : MonoBehaviour
{
    private SubCameraTarget cameraTarget;

    [Header("�J����")]
    public Vector3 cameraPos;

    public Camera cameraObject;

    //�J�����̉��s
    [Tooltip("�J�����̉��s")]
    private float cameraDepth;

    private void Start()
    {
        cameraTarget = GetComponent<SubCameraTarget>();

        cameraObject = GetComponent<Camera>();

        cameraPos = cameraObject.transform.position;

        cameraDepth = -1;
    }

    private void LateUpdate()
    {
        cameraTarget.CameraChange();
    }

    public void CamaraPos()
    {
        cameraPos = cameraTarget.targetObject.transform.position;

        cameraPos.z = cameraDepth;
    }
}
