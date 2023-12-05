using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    private TurnState turnState = TurnState.TurnStart;
    public TurnState CurrentTurnState {get{return turnState;}}

    public UnityEvent<TurnState> OnTurnStateChange;

    public UnityEvent OnTurnStart;
    public UnityEvent OnActions_1_Begin;
    public UnityEvent OnActions_1_End;
    public UnityEvent OnRollBegin;
    public UnityEvent OnRollEnd;
    public UnityEvent OnMoveBegin;
    public UnityEvent OnMoveEnd;
    public UnityEvent OnResolveBegin;
    public UnityEvent OnResolveEnd;
    public UnityEvent OnActions_2_Begin;
    public UnityEvent OnActions_2_End;
    public UnityEvent OnTurnEnd;

    private int[] turnOrder;
    public int[] GetTurnOrder(){return turnOrder;}
    private int currentTurn = 0;

    public int CurrentPlayerNumber()
    {
        return turnOrder[currentTurn] + 1;
    }

    public int CurrentPlayerIndex()
    {
        return turnOrder[currentTurn];
    }

    public void OnPlayerLose(int playerID)
    {
        // remove player from turn order

        // first find the index in turnOrder with playerID, which is currentTurn;
        turnOrder[currentTurn] = -1; // sets the turnOrder spot with playerID to -1 meaning no player

        // next we move the elment at that index down the turnOrder Array, suffling everything else one space forward
        for (int i = currentTurn; i < turnOrder.Length - 1; i++)
        {
            int buffer = turnOrder[i];
            turnOrder[i] = turnOrder[i + 1];
            turnOrder[i + 1] = buffer;
        }

        // start a freash new turn
        ChangeTurnState(TurnState.TurnStart);
    }

    public void NextTurn()
    {
        currentTurn++;

        if(currentTurn >= turnOrder.Length)
            currentTurn = 0;
        
        if(turnOrder[currentTurn] == -1)
            currentTurn = 0;
    }

    private void Awake()
    {
        turnOrder = new int[4];
    }

    public void ChangeTurnState(TurnState newState)
    {
        if(turnState == newState) return;

        switch (turnState)
        {
            case TurnState.Actions_1:
                OnActions_1_End.Invoke();
                break;
            case TurnState.Roll:
                OnRollEnd.Invoke();
                break;
            case TurnState.Move:
                OnMoveEnd.Invoke();
                break;
            case TurnState.Resolve:
                OnResolveEnd.Invoke();
                break;
            case TurnState.Actions_2:
                OnActions_2_End.Invoke();
                break;
            default:
                break;
        }

        Debug.Log("Last Turn State was: " + turnState);
        
        turnState = newState;
        OnTurnStateChange.Invoke(turnState);

        switch (turnState)
        {
            case TurnState.TurnStart:
                OnTurnStart.Invoke();
                break;
            case TurnState.Actions_1:
                OnActions_1_Begin.Invoke();
                break;
            case TurnState.Roll:
                OnRollBegin.Invoke();
                break;
            case TurnState.Move:
                OnMoveBegin.Invoke();
                break;
            case TurnState.Resolve:
                OnResolveBegin.Invoke();
                break;
            case TurnState.Actions_2:
                OnActions_2_Begin.Invoke();
                break;
            case TurnState.TurnEnd:
                OnTurnEnd.Invoke();
                break;
            default:
                break;
        }

        Debug.Log("New Turn State is: " + turnState);
    }

    public void SetTurnOrder(int[] order)
    {
        int i = 0;
        if(order.Length == 0) return;

        do
        {
            turnOrder[i] = order[i];
            ++i;
        } while (i < order.Length);

        Debug.Log("Turn Order is...");

        for (int j = 0; j < order.Length; j++)
        {
            Debug.Log("Player " + (order[j] + 1) );
        }
    }


}
