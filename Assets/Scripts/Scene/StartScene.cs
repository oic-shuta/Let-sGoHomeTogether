using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    private Sprite imageSlect1;

    [SerializeField]
    private Sprite imageSlect2;

    [SerializeField]
    private Sprite imageCredit1;

    [SerializeField]
    private Sprite imageCredit2;

    [SerializeField]
    private Sprite imageEnd1;

    [SerializeField]
    private Sprite imageEnd2;

    [SerializeField]
    private Image Credit;

    [SerializeField]
    private Image End;

    [SerializeField]
    private Image Select;

    private int select;

    [SerializeField]
    private string SceneSelect;

    [SerializeField]
    private string SceneCredit;

    [SerializeField]
    private float deadZone = 0.5f;

    private bool joystickUp = false;

    private bool joystickDown = false;

    private float time = 0.5f;

    private float timer;


    private void Start()
    {
        select = 1;
    }
    private void SelectButton()
    {
        timer += Time.deltaTime;


        float y = Input.GetAxis("Vertical");
        if (timer > time)
        {
            if (y < -deadZone)
            {
                joystickUp = true;
                joystickDown = false;
                timer = 0;
            }
            else if (y > deadZone)
            {
                joystickDown = true;
                joystickUp = false;
                timer = 0;
            }
            else
            {
                joystickUp = false;
                joystickDown = false;
            }
            if (Input.GetKey("w"))
            {
                select--;
                if (select <= 1)
                {
                    select = 1;
                }
                timer = 0;
            }
            if (Input.GetKey("s"))
            {
                select++;
                if (select >= 3)
                {
                    select = 3;
                }
                timer = 0;
            }
        }
    }

    private void Update()
    {
        SelectColor();
    }
    private void SelectColor()
    {
        SelectButton();
        if (select == 1)
        {
            Select.sprite = imageSlect2;
            Credit.sprite = imageCredit1;
            End.sprite = imageEnd1;
            SelectSelect();
        }
        else if (select == 2)
        {
            Credit.sprite = imageCredit2;
            Select.sprite = imageSlect1;
            End.sprite = imageEnd1;
            SelectCredit();
        }
        else if (select == 3)
        {
            End.sprite = imageEnd2;
            Select.sprite = imageSlect1;
            Credit.sprite = imageCredit1;
            SelectEnd();
        }
    }
    private void SelectSelect()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneSelect);
        }
    }

    private void SelectCredit()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneCredit);
        }
    }

    private void SelectEnd()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.Quit();
        }
    }
}
