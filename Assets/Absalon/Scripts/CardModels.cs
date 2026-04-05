using UnityEngine;
//poopy butt in the face
public class CardModels
{
    
}

[System.Serializable]
public class CardDefinition
{
    public string cardName;
    public int copies;
    public Tag tag = Tag.Undefined;
    public Tag subTag;

    public enum Tag
    {
        Starter,
        Extender,
        Disruption,
        Brick,
        SubStarter,
        SubExtender,
        SubDisruption,
        SubBrick,
        Undefined
    }
}

public class CardInstance
{
    public CardDefinition.Tag tag;
    public CardDefinition.Tag subTag;

    public CardInstance(CardDefinition def)
    {
        tag = def.tag;
        subTag = def.subTag;
    }
}