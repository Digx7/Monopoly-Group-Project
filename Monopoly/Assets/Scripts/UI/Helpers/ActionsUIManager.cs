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
    public GameObject messageScreenPrefab;

    private PlayerManager playerManager;
    private TurnManager turnManager;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
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

    public void OnGiveUpClick()
    {
        GameObject uiObject = Instantiate(messageScreenPrefab, transform.parent);
        MessageScreen messageScreen = uiObject.GetComponent<MessageScreen>();

        string message = "Player " + turnManager.CurrentPlayerNumber() + " Gave Up!\nThey are out of the game";
        messageScreen.Setup(message);
        messageScreen.OnContinue.AddListener(OnGiveUp);
    }

    private void OnGiveUp()
    {
        playerManager.BankruptPlayer(turnManager.CurrentPlayerIndex());
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
