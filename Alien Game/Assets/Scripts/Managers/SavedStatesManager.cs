using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SavedStatesManager {
	private static String level = "1-2";
	private static int world = 1;
	private static int levelProgress = 501;
	private static bool isLevelCleared = false;

    public static String Level 
    {
        get 
        {
            return level;
        }
        set 
        {
            level = value;
        }
    }
	
	public static int World 
    {
        get 
        {
            return world;
        }
        set 
        {
            world = value;
        }
    }
	
	public static int LevelProgress
	{
		get { return levelProgress; }
		set { levelProgress = value; }
	}
	
	public static bool IsLevelCleared
	{
		get 
        {
            return isLevelCleared;
        }
        set 
        {
            isLevelCleared = value;
        }
		
	}
	
	
		
}
