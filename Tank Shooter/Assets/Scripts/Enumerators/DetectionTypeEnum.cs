using System;

namespace TankGame.Enumerators 
{
    [Flags]
    public enum DetectionTypeEnum
    {
        ENTER = 1,
        STAY = 2,
        EXIT = 3
    }
}