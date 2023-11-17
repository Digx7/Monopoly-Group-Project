using UnityEngine;

public class cardType {
	
	// NOTE: Functionality will be tied in later.
	
	// Data Fields
	int id;
	string name;
	string description;
	
	// Constructors
	public cardType() {
		id = 0;
		name = "";
		description = "";
	}
	
	public cardType(int idNum, string cardName, string cardDesc) {
		id = idNum;
		name = cardName;
		description = cardDesc;
	}
	
	// Methods
	public void setID(int idNum)
	{	id = idNum;	}
	public void setName(string cardName)
	{	name = cardName;	}
	public void setDescription(string cardDesc)
	{	description = cardDesc;	}
	
	public int getID()
	{	return id;	}
	public string getName()
	{	return name;	}
	public string getDescription()
	{	return description;	}
	
}	// end of cardType

public class chanceType : cardType
{
	
}	// end of chanceType

public class commType : cardType
{
	
}	// end of commType