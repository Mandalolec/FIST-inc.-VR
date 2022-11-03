using UnityEngine;

public class AppLoader : MonoBehaviour
{
    public GameObject sceneManager;

    void Awake()
    {
        if (SceneManager.Instance == null)
            Instantiate(sceneManager);
    }
}
