using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraTarget : MonoBehaviour
{
    [SerializeField]
    private Goal goal;

    [SerializeField]
    private SubCameraMove cameraMove;

    [SerializeField]
    private CameraController cameraController;

    [Header("�ǂ̃L�����ɃJ�����������邩")]
    [Tooltip("�ł���(�T�u�J�����͋t)")]
    [SerializeField]
    public GameObject Dekatuyo;

    [Tooltip("���т��(�T�u�J�����͋t)")]
    [SerializeField]
    public GameObject Chibiyowa;

    [Tooltip("���݂̑���L����")]
    [SerializeField]
    public GameObject targetObject;

    //�J�������ǂ�����ǂ��Ă邩
    [SerializeField]
    public bool cameraTypeDekatuyo = true;

    private void Start()
    {
        cameraMove = GetComponent<SubCameraMove>();

        targetObject = Dekatuyo;
    }

    public void CameraChange()
    {
        if (Input.GetKeyDown("q") || Input.GetKeyDown("joystick button 3"))
        {
            cameraTypeDekatuyo = !cameraTypeDekatuyo;

            cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
        }

        if (goal.DekaGoal)
        {
            cameraTypeDekatuyo = false;
        }
        else if (goal.ChibiGoal)
        {
            cameraTypeDekatuyo = true;
        }

        if (cameraTypeDekatuyo)
        {
            targetObject = Dekatuyo;
        }
        else if (!cameraTypeDekatuyo)
        {
            targetObject = Chibiyowa;
        }
        MoveCamera();
    }

    private void MoveCamera()
    {
        cameraMove.CamaraPos();
        if (targetObject.transform.position.x < 0)
        {
            if (cameraController.outLeft)
            {
                cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
                return;
            }
            cameraMove.cameraObject.transform.position = new Vector3(0, cameraMove.cameraPos.y, cameraMove.cameraPos.z);
        }
        else
        {
            cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
        }
    }
}
