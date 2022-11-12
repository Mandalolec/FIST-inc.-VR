using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    void Start()
    {
        for (int i = 0; i < MenuManager.Locations.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponent<LocationButton>().locationText.text = MenuManager.Locations[i].Description.ToString();
            
            var startLocation = MenuManager.Locations[i].StartId.ToString();
            newButton.GetComponent<Button>().onClick.AddListener(() => SwitchScene(startLocation));
        }
    }

    private void SwitchScene(string  startLocation)
    {
        Node state = SceneManager.Nodes.Find(x => x.Main == startLocation);
        if (state != null)
        {
            SceneManager.State = state;
            UnityEngine.SceneManagement.SceneManager.LoadScene("PhotoViewScene");
        }
    }
}
