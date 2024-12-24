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
        if(Input.GetKeyDown("a"))
        {
            select--;
            if(select <= 1)
            {
                select = 1;
            }
        }
        if (Input.GetKeyDown("d"))
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
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(SceneSatge);
        }
    }

    private void SelectTitle()
    {
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(SceneTitle);
        }
    }

    private void SelectRestart()
    {
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(SceneReStart);
            Time.timeScale = 1;
        }
    }
}
