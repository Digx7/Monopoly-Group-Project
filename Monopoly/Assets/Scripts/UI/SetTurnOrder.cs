using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTurnOrder : MonoBehaviour
{
    public GameObject diceRollerUIPrefab;
    public GameObject diceRollerUIPrefabParent;

    private GameManager gameManager;
    private TurnManager turnManager;
    private PlayerManager playerManager;

    private int[] buffer = new int[4];
    private int playerIndex = 0;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        turnManager = FindObjectOfType<TurnManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Start()
    {
        // for each player in playerManager cue a dice roll
        // sort players in turnManager by dice roll, highest to lowest

        SpawnDiceRollerUI();
    }

    private void SpawnDiceRollerUI()
    {
        GameObject uIObject = Instantiate(diceRollerUIPrefab, diceRollerUIPrefabParent.transform);
        DiceRollerUI rollerUI = uIObject.GetComponent<DiceRollerUI>();

        int playerNumber = playerIndex + 1;

        rollerUI.SetUp("Player " + playerNumber + " roll to see who goes first", true);
        rollerUI.OnClickContinue.AddListener(BufferRollData);
    }

    public void BufferRollData(Roll roll)
    {
        buffer[playerIndex] = roll.total;

        CheckIfShouldRollAgain();
    }

    private void CheckIfShouldRollAgain()
    {
        playerIndex++;
        
        if(playerIndex >= playerManager.players.Count)
        {
            Debug.Log("All players have rolled");
            ProcessData();
        }
        else
        {
            SpawnDiceRollerUI();
        }
    }

    private void ProcessData()
    {
        int[] processed = new int[4];

        for (int i = 0; i < processed.Length; i++)
        {
            int largestNum = 0;
            int largestIndex = -1;
            
            for (int j = 0; j < buffer.Length; j++)
            {
                if(buffer[j] > largestNum)
                {
                    largestNum = buffer[j];
                    largestIndex = j;
                }
            }
            processed[i] = largestIndex;
            if(largestIndex > -1) buffer[largestIndex] = 0;
        }

        turnManager.SetTurnOrder(processed);

        gameManager.ChangeGameState(GameState.Run);
    }


}
