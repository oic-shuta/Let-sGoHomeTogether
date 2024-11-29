using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    //移動開始位置
    [SerializeField] private Transform strat;

    //移動終了位置
    [SerializeField] private Transform end;

    //移動する方向
    [SerializeField] private Transform dest;

    
    [SerializeField] private bool on = false;

    //移動速度
    [SerializeField] private float speed;
    private void Start()
    {
        dest = end;
    }

    void Update()
    {
        //オンの間移動する
        if (on)
        {
            UpdateMove();        
        }

        var dist = Vector3.Distance(this.transform.position, dest.position);

        //移動する方向を変更してオフにする
        if (dist < 0.1)
        {
            dest = (dest == end) ? strat : end;
            on = false;
        }

    }

    //移動処理
    private void UpdateMove()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,
                dest.position, speed * Time.deltaTime);
    }

}
