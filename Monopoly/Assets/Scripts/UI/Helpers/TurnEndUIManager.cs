using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEndUIManager : MonoBehaviour
{
    private TurnManager turnManager;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    private void OnEnable()
    {
        // Set to next players turn
        turnManager.NextTurn();

        turnManager.ChangeTurnState(TurnState.TurnStart);
    }
}
