using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    private List<Deck> myDecks;
    public Deck activeDeck;

    [Header("Card info fields")] public TMP_InputField nameField;
    public TMP_InputField copiesCountField;
    public TMP_Dropdown mainTagDropDown, subTagDropDown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddCard()
    {
        CardDefinition newCard = new CardDefinition();

        newCard.cardName = nameField.text;

        // Safety check -> er copies field faktisk et tal
        string count = copiesCountField.text;
        if (int.TryParse(count, out int val))
        {
            newCard.copies = val;
        }
        else
        {
            Debug.Log("Copies field does not contain integer, cannot create card");
            return;
        }

        string selectedMainTag = mainTagDropDown.options[mainTagDropDown.value].text;
        if (Enum.TryParse(selectedMainTag, out CardDefinition.Tag mainTag))
        {
            newCard.tag = mainTag;
        }
        else
        {
            Debug.Log($"Invalid main tag: {selectedMainTag}. Defaulting to Undefined.");
            newCard.tag = CardDefinition.Tag.Undefined;
        }

        string selectedSubTag = subTagDropDown.options[subTagDropDown.value].text;
        if (Enum.TryParse(selectedMainTag, out CardDefinition.Tag subTag))
        {
            newCard.tag = subTag;
        }
        else
        {
            Debug.Log($"Invalid main tag: {selectedSubTag}. Defaulting to Undefined.");
            newCard.tag = CardDefinition.Tag.Undefined;
        }

    }
}
