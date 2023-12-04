using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class RecieveScreen : MonoBehaviour
{
    public Image panel;
    public GameObject root;
    public TextMeshProUGUI prompt;
    public UnityEvent<int> OnRecieve;
    public UnityEvent OnContinue;

    private PlayerManager playerManager;
    private GlobalColorLUT globalColorLUT;

    private int _amountToRecieve;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    public void Setup(string message, int playerID, int amountToRecieve)
    {
        
        prompt.text = message;
        playerManager.PayPlayer(playerID, amountToRecieve);
        _amountToRecieve = amountToRecieve;

        panel.color = globalColorLUT.GetCurrentPlayerColor();
    }

    public void OnClickContinue()
    {
        OnRecieve.Invoke(_amountToRecieve);
        OnContinue.Invoke();

        Destroy(gameObject, 0.1f);
    }
}
