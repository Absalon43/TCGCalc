using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.Events;
public class SimulationRunner : MonoBehaviour
{
    public Deck deck;
    public readonly int iterations = 100000;

    public UnityEvent NewResults;
    [HideInInspector] public SimulationResult result;

    public int deckSize;
    public List<CardDefinition> cards;
   
    public void RunSimulation()
    {
        deckSize = 0;
        Deck deck = new Deck();
        deck.cardDefinitions = new List<CardDefinition>();
        
        foreach(var card in cards)
        {
            deck.cardDefinitions.Add(card);
            deckSize+=card.copies; 
        }
        
        result = Simulation.Run(deck, iterations);

        foreach (var kvp in result.tagHits)
        {
            float percent = (float)kvp.Value / iterations * 100f;
            Debug.Log($"{kvp.Key}: {percent:F2}%");
        }

        NewResults.Invoke();
    }

    private CardDefinition newCard;

    public void AddCard(string name, int copies, CardDefinition.Tag tag, CardDefinition.Tag subTag)
    {
        newCard = new CardDefinition();
        newCard.cardName = name;
        newCard.copies = copies;
        newCard.tag = tag;
        newCard.subTag = subTag;
        
        cards.Add(newCard);
    }
}
