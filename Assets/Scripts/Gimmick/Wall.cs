using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Switch _switch;

    [SerializeField] private Transform WallStartPos; //���ݒn
    [SerializeField] private Transform WallEndPos;�@ //�ړ��I���ʒu
    [SerializeField] private Transform WallDest;     //�ړ��������
    [SerializeField] private float WallSpeed;   �@   //�ǂ̈ړ����x

    void Start()
    {
        WallDest = WallEndPos;
    }

    void Update()
    {
        if (_switch.wallon)
        {
            WallMove();
        }

        var dist = Vector3.Distance(this.transform.position, WallDest.position);

        if (dist < 0.1)
        {
            WallDest = (WallDest == WallEndPos) ? WallStartPos : WallEndPos;
            _switch.wallon = false;
        }
    }

    private void WallMove()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,
            WallDest.position, WallSpeed * Time.deltaTime);
    }
}
