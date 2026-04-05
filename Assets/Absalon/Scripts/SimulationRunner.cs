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
    public CardDefinition[] cards;
   
    public void RunSimulation()
    {
        deckSize = 0;
        Deck deck = new Deck();
        /*deck.cardDefinitions = new List<CardDefinition>()
            {
            new CardDefinition { cardName = "Starter A", copies = 3, tag = "Starter", subTag = "" },
            new CardDefinition { cardName = "Extender A", copies = 3, tag = "Extender", subTag = "" },
            new CardDefinition { cardName = "Brick", copies = 2, tag = "Brick", subTag = "" },
            new CardDefinition { cardName = "Generic", copies = 32, tag = "Filler", subTag = "" }
            };
        */

        deck.cardDefinitions = new List<CardDefinition>();
        
        foreach(var card in cards)
        {
            deck.cardDefinitions.Add(card);
            deckSize+=card.copies; 
        }
        
        int iterations = 100000;

        result = Simulation.Run(deck, iterations);

        foreach (var kvp in result.tagHits)
        {
            float percent = (float)kvp.Value / iterations * 100f;
            Debug.Log($"{kvp.Key}: {percent:F2}%");
        }

        NewResults.Invoke();
    }   
}
