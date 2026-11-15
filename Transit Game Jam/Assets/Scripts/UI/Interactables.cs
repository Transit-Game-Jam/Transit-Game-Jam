using UnityEngine;
using TMPro;
using System.Collections.Generic;
using NUnit.Framework;

public class Interactables : MonoBehaviour
{
    public TextMeshProUGUI bus;
    public TextMeshProUGUI train;
    public TextMeshProUGUI ferry;
    public TextMeshProUGUI taxi;
    public TextMeshProUGUI bike;

    public TextMeshProUGUI[] interactableTexts;
    public TextMeshProUGUI[] allText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactableTexts = new TextMeshProUGUI[] { bus, train, ferry, taxi, bike };
        allText = FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.InstanceID);
    }

    // Update is called once per frame
    void Update()
    {
        CacheText();
    }

    void CacheText()
    {
        for (int i = 0; i < interactableTexts.Length; i++)
        {
            for (int a = 0; i < allText.Length; i++)
            {
                if (interactableTexts[i].name == allText[a].name)
                {
                    interactableTexts[i] = allText[a];
                }
            }
        }
    }
}
