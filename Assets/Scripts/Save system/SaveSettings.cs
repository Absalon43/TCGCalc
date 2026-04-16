using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    public SaveSlot activeSaveSlot;
    
    void Start()
    {
        SaveSystem.currentSaveSlot = activeSaveSlot;
    }

    public void SaveDeck(Deck deck, string name)
    {
        SaveSystem.SaveData(deck, name);
    }

    public Deck GetDeckFromSave(string name)
    {
        Deck deck = SaveSystem.LoadData<Deck>(name);
        
        return deck;
    }
}
