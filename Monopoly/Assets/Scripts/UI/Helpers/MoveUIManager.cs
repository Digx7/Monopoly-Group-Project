using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUIManager : MonoBehaviour
{
    private Board board;
    private TurnManager turnManager;

    private void Awake()
    {
        board = FindObjectOfType<Board>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    private void OnEnable()
    {
        board.MoveAvatar();

        board.OnAvatarMoveEnd.AddListener(OnMoveDone);
    }

    private void OnDisable()
    {
        board.OnAvatarMoveEnd.RemoveListener(OnMoveDone);
    }

    public void OnMoveDone()
    {
        turnManager.ChangeTurnState(TurnState.Resolve);
    }
}
