using System;
using System.Collections.Generic;

public class cardType {
	
	// NOTE:	Functionality will be tied in later during Game Logic.
	//		Information will be instantiated during initialization
	//		and will adhere to the listed card information on the
	//		Google Drive.
	
	// DATA FIELDS
	int id;             // ID of the card; this will essentially be the index of the card in the "pile"/array.
	string name;        // Name of the Card; self-explanatory.
	string description; // Description of the card; this will adhere to those posted on the Google Drive.
                            // Functionality will be gleaned from these descriptions.

    // IDENTIFIERS
    int modCash;    // Player money to be modified
    bool modLoc;    // Flags it as a card that modifies location
                            // If true, pays attention to modifyLocation; if false, ignore
    bool setLoc;    // Flags it as a card that sets a new location of the player
                            // If true, pays attention to setLocation; if false, ignore
    
    int modifyLocation;     // Number of spaces to change
    int setLocation;        // New location to set player
	
	// CONSTRUCTORS
	public cardType() {     // Blank constructor
		id = 0;
		name = "";
		description = "";
        
        modCash = 0;
        modLoc = false;
        setLoc = false;

        modifyLocation = 0;
        setLocation = 0;
	}
	                        // Full Constructor
	public cardType(int _id, string _name, string _description, 
                    int _modCash, bool _modLoc, bool _setLoc, int _modifyLocation, int _setLocation) {
		id = _id;
		name = _name;
		description = _description;

        modCash = _modCash;
        modLoc = _modLoc;
        setLoc = _setLoc;

        modifyLocation = _modifyLocation;
        setLocation = _setLocation;
	}
	
	// METHODS (MUTATORS)
	public void setID(int _id)
	{	id = _id;	}
	public void setName(string _name)
	{	name = _name;	}
	public void setDescription(string _description)
	{	description = _description;	}

    public void setModCash(int _modCash)
    {   modCash = _modCash;  }
    public void setModLoc(bool _modLoc)
    {   modLoc = _modLoc; }
    public void setSetLoc(bool _setLoc)
    {   setLoc = _setLoc; }
    public void setModifyLocation(int _modifyLocation)
    {   modifyLocation = _modifyLocation; }
    public void setSetLocation(int _setLocation)
    {   setLocation = _setLocation;   }


    // METHODS (ACCESSORS)
	public int getID()
	{	return id;	}
	public string getName()
	{	return name;	}
	public string getDescription()
	{	return description;	}

    public int getModCash()
    {   return modCash; }
    public bool getModLoc()
    {   return modLoc;  }
    public bool getSetLoc()
    {   return setLoc;  }
    public int getModifyLocation()
    {   return modifyLocation;  }
    public int getSetLocation()
    {   return setLocation; }

}	// end of cardType

public class chanceType : cardType
{   // This will be applied to Chance cards. This is more or less to divide them into their respective groups.
    	
}	// end of chanceType

public class commType : cardType
{   // This will be applied to Community cards. This is more or less to divide them into their respective groups.
	
}	// end of commType
