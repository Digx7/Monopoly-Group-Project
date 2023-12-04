using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PropertyColorSet
{
    public PropertyColor color;
    public List<Property> owned;

    public PropertyColorSet()
    {
        color = PropertyColor.Purple;
        owned = new List<Property>();
    }
    public PropertyColorSet(PropertyColor _color)
    {
        color = _color;
        owned = new List<Property>();
    }

    public bool IsMonopoly()
    {
        int max = 3;
        if(color == PropertyColor.Purple || color == PropertyColor.DarkBlue)
        {
            max = 2;
        }

        if(owned.Count == max) return true;
        else return false;
    }

    public void Add(Property property)
    {
        if(owned.Contains(property)) return;

        owned.Add(property);
    }

    public void Remove(Property property)
    {
        if(!owned.Contains(property)) return;

        owned.Remove(property);
    }
}
