using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PropertyCard : MonoBehaviour
{
    public Image cardImage;
    public Button button;
    public TextMeshProUGUI buttonPrompt;
    private Tile tile;
    public UnityEvent<Tile> OnMortgage;
    public UnityEvent<Tile> OnUnMortgage;

    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    public void Setup(Tile _tile)
    {
        tile = _tile;

        if(tile.isMortgaged)
        {
            cardImage.sprite = tile.backSprite;
            buttonPrompt.text = "Unmortgage (-$" + tile.unmortgagePrice + ")";
        }
        else
        {
            cardImage.sprite = tile.frontSprite;
            buttonPrompt.text = "Mortgage (+$" + tile.mortgagePrice + ")";
        }
    }

    public void OnClickButton()
    {
        if(tile.isMortgaged) OnUnMortgage.Invoke(tile);
        else OnMortgage.Invoke(tile);
    }
}
