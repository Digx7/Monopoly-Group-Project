using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnums : MonoBehaviour
{
}
public enum GlobalLUT {Purple, LightBlue, Pink, Orange, Red, Yellow, Green, DarkBlue, Player1, Player2, Player3, Player4, DefaultPanel}

public enum GameState {NONE, Start, SetTurnOrder, Run, GameFinished}
public enum TurnState {TurnStart, Actions_1, Roll, Move, Resolve, Actions_2, TurnEnd}

public enum PropertyColor {Purple, LightBlue, Pink, Orange, Red, Yellow, Green, DarkBlue};

public enum ResolveState {Begin, Property_Utility_or_RailRoad, Card, Fine, Reward, GoToJail, Nothing, End}
