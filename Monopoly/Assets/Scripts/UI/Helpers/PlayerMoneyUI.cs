using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PlayerMoneyUI : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI title;
    public TextMeshProUGUI money;

    private int ID;
    private PlayerManager playerManager;
    private GlobalColorLUT globalColorLUT;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    public void Setup(int _id)
    {
        ID = _id;

        panel.color = globalColorLUT.GetColor(ID);
        title.text = "Player " + (ID + 1);
        money.text = "$1500";

        playerManager.OnPlayerMoneyChange.AddListener(OnMoneyUpdate);
    }

    public void OnMoneyUpdate(int _id, int newAmount)
    {
        if(_id == ID) money.text = "$" + newAmount;
    }
}
