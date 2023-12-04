using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class ActionsUIManager : MonoBehaviour
{
    public TextMeshProUGUI currentTurn;
    public GameObject rollButton;
    public GameObject continueButton;

    private TurnManager turnManager;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    public void Setup(TurnState currentTurnState, int currentPlayerNumber)
    {
        currentTurn.text = "Player " + currentPlayerNumber + "'s \n turn";

        if(currentTurnState == TurnState.Actions_1)
        {
            rollButton.SetActive(true);
            continueButton.SetActive(false);
        }
        else
        {
            rollButton.SetActive(false);
            continueButton.SetActive(true);
        }
    }

    public void OnRollClick()
    {
        turnManager.ChangeTurnState(TurnState.Roll);
    }

    public void OnContinueClick()
    {
        turnManager.ChangeTurnState(TurnState.TurnEnd);
    }
}
