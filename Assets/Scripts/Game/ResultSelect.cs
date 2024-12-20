using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    private Image Title;

    [SerializeField] 
    private Image Stage;

    [SerializeField]
    private int select;

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
            Title.sprite = imageTitle1;
            Stage.sprite = imageStage1;
        }
        else if(select == 2)
        {
            Stage.sprite = imageStage2;
            Title.sprite = imageTitle1;
        }
        else if (select == 3)
        {
            Stage.sprite = imageStage1;
            Title.sprite = imageTitle2;
        }
    }
}
