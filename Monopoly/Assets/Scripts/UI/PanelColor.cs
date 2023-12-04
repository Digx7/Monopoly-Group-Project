using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelColor : MonoBehaviour
{
    public Image panel;
    public bool useCurrentPlayer = true;

    private GlobalColorLUT globalColorLUT;
    private void Awake()
    {
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    public void OnEnable()
    {
        if(useCurrentPlayer) panel.color = globalColorLUT.GetCurrentPlayerColor();
        else panel.color = globalColorLUT.UIPanels;
    }
}
