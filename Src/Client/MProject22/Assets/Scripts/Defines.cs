using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defines 
{
    public enum E_SCENES
    {
        LOGO,
        TITLE,
        TEST,
        GAME
    }

    private static Dictionary<E_SCENES, String> mScenesNms = new Dictionary<E_SCENES, string>()
        {
            { E_SCENES.LOGO , "LOGO" } ,
            { E_SCENES.TITLE , "TITLE" },
            { E_SCENES.TEST , "TEST" },
            { E_SCENES.GAME , "GAME" },
        };

    public static String GetScenesName(E_SCENES scene)
    {
        return mScenesNms[scene];
    }

    public const int G_BUBBLE_ROW_COUNT = 12;
    public const int G_BUBBLE_COL_COUNT = 8;

    public const float G_SLOT_RADIUS = 0.3f;

}
