using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct C_Status
{
    public static int gems = 0;
    public static int gemsRow = 0;
    public static int food = 0;
    public static int level = 1;
    public static mode GM = mode.game;

    public static void rest()
    {
        gems = 0;
        gemsRow = 0;
        food = 0;
        GM = mode.game;
    }
}
public enum mode
{
    game,
    lose,
    win,
    undead
}