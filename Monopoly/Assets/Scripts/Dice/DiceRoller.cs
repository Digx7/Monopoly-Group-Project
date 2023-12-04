using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceRoller : MonoBehaviour
{
    public int dice1;
    public int dice2;
    public int total;

    public UnityEvent OnRollStart;
    public UnityEvent<Roll> OnRollFinish;


    public void Awake()
    {
        dice1 = 0;
        dice2 = 0;
        total = 0;
    }

    public Roll RollOne()
    {
        OnRollStart.Invoke();

        dice1 = Random.Range(1, 7);
        dice2 = 0;
        total = dice1;

        Roll roll = new Roll();
        roll.total = total;
        roll.isDouble = CheckDoubles();

        OnRollFinish.Invoke(roll);

        return roll;
    }


    public Roll RollBoth()
    {
        OnRollStart.Invoke();
        
        dice1 = Random.Range(1, 7);
        dice2 = Random.Range(1, 7);
        total = dice1 + dice2;

        Roll roll = new Roll();
        roll.total = total;
        roll.isDouble = CheckDoubles();

        OnRollFinish.Invoke(roll);

        return roll;
    }


    private bool CheckDoubles() { return dice1 == dice2; }
}
