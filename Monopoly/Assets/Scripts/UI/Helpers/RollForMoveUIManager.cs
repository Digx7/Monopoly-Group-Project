using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollForMoveUIManager : MonoBehaviour
{
    public GameObject diceRollerUIPrefab;
    public GameObject diceRollerUIPrefabParent;

    private TurnManager turnManager;
    private PlayerManager playerManager;
    private Roll rollData;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnEnable()
    {
        SpawnDiceRollerUI();
    }

    private void SpawnDiceRollerUI()
    {
        GameObject uIObject = Instantiate(diceRollerUIPrefab, diceRollerUIPrefabParent.transform);
        DiceRollerUI rollerUI = uIObject.GetComponent<DiceRollerUI>();

        rollerUI.SetUp("Player " + turnManager.CurrentPlayerNumber() + "\nroll to move");
        rollerUI.OnClickContinue.AddListener(BufferRollData);
    }

    public void BufferRollData(Roll roll)
    {
        rollData = roll;
        // pass data along to game piece movement
        playerManager.MovePlayer(turnManager.CurrentPlayerIndex(), roll);


        // change states to move
        turnManager.ChangeTurnState(TurnState.Move);
    }

}
