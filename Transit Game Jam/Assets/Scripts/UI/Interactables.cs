using UnityEngine;
using TMPro;
using System.Collections.Generic;
using NUnit.Framework;

public class Interactables : MonoBehaviour
{
    [Header("Master Interactable Text")]
    public TextMeshProUGUI interactText;

    [Header("Interact Text")]
    public string Bus = new string("Press [SPACE] to enter the Bus");
    public string Train = new string("Press [SPACE] to enter the Train");
    public string Bike = new string("Press [SPACE] to ride the Bike");
    public string Taxi = new string("Press [SPACE] to enter the Taxi");
    public string Ferry = new string("Press [SPACE] to enter the Ferry");

    void Awake()
    {
        interactText.enabled = false;
    }

    public void HandleBusText()
    {
        interactText.enabled = true;
        interactText.color = Color.black;
        interactText.text = Bus;
    }

    public void HandleBikeText()
    {
        interactText.enabled = true;
        interactText.color = Color.black;
        interactText.text = Bike;
    }

    public void HandleTrainText()
    {
        interactText.enabled = true;
        interactText.color = Color.black;
        interactText.text = Train;
    }

    public void HandleTaxiText()
    {
        interactText.enabled = true;
        interactText.color = Color.black;
        interactText.text = Taxi;
    }

    public void HandleFerryText()
    {
        interactText.enabled = true;
        interactText.color = Color.black;
        interactText.text = Ferry;
    }

    public void DisableText()
    {
        interactText.enabled = false;
    }
}
