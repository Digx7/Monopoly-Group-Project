using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/WarningAndErrorCard/Card", order = 1)]
public class WarningAndErrorCard : ScriptableObject
{
    public Sprite cardSprite;
    public int cardType = 0;
    public int amount;
}
