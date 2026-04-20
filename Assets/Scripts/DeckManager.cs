using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Deck activeDeck;

    [Header("Card info fields")] public TMP_InputField nameField;
    public TMP_InputField copiesCountField;
    public TMP_Dropdown mainTagDropDown, subTagDropDown;

    [Header("Deck display")] public GameObject cardUIPrefab;
    public GameObject deckViewContent;

    private void Start()
    {
        activeDeck = new Deck();
        SaveSystem.SaveData<Deck>(activeDeck, activeDeck.name);
    }
    
    /*
    public void SaveDeck()
    {
    }
    */

    public void AddCard()
    {
        CardDefinition newCard = new CardDefinition();

        newCard.cardName = nameField.text;

        // Safety check -> er copies field faktisk et tal
        string count = copiesCountField.text;
        if (int.TryParse(count, out int val))
        {
            if (val <= 3 && val > 0)
            {
                newCard.copies = val;
            }
            else
            {
                Debug.Log("Copies smaller than 0 or bigger than 3, cannot create card");
                return;
            }
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

        activeDeck.cardDefinitions.Add(newCard);
        UpdateDeckUI(newCard);
        SaveSystem.SaveData<Deck>(activeDeck, activeDeck.name);
    }

    public void UpdateDeckUI(CardDefinition card)
    {
        GameObject cardObj = Instantiate(cardUIPrefab, deckViewContent.transform);
        cardObj.GetComponent<CardUIInstance>().InitializeCard(card, activeDeck);
    }
}
