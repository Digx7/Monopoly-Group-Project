using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ManageProperties : MonoBehaviour
{
    public GameObject root;
    public GameObject scrollViewContent;
    public GameObject propertySetPrefab;
    public GameObject propertySetPrefabParent;
    public GameObject recieveScreenPrefab;
    public GameObject payScreenPrefab;

    private PlayerManager playerManager;
    private TurnManager turnManager;

    private Tile bufferedTile;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    private void OnEnable()
    {
        Render();
    }

    private void OnDisable()
    {
        Wipe();
    }

    private void Render()
    {
        root.SetActive(true);
        
        Player player = playerManager.players[turnManager.CurrentPlayerIndex()];

        foreach (PropertyColorSet propertyColorSet in player.ownedPropertySets)
        {
            if(propertyColorSet.owned.Count == 0) continue;
            
            GameObject obj = Instantiate(propertySetPrefab, propertySetPrefabParent.transform);
            PropertySet propertySet = obj.GetComponent<PropertySet>();

            propertySet.Setup(propertyColorSet);
            propertySet.OnMortgage.AddListener(OnMortgage);
            propertySet.OnUnMortgage.AddListener(OnUnMortgage);
        }

        // setup railroads
        if(player.railroadList.Count > 0)
        {
            GameObject obj = Instantiate(propertySetPrefab, propertySetPrefabParent.transform);
            PropertySet propertySet = obj.GetComponent<PropertySet>();

            propertySet.Setup(player.railroadList);
            propertySet.OnMortgage.AddListener(OnMortgage);
            propertySet.OnUnMortgage.AddListener(OnUnMortgage);
        }

        // setup utilities
        if(player.utilityList.Count > 0)
        {
            GameObject obj = Instantiate(propertySetPrefab, propertySetPrefabParent.transform);
            PropertySet propertySet = obj.GetComponent<PropertySet>();

            propertySet.Setup(player.utilityList);
            propertySet.OnMortgage.AddListener(OnMortgage);
            propertySet.OnUnMortgage.AddListener(OnUnMortgage);
        }
    }

    private void Wipe()
    {
        foreach (Transform child in propertySetPrefabParent.transform)
        {
            Destroy(child.gameObject);
        }

        root.SetActive(false);
    }

    private void OnMortgage(Tile tile)
    {
        Wipe();
        
        tile.isMortgaged = true;
        
        GameObject uiObject = Instantiate(recieveScreenPrefab, transform);
        RecieveScreen recieveScreen = uiObject.GetComponent<RecieveScreen>();

        string message = "You recieved $" + tile.mortgagePrice + " for mortgaging " + tile.name;
        recieveScreen.Setup(message, turnManager.CurrentPlayerIndex(), tile.mortgagePrice);
        recieveScreen.OnContinue.AddListener(Render);
    }

    private void OnUnMortgage(Tile tile)
    {
        Wipe();

        GameObject uiObject = Instantiate(payScreenPrefab, transform);
        PayScreenUI payScreenUI = uiObject.GetComponent<PayScreenUI>();

        string successMessage = "You paid $" + tile.unmortgagePrice + " to Unmortgage " + tile.name;
        string failedMessage = "You cant afford $" + tile.unmortgagePrice + " to Unmortgage " + tile.name;
        payScreenUI.Setup(successMessage, failedMessage, turnManager.CurrentPlayerIndex(), tile.unmortgagePrice, false);
        payScreenUI.OnSuccess.AddListener(OnPayMortgage);
        payScreenUI.OnFail.AddListener(Render);

        bufferedTile = tile;
    }

    private void OnPayMortgage()
    {
        bufferedTile.isMortgaged = false;
        Render();
    }
}
