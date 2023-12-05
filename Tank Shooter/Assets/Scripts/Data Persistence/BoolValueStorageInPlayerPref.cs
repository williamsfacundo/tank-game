using UnityEngine;

namespace TankGame.DataPersistence 
{
    public static class BoolValueStorageInPlayerPref
    {
        private const int NullValue = 2;

        public static void StoreBoolValue(bool value, string keyName)
        {
            int valueData = value ? 1 : 0;

            PlayerPrefs.SetInt(keyName, valueData);

            PlayerPrefs.Save();
        }

        public static bool RetrieveBoolValue(string keyName) 
        {
            int valueData = PlayerPrefs.GetInt(keyName, 1);

            return valueData == 1 ? true : false;
        }

        public static bool DoesValueExist(string keyName) 
        {
            int valueData = PlayerPrefs.GetInt(keyName, NullValue);

            return valueData != NullValue ? true : false;
        }
    }
}