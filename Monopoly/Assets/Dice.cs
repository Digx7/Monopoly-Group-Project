using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private int _dice1;
    private int _dice2;
    private int _total;


    public Dice()
    {
        _dice1 = 0;
        _dice2 = 0;
        _total = 0;
    }


    public int GetTotal() { return _total; }


    public void Roll()
    {
        _dice1 = UnityEngine.Random.Range(1, 7);
        _dice2 = UnityEngine.Random.Range(1, 7);
        _total = _dice1 + _dice2;
    }


    public bool CheckDoubles() { return _dice1 == _dice2; }
}

