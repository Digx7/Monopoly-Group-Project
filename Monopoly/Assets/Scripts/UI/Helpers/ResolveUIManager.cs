using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolveUIManager : MonoBehaviour
{
    private TurnManager turnManager;
    private Board board;
    private ResolveState resolveState;

    public GameObject buyScreenPrefab;
    public GameObject payScreenPrefab;
    public GameObject messageScreenPrefab;
    public GameObject cardScreenPrefab;

    private PlayerManager playerManager;
    private DeckManagers deckManager;

    private Tile bufferedTile;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        board = FindObjectOfType<Board>();
        playerManager = FindObjectOfType<PlayerManager>();
        deckManager = FindObjectOfType<DeckManagers>();
    }

    private void OnEnable()
    {
        resolveState = ResolveState.Begin;

        Tile tile = board.GetAvatarsCurrentTile(turnManager.CurrentPlayerIndex());

        if(tile is Property)
        {
            Debug.Log("Player " + turnManager.CurrentPlayerNumber() + " landed on the PROPERTY tile " + tile.name);

            ResolvePropertyRailRoadUtility( tile );
        }
        else if(tile is Railroad)
        {
            Debug.Log("Player " + turnManager.CurrentPlayerNumber() + " landed on the RAILROAD tile " + tile.name);

            ResolvePropertyRailRoadUtility( tile );
        }
        else if(tile is Utility)
        {
            Debug.Log("Player " + turnManager.CurrentPlayerNumber() + " landed on the UTILITY tile " + tile.name);

            ResolvePropertyRailRoadUtility( tile );
        }
        else if(tile is FineTile)
        {
            ResolveFineTile( (FineTile)tile );
        }
        else if(tile is CardTile)
        {
            ResolveCardTile( (CardTile)tile );
        }
        else if(tile is MessageTile)
        {
            ResolveMessageTile( (MessageTile)tile );
        }
        else if(tile is Special)
        {
            Debug.Log("Player " + turnManager.CurrentPlayerNumber() + " landed on the SPECIAL tile " + tile.name);

            ResolveSpecial( (Special)tile );
        }
    }

    private void ResolvePropertyRailRoadUtility(Tile tile)
    {
        resolveState = ResolveState.Property_Utility_or_RailRoad;

        if(tile.isOwned)
        {
            if(tile.isMortgaged)
            {
                // END
                Debug.Log("tile " + tile.name + " is Mortgaged and player " + turnManager.CurrentPlayerNumber() + " should end turn");
                GameObject uiObject = Instantiate(messageScreenPrefab, transform);
                MessageScreen messageScreen = uiObject.GetComponent<MessageScreen>();

                string message = "" + tile.name + " is currently mortgaged";
                messageScreen.Setup(message);
                messageScreen.OnContinue.AddListener(EndResolve);
            }
            else
            {
                // PAY RENT
                Debug.Log("tile " + tile.name + " is owned by player "  + (tile.ownerID + 1) + "and player " + turnManager.CurrentPlayerNumber() + " needs to pay rent");

                GameObject uiObject = Instantiate(payScreenPrefab, transform);
                PayScreenUI payScreenUI = uiObject.GetComponent<PayScreenUI>();

                // int rent = tile.propertyRentPrices.rent; //TODO

                int rent = 0;

                if(tile is Property)
                {
                    Property property = (Property)tile;
                    rent = property.CalculateRent();
                }
                else if(tile is Railroad)
                {
                    Railroad railroad = (Railroad)tile;
                    rent = railroad.CalculateRent();
                }
                else if(tile is Utility)
                {
                    Utility utility = (Utility)tile;
                    rent = utility.CalculateRent();
                }

                string successMessage = "You paid player " + (tile.ownerID + 1) + " $" + rent + " for landing on " + tile.name;
                string failedMessage = "You cant afford $" + rent + " for rent";
                payScreenUI.Setup(successMessage, failedMessage, turnManager.CurrentPlayerIndex(), rent, true);
                payScreenUI.OnPay.AddListener(OnPayRent);
                payScreenUI.OnFail.AddListener(OnDeclareBankrupt);

                bufferedTile = tile;
            }
        }
        else
        {
            //ASK TO BUY
            Debug.Log("tile " + tile.name + " is available for sale and player " + turnManager.CurrentPlayerNumber() + " can try to buy it");

            GameObject uiObject = Instantiate(buyScreenPrefab, transform);
            BuyScreen buyScreen = uiObject.GetComponent<BuyScreen>();

            buyScreen.Setup(tile, turnManager.CurrentPlayerIndex());
            buyScreen.OnSuccess.AddListener(OnBuy);
            buyScreen.OnFail.AddListener(EndResolve);
        }
    }

    private void ResolveFineTile(FineTile fineTile)
    {
        GameObject uiObject = Instantiate(payScreenPrefab, transform);
        PayScreenUI payScreenUI = uiObject.GetComponent<PayScreenUI>();

        string successMessage = "You paid $" + fineTile.cost + " for landing on " + fineTile.name;
        string failedMessage = "You cant afford $" + fineTile.cost + " for rent";
        payScreenUI.Setup(successMessage, failedMessage, turnManager.CurrentPlayerIndex(), fineTile.cost, true);
        payScreenUI.OnPay.AddListener(OnPayFine);
        payScreenUI.OnFail.AddListener(OnDeclareBankrupt);

        bufferedTile = (Tile)fineTile;
    }

    private void ResolveCardTile(CardTile cardTile)
    {
        // Debug.Log("tile " + cardTile.name + " is a card tile and not implemented yet :(");
        // GameObject uiObject = Instantiate(messageScreenPrefab, transform);
        // MessageScreen messageScreen = uiObject.GetComponent<MessageScreen>();

        // string message = "" + cardTile.name + " is a card tile and not implemented yet :(";
        // messageScreen.Setup(message);
        // messageScreen.OnContinue.AddListener(EndResolve);

        Card card = deckManager.DrawCard(cardTile.drawCardType);

        GameObject uiObject = Instantiate(cardScreenPrefab, transform);
        CardScreen cardScreen = uiObject.GetComponent<CardScreen>();

        cardScreen.Setup(card);
        cardScreen.OnSuccess.AddListener(EndResolve);
        cardScreen.OnFail.AddListener(OnDeclareBankrupt);
    }

    private void ResolveMessageTile(MessageTile messageTile)
    {
        Debug.Log(messageTile.message);
        GameObject uiObject = Instantiate(messageScreenPrefab, transform);
        MessageScreen messageScreen = uiObject.GetComponent<MessageScreen>();

        string message = messageTile.message;
        messageScreen.Setup(message);
        messageScreen.OnContinue.AddListener(EndResolve);
    }

    public void OnBuy(Tile tile)
    {
        tile.Buy(turnManager.CurrentPlayerIndex());

        if(tile is Property)
        {
            playerManager.GivePlayerProperty(turnManager.CurrentPlayerIndex(),  (Property)tile); // CAST INVALID
        }
        else if(tile is Railroad)
        {
            playerManager.GivePlayerRailroad(turnManager.CurrentPlayerIndex(),  (Railroad)tile);
        }
        else if(tile is Utility)
        {
            playerManager.GivePlayerUtility(turnManager.CurrentPlayerIndex(),  (Utility)tile);  // CAST INVALID
        }

        EndResolve();
    }

    public void OnPayRent(int rent)
    {
        playerManager.PayPlayer(bufferedTile.ownerID, rent);
        EndResolve();
    }

    public void OnPayFine(int fine)
    {
        EndResolve();
    }

    public void OnDeclareBankrupt()
    {
        GameObject uiObject = Instantiate(messageScreenPrefab, transform.parent);
        MessageScreen messageScreen = uiObject.GetComponent<MessageScreen>();

        string message = "Player " + turnManager.CurrentPlayerNumber() + " Is Bankrupt!\nThey are out of the game";
        messageScreen.Setup(message);
        messageScreen.OnContinue.AddListener(OnBankrupt);
    }

    private void OnBankrupt()
    {
        playerManager.BankruptPlayer(turnManager.CurrentPlayerIndex());
    }

    private void ResolveSpecial(Special special)
    {
        //
    }

    public void OnClickContinue()
    {
        EndResolve();
    }

    private void EndResolve()
    {
        turnManager.ChangeTurnState(TurnState.Actions_2);
    }
}
