using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    private CameraMove cameraMove;

    [Header("どのキャラにカメラを向けるか")]
    [Tooltip("でかつよ")]
    [SerializeField]
    public GameObject Dekatuyo;

    [Tooltip("ちびよわ")]
    [SerializeField]
    public GameObject Chibiyowa;

    [Tooltip("現在の操作キャラ")]
    [SerializeField]
    public GameObject targetObject;

    //カメラがどっちを追ってるか
    [SerializeField]
    public bool cameraTypeDekatuyo = true;

    //左端にカメラが移動した時に動かないようにする
    private Vector3 cameraPosLeft = new Vector3(0, 0, -10);

    private void Start()
    {
        cameraMove = GetComponent<CameraMove>();

        targetObject = Dekatuyo;
    }

    public void CameraChange()
    {
        cameraMove.MoveCamara();
        if (Input.GetKeyDown("q")||Input.GetKeyDown("joystick button 3"))
        {
            cameraTypeDekatuyo = !cameraTypeDekatuyo;
        }
        if (cameraTypeDekatuyo)
        {
            targetObject = Dekatuyo;
            if (targetObject.transform.position.x < 0)
            {
                return;
            }

            cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
        }
        else if (!cameraTypeDekatuyo)
        {
            targetObject = Chibiyowa;
            if (targetObject.transform.position.x < 0)
            {
                return;
            }
            cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
        }
    }
}
