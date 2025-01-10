using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{
    [SerializeField]
    private Result result;

    [SerializeField]
    private Sprite imageTitle1;

    [SerializeField]
    private Sprite imageTitle2;

    [SerializeField]
    private Sprite imageNoStop1
        ;
    [SerializeField]
    private Sprite imageNoStop2;
    
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
        if (Input.GetKeyDown("a"))
        {
            select--;
            if (select <= 1)
            {
                select = 1;
            }
        }
        if (Input.GetKeyDown("d"))
        {
            select++;
            if (select >= 3)
            {
                select = 3;
            }
        }
    }

    private void SelectColor()
    {
        SelectButton();
        if (select == 1)
        {
            ReStart.sprite = imageRestart2;
            Title.sprite = imageTitle1;
            Stage.sprite = imageNoStop1;
            SelectRestart();
        }
        else if (select == 2)
        {
            Stage.sprite = imageNoStop2;
            Title.sprite = imageTitle1;
            ReStart.sprite = imageRestart1;
            SelectNoStop();
        }
        else if (select == 3)
        {
            Title.sprite = imageTitle2;
            Stage.sprite = imageNoStop1;
            ReStart.sprite = imageRestart1;
            SelectTitle();
        }
    }

    private void SelectNoStop()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            result.StopImage.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void SelectTitle()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneTitle);
            Time.timeScale = 1;
        }
    }

    private void SelectRestart()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneReStart);
            Time.timeScale = 1;
        }
    }

}
