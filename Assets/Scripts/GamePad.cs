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
            Debug.Log("1");
        }if(Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("2");
        }if(Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("3");
        }if(Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("4");
        }if(Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("5");
        }if(Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("6");
        }if(Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("7");
        }
if(Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("8");
        }
if(Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("9");
        }
        if(Input.GetKeyDown("joystick button Dwon"))
        {
            Debug.Log("10");
        }
        if(Input.GetKeyDown("joystick button 11"))
        {
            Debug.Log("11");
        }    if(Input.GetKeyDown("joystick button 12"))
        {
            Debug.Log("12");
        }
        

    }
}
