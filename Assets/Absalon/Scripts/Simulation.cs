using UnityEngine;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
public class SimulationResult
{
    public Dictionary<CardDefinition.Tag, int> tagHits = new Dictionary<CardDefinition.Tag, int>();
}

public static class Simulation
{
    public static SimulationResult Run(Deck deck, int iterations)
    {
        SimulationResult result = new SimulationResult();

        for (int i = 0; i < iterations; i++)
        {
            var runtimeDeck = deck.BuildDeck();
            Shuffle(runtimeDeck);

            var hand = DrawHand(runtimeDeck, 5);

            HashSet<CardDefinition.Tag> seenTags = new HashSet<CardDefinition.Tag>();

            foreach (var card in hand)
            {
                if (card.tag != CardDefinition.Tag.Undefined)
                    seenTags.Add(card.tag);

                
                if (card.subTag != CardDefinition.Tag.Undefined)
                    seenTags.Add(card.subTag);
                
            }

            foreach (var tag in seenTags)
            {
                if (!result.tagHits.ContainsKey(tag))
                    result.tagHits[tag] = 0;

                result.tagHits[tag]++;
            }
        }

        return result;
    }

    static void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }

    static List<CardInstance> DrawHand(List<CardInstance> deck, int handSize)
    {
        return deck.GetRange(0, handSize);
    }
}