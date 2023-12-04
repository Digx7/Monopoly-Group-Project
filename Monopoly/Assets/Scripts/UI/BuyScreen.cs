using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class BuyScreen : MonoBehaviour
{
    public Image panel;
    public GameObject root;
    public TextMeshProUGUI prompt;
    public Image image;
    public UnityEvent OnYes;
    public UnityEvent OnNo;
    public UnityEvent<Tile> OnSuccess;
    public UnityEvent OnFail;

    public GameObject payScreenPrefab;

    private Tile _tile;
    private int _potentialBuyerID;
    private TurnManager turnManager;
    private GlobalColorLUT globalColorLUT;

    public void Awake()
    {
        turnManager = FindObjectOfType<TurnManager>();
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    public void Setup(Tile tile, int potentialBuyerID)
    {
        prompt.text = "Would you like to buy " + tile.name + " for $" + tile.price + "?";
        image.sprite = tile.frontSprite;

        _tile = tile;
        _potentialBuyerID = potentialBuyerID;

        panel.color = globalColorLUT.GetCurrentPlayerColor();
    }

    public void OnYesClicked()
    {
        OnYes.Invoke();

        GameObject payScreen = Instantiate(payScreenPrefab, gameObject.transform.parent);
        PayScreenUI payScreenUI = payScreen.GetComponent<PayScreenUI>();

        string successMessage = "You bought " + _tile.name + " for $" + _tile.price;
        string failedMessage = "You don't have enough to buy " + _tile.name;
        payScreenUI.Setup(successMessage, failedMessage, _potentialBuyerID, _tile.price);

        payScreenUI.OnSuccess.AddListener(OnSuccessListener);
        payScreenUI.OnFail.AddListener(OnFailListener);

        root.SetActive(false);
    }

    public void OnNoClicked()
    {
        OnNo.Invoke();

        Debug.Log("Player doesn't want to buy, maybe auction");
        OnFail.Invoke();
        Destroy(gameObject, 0.1f);
    }

    public void OnSuccessListener()
    {
        OnSuccess.Invoke(_tile);
        Destroy(gameObject, 0.1f);
    }

    public void OnFailListener()
    {
        OnFail.Invoke();
        Destroy(gameObject, 0.1f);
    }
}
