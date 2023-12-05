using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public List<Player> players;

    private Board board;
    private GameManager gameManager;
    private TurnManager turnManager;

    public UnityEvent<int,int> OnPlayerMoneyChange;

    public void Awake()
    {
        board = FindObjectOfType<Board>();
        gameManager = FindObjectOfType<GameManager>();
        turnManager = FindObjectOfType<TurnManager>();
    }

    public void AddPlayer(PlayerStartData newData)
    {
        Player newPlayer = new Player();

        newPlayer.number = newData.number;
        newPlayer.name = newData.name;
        newPlayer.avatar = newData.avatar;
        
        newPlayer.money = 1500;

        players.Add(newPlayer);
    }

    public void MovePlayer(int playerID, Roll moveRoll)
    {
        Debug.Log("Player " + (playerID + 1) + "\nshould move " + moveRoll.total + " spaces");

        Debug.Log("Player " + (playerID + 1) + "\n starts at location " + players[playerID].location);

        // update player location
        players[playerID].location += moveRoll.total;
        if(players[playerID].location >= board.spacesParent.transform.childCount)
        {
            players[playerID].location-= board.spacesParent.transform.childCount;
        }

        Debug.Log("Player " + (playerID + 1) + "\n ends at location " + players[playerID].location);

        // move player avatar
        board.CueAvatarMove(playerID, moveRoll.total);
    }

    public void ChargePlayer(int playerID, int amount)
    {
        players[playerID].money -= amount;
        OnPlayerMoneyChange.Invoke(playerID, players[playerID].money);
    }

    public void PayPlayer(int playerID, int amount)
    {
        players[playerID].money += amount;
        OnPlayerMoneyChange.Invoke(playerID, players[playerID].money);
    }

    public void GivePlayerProperty(int playerID, Property property)
    {
        // accesses player using playerID, then finds the correct ownedPropertySets with the correct color, lastly adds the property to that
        players[playerID].ownedPropertySets.Find(i => i.color == property.propertyColorSet).Add(property);   
        // Player player = players[playerID];
        // PropertyColorSet propertyColorSet = player.ownedPropertySets.Find(i => i.color == property.propertyColorSet);
        // propertyColorSet.Add(property);
    }

    public void RemovePlayersProperty(int playerID, Property property)
    {
        // accesses player using playerID, then finds the correct ownedPropertySets with the correct color, lastly removes the property from that
        players[playerID].ownedPropertySets.Find(i => i.color == property.propertyColorSet).Remove(property);
    }

    public void GivePlayerRailroad(int playerID, Railroad railroad)
    {
        if(players[playerID].railroadList.Contains(railroad)) return;

        players[playerID].railroadList.Add(railroad);
    }

    public void RemovePlayerRailroad(int playerID, Railroad railroad)
    {
        if(!players[playerID].railroadList.Contains(railroad)) return;

        players[playerID].railroadList.Remove(railroad);
    }

    public void GivePlayerUtility(int playerID, Utility utility)
    {
        if(players[playerID].utilityList.Contains(utility)) return;

        players[playerID].utilityList.Add(utility);
    }

    public void RemovePlayerUtility(int playerID, Utility utility)
    {
        if(!players[playerID].utilityList.Contains(utility)) return;

        players[playerID].utilityList.Remove(utility);
    }

    public void BankruptPlayer(int playerID)
    {
        players[playerID].isBankrupt = true;
        turnManager.OnPlayerLose(playerID);
        gameManager.OnPlayerLose(playerID);
    }
}
