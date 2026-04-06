using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;


public class SimulationUI : MonoBehaviour

{
    public SimulationRunner runner;

    public TMP_InputField nameInput;
    public TMP_InputField copiesInput;
    public TMP_Dropdown tagDropdown;
    public TMP_Dropdown subTagDropdown;
    public Transform contentParent;
    public GameObject cardEntryPrefab;

    void RemoveCard(CardDefinition card)
    {
        runner.cards.Remove(card);
    }
    public void OnAddCardPressed()
    {
    string cardName = nameInput.text;

    if (!int.TryParse(copiesInput.text, out int copies))
        {
            Debug.LogError("Invalid number");
            return;
        }

    var tag = (CardDefinition.Tag)tagDropdown.value;
    var subTag = (CardDefinition.Tag)subTagDropdown.value;

    runner.AddCard(cardName, copies, tag, subTag);

    // 👇 Create UI entry
    var card = runner.cards[runner.cards.Count - 1];

    GameObject entry = Instantiate(cardEntryPrefab, contentParent);
    entry.GetComponent<CardEntryUI>().Setup(card, RemoveCard);
    }

    public void OnRunSimulationPressed()
    {
        runner.RunSimulation();
    }

    void Start()
    {
        PopulateDropdowns();
    }

    void PopulateDropdowns()
    {
        tagDropdown.ClearOptions();
        subTagDropdown.ClearOptions();

        var options = System.Enum.GetNames(typeof(CardDefinition.Tag));

        tagDropdown.AddOptions(new System.Collections.Generic.List<string>(options));
        subTagDropdown.AddOptions(new System.Collections.Generic.List<string>(options));
    }
}

[System.Serializable]
public class DeckData : MonoBehaviour
{
    public SimulationRunner runner;
    public void SaveDeck()
    {
        DeckData data = new DeckData();
        data.cards = runner.cards;

        string json = JsonUtility.ToJson(data, true);

        string path = Application.persistentDataPath + "/deck.json";
        File.WriteAllText(path, json);

        Debug.Log("Saved to: " + path);
    }
    public List<CardDefinition> cards;

    public void LoadDeck()
    {
        string path = Application.persistentDataPath + "/deck.json";

        if (!File.Exists(path))
        {
            Debug.LogError("No save file found");
            return;
        }

        string json = File.ReadAllText(path);
        DeckData data = JsonUtility.FromJson<DeckData>(json);

        runner.cards = data.cards;

        //RefreshUI(); Overvej lige!!
    }
}

