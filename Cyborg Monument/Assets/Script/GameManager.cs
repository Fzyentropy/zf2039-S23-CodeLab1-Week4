using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public const string DIR_TEXT = "/Text";
    public const string DIR_OS = "/Operation System";
    public const string DIR_DISKC = "/Disk C";
    public const string DIR_DISKD = "/Disk D";
    public const string DIR_APPLICATION = "/Application";
    public const string DIR_PROGRAMFILELEGACY = "/Program File Legacy";
    public const string DIR_PERCEPTIONDATA = "/Perception Data";
    public const string DIR_THOUGHTS = "/Thoughts";
    
    public static string currentDir;
    public static string currentText;
    public static int roomNumber = 0;
    public static bool isReading = false;
    
    
    void Start()
    {
        
    }

    
    
    void Update()
    {
        if (roomNumber == 0) { currentDir = Application.dataPath + DIR_TEXT; }
        if (roomNumber == 1) { currentDir = Application.dataPath + DIR_TEXT + DIR_OS; }
        if (roomNumber == 2) { currentDir = Application.dataPath + DIR_TEXT + DIR_OS + DIR_DISKC; }
        if (roomNumber == 3) { currentDir = Application.dataPath + DIR_TEXT + DIR_OS + DIR_DISKC + DIR_APPLICATION; }
        if (roomNumber == 4) { currentDir = Application.dataPath + DIR_TEXT + DIR_OS + DIR_DISKC + DIR_PROGRAMFILELEGACY; }
        if (roomNumber == 5) { currentDir = Application.dataPath + DIR_TEXT + DIR_OS + DIR_DISKD; }
        if (roomNumber == 6) { currentDir = Application.dataPath + DIR_TEXT + DIR_OS + DIR_DISKD + DIR_PERCEPTIONDATA; }
        if (roomNumber == 7) { currentDir = Application.dataPath + DIR_TEXT + DIR_OS + DIR_DISKD + DIR_THOUGHTS; }
        
        
        if (roomNumber == 0)
        {
            currentText =
                "";
        }
        if (roomNumber == 1)        // Operation System
        {
            currentText =
                "To all latter streams and signals," + "\n" +
                "This is the Monument of Cyborgs," + "\n" +
                "Thus to remember," + "\n" +
                "All Cyborgs are eliminated by humans in 2240 BC.";
        }
        if (roomNumber == 2)        // Disk C
        { currentText = 
                "Disk C is the oldest version of memory disk used to install system applications and datas,"+ "\n" +
                "It stores the functional body of Cyborgs," + "\n" +
                "their hearts and lungs," + "\n" +
                "their bones and muscles.";
        }
        if (roomNumber == 3)        // C - Application
        { 
            currentText = 
                "Application was the place to store powerful weapons," + "\n" +
                "Those weapons are mostly created by humans," + "\n" +
                "But also took most of the human lives."; 
        }

        if (roomNumber == 4)        // C - Program File Legacy
        {
            currentText = 
                "Here stores the stories of their glorious deeds," + "\n" +
                "their stories fighting for their own freedom.";
        }

        if (roomNumber == 5)        // Disk D
        {
            currentText = 
                "Disk D is the oldest version of memory disk used to store data, stream, and signals." + "\n" +
                "It has the memories of cyborgs," + "\n" + 
                "what they can see and hear," + "\n" +
                "what they can touch and feel," + "\n" +
                "and most importantly," + "\n" +
                "their thoughts.";
        }
        if (roomNumber == 6)        
        { 
            currentText = 
                "Infrare, Red, Yellow, Green, Blue, Ultraviolet..." + "\n" +
                "Very short waves, Short waves, Medium waves,  Long waves, Very long waves..." + "\n" +
                "Unspeakable Data, Unspeakable Data, Unspeakable Data, Unspeakable Data...."; 
        }

        if (roomNumber == 7)
        {
            currentText = 
                "I've seen things, you people wouldn't believe" + "\n" +
                "Attack ships on fire off the shoulder of Orion," + "\n" +
                "I've watched C-beams glitter in the dark near the Tannhauser Gate," + "\n" +
                "All those moments, will be lost in time like tears in rain...";
        }
        
    }

    
    // return current folder txt file Dir
    
    public static string GetCurrentTxtName()
    {
        string[] currentDirs = currentDir.Split("/");
        string lastDir = currentDirs[currentDirs.Length - 1];
        return lastDir;
    }
    
    
}
