using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("A");
        }if(Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("B");
        }if(Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("X");
        }if(Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("Y");
        }if(Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("LB");
        }if(Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("RB");
        }if(Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("BACK");
        }if(Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("START");
        }
        if(Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("左スティック押し込み");
        }
        if(Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("右スティック押し込み");
        }

        float x = Input.GetAxis("Horizontal");
        if (x > 0.5f)
        {
            Debug.Log(x);
            Debug.Log("右に倒す");
        }
        else if (x < -0.5f)
        {
            Debug.Log(x);
            Debug.Log("左に倒す");
        }
        else　　//離したときに反応をなくす
        {
            x = 0;
            return;
        }

    }
}
