using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMenuController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //user pressed back key
            Application.Quit();
        }
    }
}
