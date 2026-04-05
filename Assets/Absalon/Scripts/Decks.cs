using UnityEngine;
using System.Collections.Generic;
public class Decks
{
    
}

public class Deck
{
    public List<CardDefinition> cardDefinitions;

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