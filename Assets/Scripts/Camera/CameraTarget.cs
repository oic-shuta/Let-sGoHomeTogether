using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    private Goal goal;

    [SerializeField]
    private CameraMove cameraMove;

    [SerializeField]
    private CameraController cameraController;

    [Header("どのキャラにカメラを向けるか")]
    [Tooltip("でかつよ(サブカメラは逆)")]
    [SerializeField]
    public GameObject Dekatuyo;

    [Tooltip("ちびよわ(サブカメラは逆)")]
    [SerializeField]
    public GameObject Chibiyowa;

    [Tooltip("現在の操作キャラ")]
    [SerializeField]
    public GameObject targetObject;

    //カメラがどっちを追ってるか
    [SerializeField]
    public bool cameraTypeDekatuyo = true;


    [SerializeField]
    public float stageEnd;

    private void Start()
    {
        cameraMove = GetComponent<CameraMove>();

        targetObject = Dekatuyo;
    }

    public void CameraChange()
    {
        if (Input.GetKeyDown("q")||Input.GetKeyDown("joystick button 3"))
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
        else if(targetObject.transform.position.x > stageEnd)
        {
            return;
        }
        else
        {
            cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
        }
    }
}
