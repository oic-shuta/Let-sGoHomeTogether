using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField]
    private CameraMove cameraMove;

    [Header("�ǂ̃L�����ɃJ�����������邩")]
    [Tooltip("�ł���")]
    [SerializeField]
    private GameObject playerObject1;

    [Tooltip("���т��")]
    [SerializeField]
    private GameObject playerObject2;

    [Tooltip("���݂̑���L����")]
    [SerializeField]
    public GameObject targetObject;

    //�J�������ǂ�����ǂ��Ă邩
    [SerializeField]
    private bool cameraType = true;

    //���[�ɃJ�������ړ��������ɓ����Ȃ��悤�ɂ���
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
