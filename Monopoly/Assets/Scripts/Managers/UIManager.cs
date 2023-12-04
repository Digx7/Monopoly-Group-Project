using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public GameObject gameStartUIScreen;
    public GameObject gameSetUpUIScreen;
    public GameObject gameRunUIScreen;
    public GameObject gameEndUIScreen;

    public UnityAction unityAction;

    //References
    private GameManager gameManager;

    public void Awake()
    {

    }

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();

        gameManager.OnStartBegin.AddListener(EnableStartUIScreen);
        gameManager.OnSetTurnOrderBegin.AddListener(EnableSetupUIScreen);
        gameManager.OnRunBegin.AddListener(EnableRunUIScreen);
        gameManager.OnGameFinishedBegin.AddListener(EnableEndUIScreen);

        gameManager.OnStartEnd.AddListener(DisableStartUIScreen);
        gameManager.OnSetTurnOrderEnd.AddListener(DisableSetupUIScreen);
        gameManager.OnRunEnd.AddListener(DisableRunUIScreen);
        gameManager.OnGameFinishedEnd.AddListener(DisableEndUIScreen);
    }

    private void OnDisable()
    {
        gameManager.OnStartBegin.RemoveListener(EnableStartUIScreen);
        gameManager.OnSetTurnOrderBegin.RemoveListener(EnableSetupUIScreen);
        gameManager.OnRunBegin.RemoveListener(EnableRunUIScreen);
        gameManager.OnGameFinishedBegin.RemoveListener(EnableEndUIScreen);

        gameManager.OnStartEnd.RemoveListener(DisableStartUIScreen);
        gameManager.OnSetTurnOrderEnd.RemoveListener(DisableSetupUIScreen);
        gameManager.OnRunEnd.RemoveListener(DisableRunUIScreen);
        gameManager.OnGameFinishedEnd.RemoveListener(DisableEndUIScreen);
    }

    private void EnableStartUIScreen()
    {
        EnableUIScreen(gameStartUIScreen);
    }

    private void EnableSetupUIScreen()
    {
        EnableUIScreen(gameSetUpUIScreen);
    }

    private void EnableRunUIScreen()
    {
        EnableUIScreen(gameRunUIScreen);
    }

    private void EnableEndUIScreen()
    {
        EnableUIScreen(gameEndUIScreen);
    }

    private void DisableStartUIScreen()
    {
        DisableUIScreen(gameStartUIScreen);
    }

    private void DisableSetupUIScreen()
    {
        DisableUIScreen(gameSetUpUIScreen);
    }

    private void DisableRunUIScreen()
    {
        DisableUIScreen(gameRunUIScreen);
    }

    private void DisableEndUIScreen()
    {
        DisableUIScreen(gameEndUIScreen);
    }


    private void EnableUIScreen(GameObject uIScreen)
    {
        uIScreen.SetActive(true);
    }

    private void DisableUIScreen(GameObject uIScreen)
    {
        uIScreen.SetActive(false);
    }
}
