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
        
        
    }

    
    // return current folder txt file Dir
    
    public static string GetCurrentTxtName()
    {
        string[] currentDirs = currentDir.Split("/");
        string lastDir = currentDirs[currentDirs.Length - 1];
        return lastDir;
    }
    
    
}
