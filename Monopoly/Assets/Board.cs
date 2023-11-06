using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    // Board contains an array of Tiles
    public List<Tile> tiles = new List<Tile>();

    public void InitializeBoard()
    {
        // Purple properties
        Property Yahoo = new Property("Yahoo", "Purple", 60, 30, 33, 0, 50, {2, 4, 10, 30, 90, 160, 250}, false, false, null);
        Property Twitch = new Property("Twitch", "Purple", 60, 30, 33, 0, 50, {4, 8, 20, 60, 180, 320, 450}, false, false, null);

        // Light Blue properties
        Property Logitech = new Property("Logitech", "Light Blue", 100, 50, 55, 0, 50, {6, 12, 30, 90, 270, 400, 550}, false, false, null);
        Property Cisco = new Property("Cisco", "Light Blue", 100, 50, 55, 0, 50, {6, 12, 30, 90, 270, 400, 550}, false, false, null);
        Property ATT = new Property("AT&T", "Light Blue", 120, 60, 66, 0, 50, {8, 16, 40, 100, 300, 450, 600}, false, false, null);

        // Pink properties
        Property Lyft = new Property("Lyft", "Pink", 140, 70, 77, 0, 100, {10, 20, 50, 150, 450, 625, 750}, false, false, null);
        Property LG = new Property("LG", "Pink", 140, 70, 77, 0, 100, {10, 20, 50, 150, 450, 625, 750}, false, false, null);
        Property TMobile = new Property("TMobile", "Pink", 160, 80, 88, 0, 100, {12, 24, 60, 180, 500, 700, 900}, false, false, null);

        // Orange properties
        Property AMD = new Property("AMD", "Orange", 180, 90, 99, 0, 100, {14, 28, 70, 200, 550, 750, 950}, false, false, null);
        Property StackOverflow = new Property("StackOverflow", "Orange", 180, 90, 99, 0, 100, {14, 28, 70, 200, 550, 750, 950}, false, false, null);
        Property Reddit = new Property("Reddit", "Orange", 200, 100, 110, 0, 100, {16, 32, 80, 220, 600, 800, 1000}, false, false, null);

        // Red properties
        Property CDProjectRed = new Property("CDProjectRed", "Red", 220, 110, 121, 0, 150, {18, 36, 90, 250, 700, 875, 1050}, false, false, null);
        Property RiotGames = new Property("RiotGames", "Red", 220, 110, 121, 0, 150, {18, 36, 90, 250, 700, 875, 1050}, false, false, null);
        Property ElectronicArts = new Property("ElectronicArts", "Red", 240, 120, 132, 0, 150, {20, 40, 100, 300, 750, 925, 1100}, false, false, null);

        // Yellow properties
        Property BestBuy = new Property("BestBuy", "Yellow", 260, 130, 143, 0, 150, {22, 44, 110, 330, 800, 975, 1150}, false, false, null);
        Property Sprint = new Property("Sprint", "Yellow", 260, 130, 143, 0, 150, {22, 44, 110, 330, 800, 975, 1150}, false, false, null);
        Property WesternUnion = new Property("WesternUnion", "Yellow", 280, 140, 154, 0, 150, {24, 48, 120, 360, 850, 1025, 1200}, false, false, null);

        // Green properties
        Property Razer = new Property("Razer", "Green", 300, 150, 165, 0, 200, {26, 52, 130, 390, 900, 1100, 1275}, false, false, null);
        Property Nvidia = new Property("Nvidia", "Green", 300, 150, 165, 0, 200, {26, 52, 130, 390, 900, 1100, 1275}, false, false, null);
        Property Spotify = new Property("Spotify", "Green", 320, 160, 176, 0, 200, {28, 56, 150, 450, 1000, 1200, 1400}, false, false, null);

        // Dark Blue properties
        Property Intel = new Property("Intel", "Dark Blue", 350, 175, 193, 0, 200, {35, 70, 175, 500, 1100, 1300, 1500}, false, false, null);
        Property HP = new Property("HP", "Dark Blue", 400, 200, 220, 0, 200, {50, 100, 200, 600, 1400, 1700, 2000}, false, false, null);

        // TODO: Add Properties to their respective indexes within Tiles array
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
