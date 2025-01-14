using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSelect : MonoBehaviour
{
    [SerializeField]
    private Result result;

    [SerializeField]
    private Sprite imageTitle1;

    [SerializeField]
    private Sprite imageTitle2;

    [SerializeField]
    private Sprite imageStage1;

    [SerializeField]
    private Sprite imageStage2;

    [SerializeField]
    private Sprite imageRestart1;

    [SerializeField]
    private Sprite imageRestart2;
 
    [SerializeField]
    private Image Title;

    [SerializeField] 
    private Image Stage;

    [SerializeField]
    private Image ReStart;

    private int select;

    [SerializeField]
    private string SceneTitle;

    [SerializeField]
    private string SceneSatge;

    [SerializeField]
    private string SceneReStart;

    [SerializeField]
    private bool joystickLeft = false;

    [SerializeField]
    private bool joystickRight = false;

    [SerializeField]
    private float deadZone = 0;

    private void Start()
    {
        select = 2;

    }
    private void Update()
    {
        SelectColor();
    }


    private void SelectButton()
    {
        //スティックの右または左に倒れてるか
        float x = Input.GetAxis("Horizontal");
        if (x < -deadZone)
        {
            joystickLeft = true;
            joystickRight = false;
        }
        else if (x > deadZone)
        {
            joystickRight = true;
            joystickLeft = false;
        }
        else
        {
            joystickLeft = false;
            joystickRight = false;
        }

        if (Input.GetKeyDown("a") || joystickLeft)
        {
            select--;
            if(select <= 1)
            {
                select = 1;
            }
        }
        if (Input.GetKeyDown("d") || joystickRight)
        {
            select++;
            if(select >= 3)
            {
                select = 3;
            }
        }
    }

    private void SelectColor()
    {
        SelectButton();
        if(select == 1)
        {
            ReStart.sprite = imageRestart2;
            Title.sprite = imageTitle1;
            Stage.sprite = imageStage1;
            SelectRestart();
        }
        else if(select == 2)
        {
            Stage.sprite = imageStage2;
            Title.sprite = imageTitle1;
            ReStart.sprite = imageRestart1;
            SelectStage();
        }
        else if (select == 3)
        {
            Title.sprite = imageTitle2;
            Stage.sprite = imageStage1;
            ReStart.sprite = imageRestart1;
            SelectTitle();
        }
    }

    private void SelectStage()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene(SceneSatge);
            Time.timeScale = 1;
        }
    }

    private void SelectTitle()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene(SceneTitle);
            Time.timeScale = 1;
        }
    }

    private void SelectRestart()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene(SceneReStart);
            Time.timeScale = 1;
        }
    }
}
