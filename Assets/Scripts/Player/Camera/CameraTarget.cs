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
    public GameObject Dekatuyo;

    [Tooltip("���т��")]
    [SerializeField]
    public GameObject Chibiyowa;

    [Tooltip("���݂̑���L����")]
    [SerializeField]
    public GameObject targetObject;

    //�J�������ǂ�����ǂ��Ă邩
    [SerializeField]
    public bool cameraTypeDekatuyo = true;

    //���[�ɃJ�������ړ��������ɓ����Ȃ��悤�ɂ���
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
