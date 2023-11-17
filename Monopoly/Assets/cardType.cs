using UnityEngine;

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
	public cardType(int idNum, string cardName, string cardDesc, 
                    int chMoney, bool chLoc, bool stLoc, int modifyLoc, int setLoc) {
		id = idNum;
		name = cardName;
		description = cardDesc;

        modCash = chMoney;
        modLoc = chLoc;
        setLoc = stLoc;

        modifyLocation = modifyLoc;
        setLocation = setLoc;
	}
	
	// METHODS (MUTATORS)
	public void setID(int idNum)
	{	id = idNum;	}
	public void setName(string cardName)
	{	name = cardName;	}
	public void setDescription(string cardDesc)
	{	description = cardDesc;	}

    public void setModCash(int chMoney)
    {   modCash = chMoney;  }
    public void setModLoc(bool chLoc)
    {   modLoc = chLoc; }
    public void setSetLoc(bool stLoc)
    {   setLoc = stLoc; }
    public void setModifyLocation(int modifyLoc)
    {   modifyLocation = modifyLoc; }
    public void setSetLocation(int setLoc)
    {   setLocation = setLoc;   }


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
