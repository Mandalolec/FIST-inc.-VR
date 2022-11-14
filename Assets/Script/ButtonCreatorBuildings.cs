using System.Security.Cryptography.X509Certificates;
using Assets.Script.Map;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreatorBuildings : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParent;

    public GameObject nextMenu;

    void Start()
    {
        for (int i = 0; i < MenuManager.Buildings.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponent<LocationButton>().locationText.text = MenuManager.Buildings[i].Description.ToString();

            string buildName = MenuManager.Buildings[i].Name.ToString();
            newButton.GetComponent<Button>().onClick.AddListener(() => SwitchMenu(buildName));
        }
    }

    private void SwitchMenu(string buildName)
    {
        Building bState = MenuManager.Buildings.Find(x => x.Name == buildName);
        if (bState != null)
        {
            MenuManager.BState = bState;
            nextMenu.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
