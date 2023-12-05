using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStructs : MonoBehaviour
{
}



[System.Serializable]
public struct Card
{
    public Sprite cardSprite;
    public WarningAndErrorCardTypes cardType;
    public int amount;
}

[System.Serializable]
public struct BoardMove
{
    public int playerID;
    public int startingBoardLocation;
    public int endingBoardLocation;
}

[System.Serializable]
public struct PlayerStartData
{
    public int number;
    public string name;
    public int avatar;
}

[System.Serializable]
public struct Roll
{
    public int total;
    public bool isDouble;
}

[System.Serializable]
public struct PropertyRentPrices
{
    public int rent;
    public int rentWithColorSet;
    public int rentWith_1_Computer;
    public int rentWith_2_Computers;
    public int rentWith_3_Computers;
    public int rentWith_4_Computers;
    public int rentWithServer;

    public int computerCost;
    public int serverCost;
}
