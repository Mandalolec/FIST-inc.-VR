using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

    public static Node State = new Node();
    public static List<Photo> Photos = new List<Photo>();
    public static List<Node> Nodes = new List<Node>();

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
        List<Photo> photos = new List<Photo>();
        List<Node> nodes = new List<Node>();

        TextAsset textAsset = Resources.Load<TextAsset>("map");

        var document = new XmlDocument();
        document.LoadXml(textAsset.text);

        XmlElement? root = document.DocumentElement;

        foreach (XmlNode xNode in root)
        {
            foreach (XmlNode nodenode in xNode.ChildNodes)
            {
                Photo photo = new Photo();
                Node node = new Node();

                foreach (XmlNode child in nodenode.ChildNodes)
                {

                    if (child.Name == "id") photo.Id = child.InnerText;
                    if (child.Name == "path") photo.Path = child.InnerText;

                    if (child.Name == "main") node.Main = child.InnerText;
                    if (child.Name == "left") node.Left = child.InnerText != "null" ? child.InnerText : null;
                    if (child.Name == "right") node.Right = child.InnerText != "null" ? child.InnerText : null;
                    if (child.Name == "front") node.Front = child.InnerText != "null" ? child.InnerText : null;
                    if (child.Name == "back") node.Back = child.InnerText != "null" ? child.InnerText : null;
                }

                if (photo.Id != null) photos.Add(photo);
                if (node.Main != null) nodes.Add(node);
            }
        }

        Photos = photos;
        Nodes = nodes;
        State = nodes[0];

        foreach (var photo in Photos)
        {
            Debug.Log($"{photo.Path}");
        }

        foreach (var node in Nodes)
        {
            Debug.Log($"{node.Main}");
        }
    }
}
