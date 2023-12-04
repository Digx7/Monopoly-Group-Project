using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnStartUIManager : MonoBehaviour
{
    public TextMeshProUGUI prompt;
    private TurnManager turnManager;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    private void OnEnable()
    {
        prompt.text = "Player " + turnManager.CurrentPlayerNumber() + "\nIts your turn";
    }

    public void OnClickStart()
    {
        turnManager.ChangeTurnState(TurnState.Actions_1);
    }
}
