using UnityEngine;
using System.Collections;

public static class MyInfo  
{

    public static int HPCount;
    public static int SoulCount;
    public static int WeaponCount;

    public static void Initialize()
    {
        HPCount = 100;

        SoulCount = PlayerPrefs.GetInt("soulCount");

        WeaponCount = PlayerPrefs.GetInt("weaponCount");
    }

    public static void SaveInfo()
    {
         PlayerPrefs.SetInt("soulCount", SoulCount);

         PlayerPrefs.GetInt("weaponCount", WeaponCount);
    }
}
