using UnityEngine;
using System.Collections.Generic;
public class Decks
{
    
}

[System.Serializable]
public class Deck
{
    public string name;
    public List<CardDefinition> cardDefinitions = new List<CardDefinition>();

    public List<CardInstance> BuildDeck()
    {
        List<CardInstance> deck = new List<CardInstance>();

        foreach (var def in cardDefinitions)
        {
            for (int i = 0; i < def.copies; i++)
            {
                deck.Add(new CardInstance(def));
            }
        }

        return deck;
    }
}