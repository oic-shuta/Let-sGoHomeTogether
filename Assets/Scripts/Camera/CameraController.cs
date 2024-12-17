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
        //Rect�i���[����ʂ̂ǂ��ɒu�����A���̈ʒu����ʂ̂ǂ��ɒu�����A��ʂ̃T�C�Y���A��ʃT�C�Y�c�j
        leftCamera = new Rect(0f, 0.4f, 0.15f, 0.25f); //���O�̃J�����̈ʒu
        rightCamera = new Rect(0.85f, 0.4f, 0.15f, 0.25f);�@//�E�O�̃J�����̈ʒu

        outCamera.enabled = false;�@//������\��
    }

    private void Update()
    {
        TargetCameraOut();
        TargetCameraSub();
        OutCamera();
    }

    //�O�ɗ������ɍ��E�ǂ��炩�ɃJ�������ł�
    private void OutCamera()
    {
        if (!outRight && !outLeft)�@//���C���J��������2�l����
        {
            outCamera.enabled = false;
        }
        else�@
        {
            outCamera.enabled = true;
        }
    }

    //�J�����O�ɏo�������E�ǂ�����
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

    //��ʊO�J�������o��
    private void TargetCameraSub()
    {
        if (cameraTarget.cameraTypeDekatuyo)�@//���т�킪��ʊO�ɏo����
        {
            target = cameraTarget.Chibiyowa;
        }
        else if (!cameraTarget.cameraTypeDekatuyo)//�ł��悪��ʊO�ɏo����
        {
            target = cameraTarget.Dekatuyo;
        }
        outCamera.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,-10);
    }
}
