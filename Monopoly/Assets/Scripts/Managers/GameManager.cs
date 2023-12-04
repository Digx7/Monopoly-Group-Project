using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private GameState gameState = GameState.NONE;
    public GameState CurrentGameState {get{return gameState;}}

    public UnityEvent<GameState> OnGameStateChange;
    
    public UnityEvent OnStartBegin;
    public UnityEvent OnStartEnd;
    public UnityEvent OnSetTurnOrderBegin;
    public UnityEvent OnSetTurnOrderEnd;
    public UnityEvent OnRunBegin;
    public UnityEvent OnRunEnd;
    public UnityEvent OnGameFinishedBegin;
    public UnityEvent OnGameFinishedEnd;

    public void Awake()
    {
        // Initialize
    }

    public void Start()
    {
        ChangeGameState(GameState.Start);
    }

    public void ChangeGameState(GameState newState)
    {
        if(gameState == newState) {return;}
        
        switch (gameState)
        {
            case GameState.Start:
                OnStartEnd.Invoke();
                break;
            case GameState.SetTurnOrder:
                OnSetTurnOrderEnd.Invoke();
                break;
            case GameState.Run:
                OnRunEnd.Invoke();
                break;
            case GameState.GameFinished:
                OnGameFinishedEnd.Invoke();
                break;
            default:
                break;
        }
        
        gameState = newState;
        OnGameStateChange.Invoke(gameState);

        switch (gameState)
        {
            case GameState.Start:
                OnStartBegin.Invoke();
                break;
            case GameState.SetTurnOrder:
                OnSetTurnOrderBegin.Invoke();
                break;
            case GameState.Run:
                OnRunBegin.Invoke();
                break;
            case GameState.GameFinished:
                OnGameFinishedBegin.Invoke();
                break;
            default:
                break;
        }
    }
}
