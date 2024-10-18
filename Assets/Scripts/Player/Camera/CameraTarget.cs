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
    private GameObject playerObject1;

    [Tooltip("ちびよわ")]
    [SerializeField]
    private GameObject playerObject2;

    [Tooltip("現在の操作キャラ")]
    [SerializeField]
    public GameObject targetObject;

    //カメラがどっちを追ってるか
    [SerializeField]
    private bool cameraType = true;

    //左端にカメラが移動した時に動かないようにする
    private Vector3 cameraPosLeft = new Vector3(0, 0, -10);

    private void Start()
    {
        cameraMove = GetComponent<CameraMove>();

        targetObject = playerObject1;
    }

    public void CameraChange()
    {
        cameraMove.MoveCamara();
        if (Input.GetKeyDown("q"))
        {
            cameraType = !cameraType;
        }
        if (cameraType)
        {
            targetObject = playerObject1;
            if (targetObject.transform.position.x < 0)
            {
                cameraMove.cameraObject.transform.position = cameraPosLeft;
                return;
            }

            cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
        }
        else if (!cameraType)
        {
            targetObject = playerObject2;
            if (targetObject.transform.position.x < 0)
            {
                cameraMove.cameraObject.transform.position = cameraPosLeft;
                return;
            }
            cameraMove.cameraObject.transform.position = cameraMove.cameraPos;
        }
    }
}
