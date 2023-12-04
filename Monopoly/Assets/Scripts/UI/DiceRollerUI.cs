using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DiceRollerUI : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI prompt;
    public TextMeshProUGUI result;
    public GameObject rollButton;
    public GameObject continueButton;

    public UnityEvent<Roll> OnClickContinue;

    private DiceRoller diceRoller;
    private Roll roll;
    private bool onlyRollOne;
    private GlobalColorLUT globalColorLUT;

    private void Awake()
    {
        globalColorLUT = FindObjectOfType<GlobalColorLUT>();
        diceRoller = FindObjectOfType<DiceRoller>();
        roll = new Roll();
    }

    public void SetUp(string promptMessage, bool rollOne = false)
    {
        prompt.text = promptMessage;
        onlyRollOne = rollOne;

        panel.color = globalColorLUT.GetCurrentPlayerColor();
    }

    public void OnRoll()
    {
        if(onlyRollOne)
        {
            roll = diceRoller.RollOne();
        }
        else
        {
            roll = diceRoller.RollBoth();
        }

        result.text = "" + roll.total;

        rollButton.SetActive(false);
        continueButton.SetActive(true);
    }

    public void OnContinue()
    {
        // pass roll data along 
        OnClickContinue.Invoke(roll);
        // destroy self
        Destroy(this.gameObject, 0.2f);
    }
}
