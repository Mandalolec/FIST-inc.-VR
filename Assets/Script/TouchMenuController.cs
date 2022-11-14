using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMenuController : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject secondMenu;
    public GameObject secondMenuContent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (secondMenu.activeSelf)
            {
                startMenu.gameObject.SetActive(true);
                secondMenu.gameObject.SetActive(false);

                foreach (Transform child in secondMenuContent.transform)
                {
                    Destroy(child.gameObject);
                }
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
