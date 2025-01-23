using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySetting : MonoBehaviour
{
    [SerializeField]
    private GameObject joy;

    [SerializeField]
    private GameObject Key;

    private void Update()
    {
        Setting();
    }

    private void Setting()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("d") || Input.GetKeyDown("s") || Input.GetKeyDown("e") || Input.GetKeyDown("q"))
        {
            joy.SetActive(false);
            Key.SetActive(true);
        }
        else if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 3") || Input.GetKeyDown("joystick button 4")
            || Input.GetKeyDown("joystick button 5") || Input.GetKeyDown("joystick button 6") || Input.GetKeyDown("joystick button 7") || Input.GetKeyDown("joystick button 8") || Input.GetKeyDown("joystick button 9"))
            {
            Key.SetActive(false);
            joy.SetActive(true);
        }
    }
    
}
