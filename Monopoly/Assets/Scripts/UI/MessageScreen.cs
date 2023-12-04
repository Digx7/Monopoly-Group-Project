using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MessageScreen : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI prompt;
    public UnityEvent OnContinue;

    private GlobalColorLUT globalColorLUT;
    private void Awake()
    {
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
    }

    public void Setup(string message)
    {
        prompt.text = message;

        panel.color = globalColorLUT.GetCurrentPlayerColor();
    }

    public void OnClickContinue()
    {
        OnContinue.Invoke();

        Destroy(gameObject, 0.1f);
    }
}
