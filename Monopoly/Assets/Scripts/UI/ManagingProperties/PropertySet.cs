using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PropertySet : MonoBehaviour
{
    public Image panel;
    public GameObject buttonsParent;
    public Button buyComputerButton;
    public Button sellComputerButton;
    public PropertyColorSet propertyColorSet;
    public GameObject propertyCardPrefab;
    public GameObject propertyCardPrefabParent;
    public UnityEvent OnBuyComputer;
    public UnityEvent OnSellComputer;
    public UnityEvent<Tile> OnMortgage;
    public UnityEvent<Tile> OnUnMortgage;

    private PlayerManager playerManager;
    private GlobalColorLUT globalColorLUT;
    private PropertyColor propertyColor;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    public void Setup(PropertyColorSet propertyColorSet)
    {
        // set panel color;
        propertyColor = propertyColorSet.color;
        panel.color = globalColorLUT.GetColor(propertyColor);

        foreach (Property property in propertyColorSet.owned)
        {   
            GameObject card = Instantiate(propertyCardPrefab, propertyCardPrefabParent.transform);
            PropertyCard propertyCard = card.GetComponent<PropertyCard>();

            propertyCard.Setup(property);
            propertyCard.OnMortgage.AddListener(OnMortgageListener);
            propertyCard.OnUnMortgage.AddListener(OnUnMortgageListener);
        }

        if(!propertyColorSet.IsMonopoly())
        {
            buyComputerButton.interactable = false;
            sellComputerButton.interactable = false;
        }
    }

    public void Setup(List<Railroad> railroads)
    {
        panel.color = globalColorLUT.UIPanels;

        foreach (Railroad railroad in railroads)
        {   
            GameObject card = Instantiate(propertyCardPrefab, propertyCardPrefabParent.transform);
            PropertyCard propertyCard = card.GetComponent<PropertyCard>();

            propertyCard.Setup(railroad);
            propertyCard.OnMortgage.AddListener(OnMortgageListener);
            propertyCard.OnUnMortgage.AddListener(OnUnMortgageListener);
        }

        buttonsParent.SetActive(false);
    }

    public void Setup(List<Utility> utilities)
    {
        panel.color = globalColorLUT.UIPanels;

        foreach (Utility utility in utilities)
        {   
            GameObject card = Instantiate(propertyCardPrefab, propertyCardPrefabParent.transform);
            PropertyCard propertyCard = card.GetComponent<PropertyCard>();

            propertyCard.Setup(utility);
            propertyCard.OnMortgage.AddListener(OnMortgageListener);
            propertyCard.OnUnMortgage.AddListener(OnUnMortgageListener);
        }

        buttonsParent.SetActive(false);
    }

    

    public void OnMortgageListener(Tile tile)
    {
        OnMortgage.Invoke(tile);
    }

    public void OnUnMortgageListener(Tile tile)
    {
        OnUnMortgage.Invoke(tile);
    }

    public void OnClickBuyComputer()
    {
        OnBuyComputer.Invoke();
    }

    public void OnClidkSellComputer()
    {
        OnSellComputer.Invoke();
    }
}