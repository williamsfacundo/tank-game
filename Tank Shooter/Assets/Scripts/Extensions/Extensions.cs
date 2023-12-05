using System;
using System.Collections.Generic;

namespace TankGame.Extension 
{
    public static class Extensions
    {
        public static void SortDescending<T>(this List<T> list) where T : IComparable<T>
        {
            list.Sort((x, y) => y.CompareTo(x));
        }
    }
}