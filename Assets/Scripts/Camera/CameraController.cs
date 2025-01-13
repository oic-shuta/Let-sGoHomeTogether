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
    private SubCameraFrame frame;

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
        leftCamera = new Rect(0f, 0.4f, 0.15f, 0.25f); //左外のカメラの位置
        rightCamera = new Rect(0.85f, 0.4f, 0.15f, 0.25f);　//右外のカメラの位置

        outCamera.enabled = false;　//初期非表示
    }

    private void Update()
    {
        TargetCameraOut();
        TargetCameraSub();
        OutCamera();
    }

    //外に立た時に左右どちらかにカメラがでる
    private void OutCamera()
    {
        if (!outRight && !outLeft)　//メインカメラ内に2人いる
        {
            frame.frameLeftOn = false; 

            frame.frameRightOn = false; 

            frame.frameOut = false;

            outCamera.enabled = false;
        }
        else　
        {
            frame.frameOut = true;

            outCamera.enabled = true;
        }
    }

    //カメラ外に出た時左右どっちか
    private void TargetCameraOut()
    {
        if(target.transform.position.x < outLineLeft.transform.position.x) 
        { 
            outLeft = true; 
            frame.frameLeftOn = true;
            outCamera.rect = leftCamera; 
        }
        else if(target.transform.position.x >  outLineRight.transform.position.x)
        { 
            outRight = true; 
            frame.frameRightOn = true;
            outCamera.rect = rightCamera; 
        }
        else 
        { 
            outLeft = false; 
            outRight = false; 
        }
    }

    //画面外カメラを出す
    private void TargetCameraSub()
    {
        if (cameraTarget.cameraTypeDekatuyo)　//ちびよわが画面外に出たら
        {
            target = cameraTarget.Chibiyowa;
        }
        else if (!cameraTarget.cameraTypeDekatuyo)//でかつよが画面外に出たら
        {
            target = cameraTarget.Dekatuyo;
        }
        outCamera.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,-10);
    }
}
