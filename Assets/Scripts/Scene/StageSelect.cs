using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    private Sprite imageStage0_1;

    [SerializeField]
    private Sprite imageStage0_2;

    [SerializeField]
    private Sprite imageStage1_1;

    [SerializeField]
    private Sprite imageStage1_2;

    [SerializeField]
    private Sprite imageTitle1;

    [SerializeField]
    private Sprite imageTitle2;

    [SerializeField]
    private Image Stage0;

    [SerializeField]
    private Image Stage1;

    [SerializeField]
    private Image Title;

    private int select;

    [SerializeField]
    private string SceneStage0;

    [SerializeField]
    private string SceneStage1;

    [SerializeField]
    private string SceneTitle;

    [SerializeField]
    private Image StageImage;

    [SerializeField]
    private Sprite Stage00;

    [SerializeField]
    private Sprite Stage01;

    [SerializeField]
    private Sprite TitleScene;

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
    private void Update()
    {
        SelectColor();
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
            if (Input.GetKey("w") || joystickUp)
            {
                select--;
                if (select <= 1)
                {
                    select = 1;
                }
                timer = 0;
            }
            else if (Input.GetKey("s") || joystickDown)
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

    private void SelectColor()
    {
        SelectButton();
        if (select == 3)
        {
            Title.sprite = imageTitle2;
            Stage0.sprite = imageStage0_1;
            Stage1.sprite = imageStage1_1;
            StageImage.sprite = TitleScene;
            SelectTitle();
        }
        else if (select == 2)
        {
            Stage1.sprite = imageStage1_2;
            Stage0.sprite = imageStage0_1;
            Title.sprite = imageTitle1;
            StageImage.sprite = Stage01;
            SelectStage1();
        }
        else if (select == 1)
        {
            Stage0.sprite = imageStage0_2;
            Stage1.sprite = imageStage1_1;
            Title.sprite = imageTitle1;
            StageImage.sprite = Stage00;
            SelectStage0();
        }
    }

    private void SelectStage0()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene(SceneStage0);
        }
    }

    private void SelectStage1()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene(SceneStage1);
        }
    }

    private void SelectTitle()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene(SceneTitle);
        }
    }

}
