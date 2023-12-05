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

        private void Awake()
        {
            soundActiveStatusToggle = GetComponent<Toggle>();
        }

        void Start()
        {
            if (BoolValueStorageInPlayerPref.DoesValueExist(SoundManager.SoundKeyName))
            {
                soundActiveStatusToggle.isOn = BoolValueStorageInPlayerPref.RetrieveBoolValue(SoundManager.SoundKeyName);
            }
            else 
            {
                BoolValueStorageInPlayerPref.StoreBoolValue(true, SoundManager.SoundKeyName);

                soundActiveStatusToggle.isOn = true;
            }

            soundActiveStatusToggle.onValueChanged.AddListener(UpdateSoundStatusInPlayerPrefs);
        }

        private void OnDestroy()
        {
            soundActiveStatusToggle.onValueChanged.AddListener(UpdateSoundStatusInPlayerPrefs);
        }

        private void UpdateSoundStatusInPlayerPrefs(bool toggleValue) 
        {
            BoolValueStorageInPlayerPref.StoreBoolValue(toggleValue, SoundManager.SoundKeyName);
        }
    }
}