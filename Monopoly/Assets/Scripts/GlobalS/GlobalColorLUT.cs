using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalColorLUT : MonoBehaviour
{
    public Color purpleProperty;
    public Color lightBlueProperty;
    public Color pinkProperty;
    public Color orangeProperty;
    public Color redProperty;
    public Color yellowProperty;
    public Color greenProperty;
    public Color darkBlueProperty;

    public Color player1;
    public Color player2;
    public Color player3;
    public Color player4;

    public Color UIPanels;

    private TurnManager turnManager;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    public Color GetCurrentPlayerColor()
    {
        if(gameManager.CurrentGameState != GameState.Run)
        {
            return UIPanels;
        }
        return GetColor (turnManager.CurrentPlayerIndex());
    }
    
    public Color GetColor (int playerIndex)
    {
        switch (playerIndex)
        {
            case 0:
                return player1;
                break;
            case 1:
                return player2;
                break;
            case 2:
                return player3;
                break;
            case 3:
                return player4;
                break;
            default:
                return player1;
                break;
        }
    }

    public Color GetColor(GlobalLUT globalLUT)
    {
        switch (globalLUT)
        {
            case GlobalLUT.Purple:
                return purpleProperty;
                break;
            case GlobalLUT.LightBlue:
                return lightBlueProperty;
                break;
            case GlobalLUT.Pink:
                return pinkProperty;
                break;
            case GlobalLUT.Orange:
                return orangeProperty;
                break;
            case GlobalLUT.Red:
                return redProperty;
                break;
            case GlobalLUT.Yellow:
                return yellowProperty;
                break;
            case GlobalLUT.Green:
                return greenProperty;
                break;
            case GlobalLUT.DarkBlue:
                return darkBlueProperty;
                break;
            case GlobalLUT.Player1:
                return player1;
                break;
            case GlobalLUT.Player2:
                return player2;
                break;
            case GlobalLUT.Player3:
                return player3;
                break;
            case GlobalLUT.Player4:
                return player4;
                break;
            default:
                return UIPanels;
                break;
        }
    }

    public Color GetColor(PropertyColor color)
    {
        switch (color)
        {
            case PropertyColor.Purple:
                return purpleProperty;
                break;
            case PropertyColor.LightBlue:
                return lightBlueProperty;
                break;
            case PropertyColor.Pink:
                return pinkProperty;
                break;
            case PropertyColor.Orange:
                return orangeProperty;
                break;
            case PropertyColor.Red:
                return redProperty;
                break;
            case PropertyColor.Yellow:
                return yellowProperty;
                break;
            case PropertyColor.Green:
                return greenProperty;
                break;
            case PropertyColor.DarkBlue:
                return darkBlueProperty;
                break;
            default:
                return purpleProperty;
                break;
        }
    }
}
