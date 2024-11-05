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
    private Camera outCamera;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject outLineLeft;

    [SerializeField]
    private GameObject outLineRight;

    [SerializeField]
    public bool outLeft = false;

    [SerializeField]
    private bool outRight = false;

    [SerializeField]
    private Rect leftCamera;

    [SerializeField]
    private Rect rightCamera;

    private void Start()
    {
        //Rect（左端が画面のどこに置くか、下の位置を画面のどこに置くか、画面のサイズ横、画面サイズ縦）
        leftCamera = new Rect(0f, 0.4f, 0.2f, 0.25f);
        rightCamera = new Rect(0.8f, 0.4f, 0.2f, 0.25f);

        outCamera.enabled = false;
    }

    private void Update()
    {
        TargetCameraOut();
        TargetCameraSub();
        CahngeCamera();
    }

    private void CahngeCamera()
    {
        if (!outRight && !outLeft)
        {
            outCamera.enabled = false;
        }
        else
        {
            outCamera.enabled = true;
        }
    }

    private void TargetCameraOut()
    {
        if(target.transform.position.x < outLineLeft.transform.position.x) 
        { 
            outLeft = true; 
            outCamera.rect = leftCamera; 
        }
        else if(target.transform.position.x >  outLineRight.transform.position.x)
        { 
            outRight = true; 
            outCamera.rect = rightCamera; 
        }
        else 
        { 
            outLeft = false; 
            outRight = false; 
        }
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
        outCamera.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,-10);
    }
}
