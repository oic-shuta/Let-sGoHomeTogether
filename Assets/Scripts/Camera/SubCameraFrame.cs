using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraFrame : MonoBehaviour
{
    [SerializeField]
    private Goal goal;

    [SerializeField]
    public bool frameLeftOn;

    [SerializeField]
    public bool frameRightOn;

    [SerializeField]
    public bool frameOut;

    [SerializeField]
    private GameObject LeftFrame;

    [SerializeField]
    private GameObject RightFrame;

    private void Start()
    {
        LeftFrame.SetActive(false);

        RightFrame.SetActive(false);
    }

    private void Update()
    {
        if (frameOut)
        {
            if (frameLeftOn)
            {
                LeftFrame.SetActive(true);
            }
            else if (frameRightOn)
            {
                RightFrame.SetActive(true);
            }
        }
        else
        {
            LeftFrame.SetActive(false);

            RightFrame.SetActive(false);
        }
        if(goal.ChibiGoal || goal.DekaGoal)
        {
            this.gameObject.SetActive(false);
        }
    }
}
