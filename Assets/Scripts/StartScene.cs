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


    private void Start()
    {
        select = 1;
    }
    private void SelectButton()
    {
        if (Input.GetKeyDown("w"))
        {
            select--;
            if (select <= 1)
            {
                select = 1;
            }
        }
        if (Input.GetKeyDown("s"))
        {
            select++;
            if (select >= 3)
            {
                select = 3;
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
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(SceneSelect);
        }
    }

    private void SelectCredit()
    {
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(SceneCredit);
        }
    }

    private void SelectEnd()
    {
        if (Input.GetKeyDown("l"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
