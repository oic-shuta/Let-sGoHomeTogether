using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeesawObject : MonoBehaviour
{
    [SerializeField]
    private GameObject seesaw;

    [SerializeField]
    private GameObject maxRotate;

    [SerializeField]
    private GameObject minRotate;

    [SerializeField]
    private GameObject seesawPos;

    private void Start()
    {
        seesaw = this.gameObject;
    }
    private void FixedUpdate()
{
        SeesawRotate();

        seesaw.transform.position = seesawPos.transform.position;
    }

    private void SeesawRotate()
    {
        if(seesaw.transform.rotation.z < minRotate.transform.rotation.z)
        {
            seesaw.transform.rotation = minRotate.transform.rotation;
        }
        else if(seesaw.transform.rotation.z > maxRotate.transform.rotation.z)
        {
            seesaw.transform.rotation = maxRotate.transform.rotation;
        }
        this.gameObject.transform.rotation = seesaw.transform.rotation;

    }
}
