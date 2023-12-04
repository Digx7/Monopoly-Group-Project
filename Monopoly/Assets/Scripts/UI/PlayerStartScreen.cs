using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStartScreen : MonoBehaviour
{
    public Image panel;
    public PlayerStartData playerStartData;

    private GlobalColorLUT globalColorLUT;
    private void Awake()
    {
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }
    
    private void Start()
    {
        RenderPanel();
    }

    private void RenderPanel()
    {
        panel.color = globalColorLUT.GetColor(playerStartData.number);
    }

    public void BufferNumber(int number)
    {
        playerStartData.number = number;
    }

    public void BufferName(string name)
    {
        playerStartData.name = name;
    }

    public void BufferAvatar(int number)
    {
        playerStartData.avatar = number;
    }
}
