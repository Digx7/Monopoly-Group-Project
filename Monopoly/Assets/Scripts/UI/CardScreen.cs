using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class CardScreen : MonoBehaviour
{
    public GameObject root;
    public Image cardImage;

    public GameObject payScreenPrefab;
    public GameObject recieveScreenPrefab;
    public UnityEvent OnContinue;
    public UnityEvent OnSuccess;
    public UnityEvent OnFail;

    private TurnManager turnManager;
    private Card bufferedCard;

    private void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

    public void Setup(Card card)
    {
        cardImage.sprite = card.cardSprite;

        bufferedCard = card;
    }

    public void OnClickContinue()
    {
        OnContinue.Invoke();

        switch (bufferedCard.cardType)
        {
            case WarningAndErrorCardTypes.Pay:
                SetUpPay();
                break;
            case WarningAndErrorCardTypes.Collect:
                SetUpRecieve();
                break;
            default:
                break;
        }

        root.SetActive(false);
    }

    private void SetUpPay()
    {
        GameObject uiObject = Instantiate(payScreenPrefab, transform.parent);
        PayScreenUI payScreenUI = uiObject.GetComponent<PayScreenUI>();

        string successMessage = "You paid the bank $" + bufferedCard.amount;
        string failedMessage = "You cant afford to pay the bank $" + bufferedCard.amount;
        payScreenUI.Setup(successMessage, failedMessage, turnManager.CurrentPlayerIndex(), bufferedCard.amount, true);
        payScreenUI.OnPay.AddListener(OnPayListener);
        payScreenUI.OnFail.AddListener(OnFailListener);
    }

    private void SetUpRecieve()
    {
        GameObject uiObject = Instantiate(recieveScreenPrefab, transform.parent);
        RecieveScreen recieveScreen = uiObject.GetComponent<RecieveScreen>();

        string message = "You recieved $" + bufferedCard.amount;
        recieveScreen.Setup(message, turnManager.CurrentPlayerIndex(), bufferedCard.amount);
        recieveScreen.OnContinue.AddListener(OnSuccessListener);
    }

    private void OnPayListener(int value)
    {
        OnSuccessListener();
    }

    private void OnSuccessListener()
    {
        OnSuccess.Invoke();

        Destroy(gameObject, 0.1f);
    }

    private void OnFailListener()
    {
        OnFail.Invoke();

        Destroy(gameObject, 0.1f);
    }
}
