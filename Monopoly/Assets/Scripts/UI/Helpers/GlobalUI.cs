using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GlobalUI : MonoBehaviour
{
    public GameObject playerMoneyUIPrefab;
    public GameObject playerMoneyUIPrefabParent;
    
    public TextMeshProUGUI currentPlayerTurn;
    public Image currentPlayerTurnPanel;

    private TurnManager turnManager;
    private GlobalColorLUT globalColorLUT;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    private void OnEnable()
    {
        RenderCurrentTurn();
        RenderPlayerMoneyUI();

        turnManager.OnTurnStart.AddListener(RenderCurrentTurn);
    }

    private void OnDisable()
    {
        turnManager.OnTurnStart.AddListener(RenderCurrentTurn);
    }

    private void RenderPlayerMoneyUI()
    {
        int[] order = turnManager.GetTurnOrder();

        for (int i = 0; i < order.Length; i++)
        {
            if(order[i] == -1) break;
            
            GameObject obj = Instantiate(playerMoneyUIPrefab, playerMoneyUIPrefabParent.transform);
            PlayerMoneyUI playerMoneyUI = obj.GetComponent<PlayerMoneyUI>();

            playerMoneyUI.Setup(order[i]);
        }
    }

    private void RenderCurrentTurn()
    {
        currentPlayerTurn.text = "Player " + turnManager.CurrentPlayerNumber() + "'s Turn";
        currentPlayerTurnPanel.color = globalColorLUT.GetColor(turnManager.CurrentPlayerIndex());
    }
}
