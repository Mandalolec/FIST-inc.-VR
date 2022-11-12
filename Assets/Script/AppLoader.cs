using UnityEngine;

public class AppLoader : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject menuManager;

    void Awake()
    {
        if (SceneManager.Instance == null)
            Instantiate(sceneManager);
        if (MenuManager.Instance == null)
            Instantiate(menuManager);
    }
}
