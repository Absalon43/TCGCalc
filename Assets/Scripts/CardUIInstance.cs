using TMPro;
using UnityEngine;

public class CardUIInstance : MonoBehaviour
{
    public CardDefinition cardDefinition;
    private Deck parentDeck;
    
    [Header("UI elements")] public TMP_Text name;
    public TMP_Text count, tag, subTag;

    public void InitializeCard(CardDefinition newCardDefinition, Deck deck)
    {
        this.cardDefinition = newCardDefinition;
        parentDeck = deck;

        UpdateCardUI();
    }

    // Update is called once per frame
    void UpdateCardUI()
    {
        name.text = cardDefinition.cardName;
        count.text = cardDefinition.copies.ToString();
        tag.text = cardDefinition.tag.ToString();
        subTag.text = cardDefinition.subTag.ToString();
    }

    public void DeleteCard()
    {
        parentDeck.cardDefinitions.Remove(this.cardDefinition);
        Destroy(this.gameObject);
    }
}
