using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameRun : MonoBehaviour
{
    public GameObject TurnStartUI;
    public GameObject ActionsUI;
    public GameObject RollUI;
    public GameObject MoveUI;
    public GameObject ResolveUI;
    public GameObject GlobalUI;
    public GameObject TurnEndUI;

    private TurnManager turnManager;

    private void Awake()
    {
        
    }

    public void Start()
    {
        EnableTurnStartUI();
    }

    private void OnEnable()
    {
        turnManager = FindObjectOfType<TurnManager>();

        turnManager.OnTurnStart.AddListener(EnableTurnStartUI);
        turnManager.OnTurnStart.AddListener(DisableTurnEndUI);

        turnManager.OnActions_1_Begin.AddListener(EnableActionsUI);
        turnManager.OnActions_1_Begin.AddListener(DisableTurnStartUI);

        turnManager.OnActions_1_End.AddListener(DisableActionsUI);


        turnManager.OnRollBegin.AddListener(EnableRollUI);
        turnManager.OnRollEnd.AddListener(DisableRollUI);

        turnManager.OnMoveBegin.AddListener(EnableMoveUI);
        turnManager.OnMoveEnd.AddListener(DisableMoveUI);

        turnManager.OnResolveBegin.AddListener(EnableResolveUI);
        turnManager.OnResolveEnd.AddListener(DisableResolveUI);

        turnManager.OnActions_2_Begin.AddListener(EnableActionsUI);
        turnManager.OnActions_2_End.AddListener(DisableActionsUI);

        turnManager.OnTurnEnd.AddListener(EnableTurnEndUI);
    }

    private void OnDisable()
    {
        turnManager.OnActions_1_Begin.RemoveListener(EnableActionsUI);
        turnManager.OnActions_1_End.RemoveListener(DisableActionsUI);

        turnManager.OnRollBegin.RemoveListener(EnableRollUI);
        turnManager.OnRollEnd.RemoveListener(DisableRollUI);

        turnManager.OnMoveBegin.RemoveListener(EnableMoveUI);
        turnManager.OnMoveEnd.RemoveListener(DisableMoveUI);

        turnManager.OnResolveBegin.RemoveListener(EnableResolveUI);
        turnManager.OnResolveEnd.RemoveListener(DisableResolveUI);

        turnManager.OnActions_2_Begin.RemoveListener(EnableActionsUI);
        turnManager.OnActions_2_End.RemoveListener(DisableActionsUI);
    }

    private void EnableTurnStartUI()
    {
        TurnStartUI.SetActive(true);
    }

    private void EnableTurnEndUI()
    {
        TurnEndUI.SetActive(true);
    }

    private void EnableActionsUI()
    {
        ActionsUI.SetActive(true);
        ActionsUIManager actionsUIManager = ActionsUI.GetComponent<ActionsUIManager>();
        actionsUIManager.Setup(turnManager.CurrentTurnState, turnManager.CurrentPlayerNumber());
    }

    private void EnableRollUI()
    {
        RollUI.SetActive(true);
        Debug.Log("EnableRollUI");
    }

    private void EnableMoveUI()
    {
        MoveUI.SetActive(true);
    }

    private void EnableResolveUI()
    {
        ResolveUI.SetActive(true);
    }

    private void EnableGlobalUI()
    {
        GlobalUI.SetActive(true);
    }

    private void DisableTurnStartUI()
    {
        TurnStartUI.SetActive(false);
    }

    private void DisableTurnEndUI()
    {
        TurnEndUI.SetActive(false);
    }

    private void DisableActionsUI()
    {
        ActionsUI.SetActive(false);
        Debug.Log("DisableActionsUI");
    }

    private void DisableRollUI()
    {
        RollUI.SetActive(false);
    }

    private void DisableMoveUI()
    {
        MoveUI.SetActive(false);
    }

    private void DisableResolveUI()
    {
        ResolveUI.SetActive(false);
    }

    private void DisableGlobalUI()
    {
        GlobalUI.SetActive(false);
    }
}
