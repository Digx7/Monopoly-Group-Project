using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameFinishedScreen : MonoBehaviour
{
    public GameObject scoreBoardPrefab;
    public GameObject scoreBoardPrefabParent;
    
    private TurnManager turnManager;
    private GameManager gameManager;
    private GlobalColorLUT globalColorLUT;

    private string[] places;
    private int placeIndex = 0;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        gameManager = FindObjectOfType<GameManager>();
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();

        places = new string[5] {"1st", "2nd", "3rd","4th","5th"};
    }

    private void OnEnable()
    {
        RenderScoreBoardEntry(turnManager.CurrentPlayerIndex());

        while (gameManager.winnerStack.Count > 0)
        {
            RenderScoreBoardEntry((int)gameManager.winnerStack.Pop());
        }
    }

    private void RenderScoreBoardEntry(int playerID)
    {
        GameObject obj = Instantiate(scoreBoardPrefab, scoreBoardPrefabParent.transform);
        TextMeshProUGUI entry = obj.GetComponent<TextMeshProUGUI>();

        
        entry.text = places[placeIndex] + " Place.........Player " + (playerID + 1);
        entry.color = globalColorLUT.GetColor(playerID);

        placeIndex++;
    }

    public void OnPlayerAgainClick()
    {
        SceneManager.LoadScene(0);
    }
}
