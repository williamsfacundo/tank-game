using System;

using UnityEngine;
using UnityEngine.UI;

using TankGame.DataPersistence;
using TankGame.Sound;

namespace TankGame.UI 
{
    [RequireComponent(typeof(Toggle))]
    public class SoundToggleUI : MonoBehaviour
    {
        private Toggle soundActiveStatusToggle;

        public static event Action<bool> OnSoundStatusChanged;

        private void Awake()
        {
            soundActiveStatusToggle = GetComponent<Toggle>();
        }

        void Start()
        {
            if (BoolValueStorageInPlayerPref.DoesValueExist(AudioManager.SoundKeyName))
            {
                soundActiveStatusToggle.isOn = BoolValueStorageInPlayerPref.RetrieveBoolValue(AudioManager.SoundKeyName);
            }
            else 
            {
                BoolValueStorageInPlayerPref.StoreBoolValue(true, AudioManager.SoundKeyName);

                soundActiveStatusToggle.isOn = true;
            }

            OnSoundStatusChanged?.Invoke(!soundActiveStatusToggle.isOn);

            soundActiveStatusToggle.onValueChanged.AddListener(UpdateSoundStatusInPlayerPrefs);
        }

        private void OnDestroy()
        {
            soundActiveStatusToggle.onValueChanged.AddListener(UpdateSoundStatusInPlayerPrefs);
        }

        private void UpdateSoundStatusInPlayerPrefs(bool toggleValue) 
        {
            BoolValueStorageInPlayerPref.StoreBoolValue(toggleValue, AudioManager.SoundKeyName);

            OnSoundStatusChanged?.Invoke(!soundActiveStatusToggle.isOn);
        }
    }
}