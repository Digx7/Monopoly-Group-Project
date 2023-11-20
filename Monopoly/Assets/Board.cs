using System;
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
        Property Yahoo = new Property();
        Yahoo.InitializeProperty("Yahoo", "Purple", 60, 30, 33, 0, 50, new int[] { 2, 4, 10, 30, 90, 160, 250 }, false, false, null);
        Property Twitch = new Property();
        Twitch.InitializeProperty("Twitch", "Purple", 60, 30, 33, 0, 50, new int[] { 4, 8, 20, 60, 180, 320, 450 }, false, false, null);

        // Light Blue properties
        Property Logitech = new Property();
        Logitech.InitializeProperty("Logitech", "Light Blue", 100, 50, 55, 0, 50, new int[] { 6, 12, 30, 90, 270, 400, 550 }, false, false, null);
        Property Cisco = new Property();
        Cisco.InitializeProperty("Cisco", "Light Blue", 100, 50, 55, 0, 50, new int[] { 6, 12, 30, 90, 270, 400, 550 }, false, false, null);
        Property ATT = new Property();
        ATT.InitializeProperty("AT&T", "Light Blue", 120, 60, 66, 0, 50, new int[] { 8, 16, 40, 100, 300, 450, 600 }, false, false, null);

        // Pink properties
        Property Lyft = new Property();
        Lyft.InitializeProperty("Lyft", "Pink", 140, 70, 77, 0, 100, new int[] { 10, 20, 50, 150, 450, 625, 750 }, false, false, null);
        Property LG = new Property();
        LG.InitializeProperty("LG", "Pink", 140, 70, 77, 0, 100, new int[] { 10, 20, 50, 150, 450, 625, 750 }, false, false, null);
        Property TMobile = new Property();
        TMobile.InitializeProperty("TMobile", "Pink", 160, 80, 88, 0, 100, new int[] { 12, 24, 60, 180, 500, 700, 900 }, false, false, null);

        // Orange properties
        Property AMD = new Property();
        AMD.InitializeProperty("AMD", "Orange", 180, 90, 99, 0, 100, new int[] { 14, 28, 70, 200, 550, 750, 950 }, false, false, null);
        Property StackOverflow = new Property();
        StackOverflow.InitializeProperty("StackOverflow", "Orange", 180, 90, 99, 0, 100, new int[] { 14, 28, 70, 200, 550, 750, 950 }, false, false, null);
        Property Reddit = new Property();
        Reddit.InitializeProperty("Reddit", "Orange", 200, 100, 110, 0, 100, new int[] { 16, 32, 80, 220, 600, 800, 1000 }, false, false, null);

        // Red properties
        Property CDProjectRed = new Property();
        CDProjectRed.InitializeProperty("CDProjectRed", "Red", 220, 110, 121, 0, 150, new int[] { 18, 36, 90, 250, 700, 875, 1050 }, false, false, null);
        Property RiotGames = new Property();
        RiotGames.InitializeProperty("RiotGames", "Red", 220, 110, 121, 0, 150, new int[] { 18, 36, 90, 250, 700, 875, 1050 }, false, false, null);
        Property ElectronicArts = new Property();
        ElectronicArts.InitializeProperty("ElectronicArts", "Red", 240, 120, 132, 0, 150, new int[] { 20, 40, 100, 300, 750, 925, 1100 }, false, false, null);

        // Yellow properties
        Property BestBuy = new Property();
        BestBuy.InitializeProperty("BestBuy", "Yellow", 260, 130, 143, 0, 150, new int[] { 22, 44, 110, 330, 800, 975, 1150 }, false, false, null);
        Property Sprint = new Property();
        Sprint.InitializeProperty("Sprint", "Yellow", 260, 130, 143, 0, 150, new int[] { 22, 44, 110, 330, 800, 975, 1150 }, false, false, null);
        Property WesternUnion = new Property();
        WesternUnion.InitializeProperty("WesternUnion", "Yellow", 280, 140, 154, 0, 150, new int[] { 24, 48, 120, 360, 850, 1025, 1200 }, false, false, null);

        // Green properties
        Property Razer = new Property();
        Razer.InitializeProperty("Razer", "Green", 300, 150, 165, 0, 200, new int[] { 26, 52, 130, 390, 900, 1100, 1275 }, false, false, null);
        Property Nvidia = new Property();
        Nvidia.InitializeProperty("Nvidia", "Green", 300, 150, 165, 0, 200, new int[] { 26, 52, 130, 390, 900, 1100, 1275 }, false, false, null);
        Property Spotify = new Property();
        Spotify.InitializeProperty("Spotify", "Green", 320, 160, 176, 0, 200, new int[] { 28, 56, 150, 450, 1000, 1200, 1400 }, false, false, null);

        // Dark Blue properties
        Property Intel = new Property();
        Intel.InitializeProperty("Intel", "Dark Blue", 350, 175, 193, 0, 200, new int[] { 35, 70, 175, 500, 1100, 1300, 1500 }, false, false, null);
        Property HP = new Property();
        HP.InitializeProperty("HP", "Dark Blue", 400, 200, 220, 0, 200, new int[] { 50, 100, 200, 600, 1400, 1700, 2000 }, false, false, null);

        // Special tiles
        Special Go = new Special();
        Go.InitializeSpecial("Go");

        Special GoToJail = new Special();
        GoToJail.InitializeSpecial("GoToJail");

        Special Jail = new Special();
        Jail.InitializeSpecial("Jail");

        Special Parking = new Special();
        Parking.InitializeSpecial("Parking");

        Special Update = new Special();
        Update.InitializeSpecial("Update");

        Special Crash = new Special();
        Crash.InitializeSpecial("Crash");

        Special Error = new Special();
        Error.InitializeSpecial("Error");

        Special Warning = new Special();
        Warning.InitializeSpecial("Warning");

        // Railraods
        Railroad CPP = new Railroad();
        CPP.railroadName = "CPP";

        Railroad Java = new Railroad();
        Java.railroadName = "Java";

        Railroad HTML = new Railroad();
        HTML.railroadName = "HTML";

        Railroad Python = new Railroad();
        Python.railroadName = "Python";

        // Utilities
        Utility Surfshark = new Utility();
        Surfshark.utilityName = "Surfshark";

        Utility NordVPN = new Utility();
        NordVPN.utilityName = "NordVPN";

        tiles.Insert(0, Go);
        tiles.Insert(1, Yahoo);
        tiles.Insert(2, Error);
        tiles.Insert(3, Twitch);
        tiles.Insert(4, Update);
        tiles.Insert(5, CPP);
        tiles.Insert(6, Logitech);
        tiles.Insert(7, Warning);
        tiles.Insert(8, Cisco);
        tiles.Insert(9, ATT);
        tiles.Insert(10, Jail);
        tiles.Insert(11, Lyft);
        tiles.Insert(12, Surfshark);
        tiles.Insert(13, LG);
        tiles.Insert(14, TMobile);
        tiles.Insert(15, Java);
        tiles.Insert(16, AMD);
        tiles.Insert(17, Error);
        tiles.Insert(18, StackOverflow);
        tiles.Insert(19, Reddit);
        tiles.Insert(20, Parking);
        tiles.Insert(21, CDProjectRed);
        tiles.Insert(22, Warning);
        tiles.Insert(23, RiotGames);
        tiles.Insert(24, ElectronicArts);
        tiles.Insert(25, HTML);
        tiles.Insert(26, BestBuy);
        tiles.Insert(27, Sprint);
        tiles.Insert(28, NordVPN);
        tiles.Insert(29, WesternUnion);
        tiles.Insert(30, GoToJail);
        tiles.Insert(31, Razer);
        tiles.Insert(32, Nvidia);
        tiles.Insert(33, Error);
        tiles.Insert(34, Spotify);
        tiles.Insert(35, Python);
        tiles.Insert(36, Warning);
        tiles.Insert(37, Intel);
        tiles.Insert(38, Crash);
        tiles.Insert(39, HP);
    }
}