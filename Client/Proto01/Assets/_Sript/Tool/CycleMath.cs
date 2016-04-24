using UnityEngine;
using System.Collections;

public static class CycleMath 
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
}
