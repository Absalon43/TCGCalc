using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardEntryUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI copiesText;
    public TextMeshProUGUI tagText;
    public Button removeButton;

    private CardDefinition card;
    private System.Action<CardDefinition> onRemove;

    public void Setup(CardDefinition card, System.Action<CardDefinition> onRemove)
    {
        this.card = card;
        this.onRemove = onRemove;

        nameText.text = card.cardName;
        copiesText.text = $"x{card.copies}";
        tagText.text = card.tag.ToString();

        removeButton.onClick.AddListener(Remove);
    }

    void Remove()
    {
        onRemove?.Invoke(card);
        Destroy(gameObject);
    }
}