using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Script.Map;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    public static List<Location> Locations = new List<Location>();

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        InitializeManager();
    }

    private void InitializeManager()
    {
        List<Location> locations = new List<Location>();

        TextAsset textAsset = Resources.Load<TextAsset>("locations");

        var document = new XmlDocument();
        document.LoadXml(textAsset.text);

        XmlElement? root = document.DocumentElement;

        foreach (XmlNode xNode in root)
        {
            Location location = new Location();

            foreach (XmlNode child in xNode.ChildNodes)
            {
                if (child.Name == "name") location.Name = child.InnerText;
                if (child.Name == "description") location.Description = child.InnerText;
                if (child.Name == "startId") location.StartId = child.InnerText;
            }
            if (location.Name != null) locations.Add(location);
        }

        Locations = locations;
    }
}
