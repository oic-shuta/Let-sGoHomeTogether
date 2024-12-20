using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
    [SerializeField]
    private string SceneTitle;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneTitle);
        }
    }
}
