using UnityEngine;
using System.Collections;

public static class GameMath 
{
    public const float PI = 3.141592f;

    public const int secToMin = 60;
    public const int secToHour = 3600;
    public const float secToMinInvert = 1 / secToMin;
    public const float secToHourInvert = 1 / secToHour;

    public const float meterPerOneKilo = 1000;
    public const float meterPerOneKiloInvert = 1 /1000;

    public static float MeterToKilometer(float inputMeter)
    {
        return inputMeter * meterPerOneKiloInvert;
    }
    public static float KilometerToMeter(float intputKilo)
    {
        return intputKilo * meterPerOneKilo;
    }

    //질량은 없고 일단 중력은 2배처리..
    public static float gravity = -9.8f * 3f;
}
