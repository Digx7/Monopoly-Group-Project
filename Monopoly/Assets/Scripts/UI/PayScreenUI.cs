using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class PayScreenUI : MonoBehaviour
{
    public Image panel;
    public GameObject root;
    public TextMeshProUGUI prompt;
    public UnityEvent<int> OnPay;
    public UnityEvent OnCantPay;
    public UnityEvent OnContinue;
    public UnityEvent OnSuccess;
    public UnityEvent OnFail;

    private PlayerManager playerManager;
    private GlobalColorLUT globalColorLUT;
    private int fine;
    private bool isPayed = false;
    private bool _requiredToPay;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    public void Setup(string successMessage, string failedMessage, int playerID, int amountToPay, bool requiredToPay = false)
    {
        fine = amountToPay;
        
        if(CanPay(playerID, fine))
        {
            playerManager.ChargePlayer(playerID, fine);
            isPayed = true;

            prompt.text = successMessage;
        }
        else
        {
            prompt.text = failedMessage;
            
            OnCantPay.Invoke();
            Debug.Log("Player Can't pay and must sell houses/mortgage properties");
        }

        _requiredToPay = requiredToPay;

        panel.color = globalColorLUT.GetCurrentPlayerColor();
    }

    private bool CanPay(int playerID, int amountToPay)
    {
        if(playerManager.players[playerID].money >= amountToPay) return true;
        else return false;
    }

    public void OnClickContinue()
    {
        if(isPayed)
        {
            OnSuccess.Invoke();
            OnPay.Invoke(fine);
            Destroy(gameObject, 0.1f);
        }
        else if(!_requiredToPay)
        {
            Debug.Log("Can't afford but not requried to pay");
            OnFail.Invoke();
            root.SetActive(false);
            Destroy(gameObject, 0.1f);
        }
        else if(_requiredToPay)
        {
            Debug.Log("Can't afford but MUST pay");
            OnFail.Invoke();
            root.SetActive(false);
            Destroy(gameObject, 0.1f);
        }
    }

    public void OnSuccessListener()
    {
        OnSuccess.Invoke();
        OnPay.Invoke(fine);
        Destroy(gameObject, 0.1f);
    }

    public void OnFailListener()
    {
        OnFail.Invoke();
        Destroy(gameObject, 0.1f);
    }
}
