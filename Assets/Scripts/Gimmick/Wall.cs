using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Switch _switch;

    [SerializeField] private Transform WallStartPos; //現在地
    [SerializeField] private Transform WallEndPos;　 //移動終了位置
    [SerializeField] private Transform WallDest;     //移動する方向
    [SerializeField] private float WallSpeed;   　   //壁の移動速度

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
