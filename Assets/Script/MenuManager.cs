using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml;
using Assets.Script.Map;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    public static List<Building> Buildings = new List<Building>();

    public static Building BState = new Building();

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
        List<Building> buildings = new List<Building>();

        TextAsset textAsset = Resources.Load<TextAsset>("locations");

        var document = new XmlDocument();
        document.LoadXml(textAsset.text);

        XmlElement? root = document.DocumentElement;

        foreach (XmlNode xNode in root)
        {
            Building building = new Building();
            List<Location> locations = new List<Location>();

            foreach (XmlNode child in xNode.ChildNodes)
            {
                if (child.Name == "Name") building.Name = child.InnerText;
                if (child.Name == "Description") building.Description = child.InnerText;

                if (child.Name == "Location")
                {
                    Location location = new Location();

                    foreach (XmlNode loc in child)
                    {
                        if (loc.Name == "name") location.Name = loc.InnerText;
                        if (loc.Name == "description") location.Description = loc.InnerText;
                        if (loc.Name == "startId") location.StartId = loc.InnerText;
                    }

                    if (location.Name != null) locations.Add(location);
                }
            }

            if (building.Name != null)
            {
                building.Locations = locations;
                buildings.Add(building);
            }
        }

        Buildings = buildings;
    }
}
