using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CameraTarget cameraTarget;

    [SerializeField]
    private Camera leftCamera;

    [SerializeField]
    private Camera rightCamera;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject outLineLeft;

    [SerializeField]
    private GameObject outLineRight;

    [SerializeField]
    private bool outLeft = false;

    [SerializeField]
    private bool outRight = false;

    private void Start()
    {
        //Rect（左端が画面のどこに置くか、下の位置を画面のどこに置くか、画面のサイズ横、画面サイズ縦）
        leftCamera.rect = new Rect(0f, 0.4f, 0.2f, 0.25f);
        rightCamera.rect = new Rect(0.8f, 0.4f, 0.2f, 0.25f);
    }

    private void Update()
    {
        TargetCameraSub();
        CahngeCamera();
        TargetCameraOut();
    }

    private void CahngeCamera()
    {
        if (!outRight && !outLeft)
        {
            leftCamera.enabled = false;
            rightCamera.enabled = false;
        }
        else if(outLeft)
        {
            rightCamera.enabled = false;
            leftCamera.enabled = true;
        }
        else if(outRight)
        {
            leftCamera.enabled = false;
            rightCamera.enabled = true;
        }
    }

    private void TargetCameraOut()
    {
        if(target.transform.position.x < outLineLeft.transform.position.x) { outLeft = true; }
        else if(target.transform.position.x >  outLineRight.transform.position.x) { outRight = true; }
        else { outLeft = false; outRight = false; }
    }

    private void TargetCameraSub()
    {
        if (cameraTarget.cameraTypeDekatuyo)
        {
            target = cameraTarget.Chibiyowa;
        }
        else if (!cameraTarget.cameraTypeDekatuyo)
        {
            target = cameraTarget.Dekatuyo;
        }
    }
}
