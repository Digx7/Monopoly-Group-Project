using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScreen : MonoBehaviour
{
    public int numberOfPlayers;
    public GameObject playerUIPrefab;

    public TextMeshProUGUI numberOfPlayersDisplay;
    public GameObject playerUIPrefabParent;

    //magic numbers
    private int minAmountOfPlayers = 2;
    private int maxAmountOfPlayers = 4;
    private int numberOfCurrentlyRenderedPlayers = 2;

    private List<PlayerStartData> playerStartData;

    //references
    private PlayerManager playerManager;
    private GameManager gameManager;
    private Board board;

    private void Awake()
    {
        playerStartData = new List<PlayerStartData>();
        playerManager = FindObjectOfType<PlayerManager>();
        gameManager = FindObjectOfType<GameManager>();
        board = FindObjectOfType<Board>();

        // BufferNewStartData(1);
        // BufferNewStartData(2);
    }

    public void IncreaseNumberOfPlayers()
    {
        numberOfPlayers++;
        
        if(numberOfPlayers > maxAmountOfPlayers) numberOfPlayers = maxAmountOfPlayers;

        // update displays
        RenderPlayerCount();
    }

    public void DecreaseNumberOfPlayers()
    {
        numberOfPlayers--;

        if (numberOfPlayers < minAmountOfPlayers) numberOfPlayers = minAmountOfPlayers;

        // update displays
        RenderPlayerCount();
    }

    private void RenderPlayerCount()
    {
        numberOfPlayersDisplay.text = "" + numberOfPlayers;
        GeneratePlayerUIPrefabs();
    }

    private void GeneratePlayerUIPrefabs()
    {
        if(numberOfPlayers > numberOfCurrentlyRenderedPlayers)
        {
            // add 1 more

            GameObject playerUI = Instantiate(playerUIPrefab, playerUIPrefabParent.transform);

            // Sets player number

            TextMeshProUGUI playerNumber = playerUI.transform.Find("Items/PlayerNumber (TMP)").GetComponent<TextMeshProUGUI>();
            playerNumber.text = "Player " + numberOfPlayers;

            playerUI.GetComponent<PlayerStartScreen>().BufferNumber(numberOfPlayers - 1);

            // BufferNewStartData(numberOfPlayers);

        }
        else if(numberOfPlayers < numberOfCurrentlyRenderedPlayers)
        {
            // remove last one
            int childCount = playerUIPrefabParent.transform.childCount;
            GameObject lastPlayer = playerUIPrefabParent.transform.GetChild(childCount - 1).gameObject;
            Destroy(lastPlayer);

            // playerStartData.RemoveAt(numberOfPlayers);
        }

        numberOfCurrentlyRenderedPlayers = numberOfPlayers;
    }



    private void ReadBufferedData()
    {
        foreach (Transform playerUI in playerUIPrefabParent.transform)
        {
            PlayerStartData newData = playerUI.GetComponent<PlayerStartScreen>().playerStartData;
            playerStartData.Add(newData);
        }
    }

    public void OnStart()
    {
        ReadBufferedData();
        
        foreach (PlayerStartData startingData in playerStartData)
        {
            playerManager.AddPlayer(startingData);
            board.SetUpAvatar(startingData);
        }

        gameManager.ChangeGameState(GameState.SetTurnOrder);
    }
}
