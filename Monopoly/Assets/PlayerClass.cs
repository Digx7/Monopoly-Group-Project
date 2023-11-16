using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // all commented lines involve an undefined Property, Railroad, or Utility class
    // uncomment once defined

    // private List<Property> _property_list;
    // private List<Railroad> _railroad_list;
    // private List<Utility> _utility_list;
    private int _money;
    private int _location;
    private int _out_of_jail_count;


    public Player()
    {
        // _property_list = new List<Property>();
        // _railroad_list = new List<Railroad>();
        // _utility_list = new List<Utility>();
        _money = 0;
        _location = 0;
        _out_of_jail_count = 0;
    }


    public int GetMoney() { return _money; }


    public void SetMoney(int money) { _money = money; }


    public void ModifyMoney(int amount) { _money += amount; }


    public int GetLocation() { return _location; }


    public void SetLocation(int index) { if (index >= 0 || index < 40) _location = index; }


    public void ModifyLocation(int amount)
    {
        if (amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                if (_location == 39) _location = 0;
                else _location++;
            }
        }
        else if (amount < 0)
        {
            for (int i = 0; i > amount; i--)
            {
                if (_location == 0) _location = 39;
                else _location--;
            }
        }
    }


    // public List<Property> GetPropertyList() { return _property_list; }


    // public void SetPropertyList(List<Property> property_list) { _property_list = property_list; }


    // public void AddProperty(Property property) { _property_list.Add(property); }


    /*
    public void RemoveProperty(string property_name)
    {
        int index = _property_list.FindIndex(property => property.propertyName == property_name);
        if (index != -1) _property_list.RemoveAt(index);
    }
    */


    // public List<Railroad> GetRailroadList() { return _railroad_list; }


    // public void SetRailroadList(List<Railroad> railroad_list) { _railroad_list = railroad_list; }


    // public void AddRailroad(Railroad railroad) { _railroad_list.Add(railroad); }


    /*
    public void RemoveRailroad(string railroad_name)
    {
        int index = _railroad_list.FindIndex(railroad => railroad.railroadName == railroad_name);
        if (index != -1) _railroad_list.RemoveAt(index);
    }
    */


    // public List<Utility> GetUtilityList() { return _utility_list; }


    // public void SetUtilityList(List<Utility> utility_list) { _utility_list = utility_list; }


    // public void AddUtility(Utility utility) { utility_list.Add(utility); }


    /*
    public void RemoveUtility(string utility_name)
    {
        int index = _utility_list.FindIndex(utility => utility.utilityName == utility_name);
        if (index != -1) _utility_list.RemoveAt(index);
    }
    */


    public int GetOutOfJailCount() { return _out_of_jail_count; }


    public void SetOutOfJailCount(int amount) { _out_of_jail_count = amount; }


    public void ModifyOutOfJailCount(int amount) { _out_of_jail_count += amount; }


    public void AddOutOfJailCount() { _out_of_jail_count++; }


    public void RemoveOutOfJailCount() { _out_of_jail_count--; }
}
