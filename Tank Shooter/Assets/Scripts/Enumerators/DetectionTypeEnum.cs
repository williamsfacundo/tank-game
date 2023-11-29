using System;

//Enums used in another of my projects
//Link: https://github.com/lobinuxsoft/weather-guardian/blob/development/Assets/Scripts/Utils/DetectionType.cs

namespace TankGame.Enumerators 
{
    [Flags]
    public enum DetectionTypeEnum
    {
        ENTER = 1 << 0,
        STAY = 1 << 1,
        EXIT = 1 << 2
    }
}