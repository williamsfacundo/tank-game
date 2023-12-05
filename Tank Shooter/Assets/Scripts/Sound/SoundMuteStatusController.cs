using UnityEngine;

using TankGame.UI;

namespace TankGame.Sound 
{
    public class SoundMuteStatusController : MonoBehaviour
    {
        private void Awake()
        {
            SoundToggleUI.OnSoundStatusChanged += UpdateAudioManagerMuteStatus;            
        }

        private void OnDestroy() 
        {
            SoundToggleUI.OnSoundStatusChanged -= UpdateAudioManagerMuteStatus;            
        }

        private void UpdateAudioManagerMuteStatus(bool isMusicOn) 
        {
            AudioManager.Instance.SetMusicMuteStatus(isMusicOn);

            AudioManager.Instance.SetSfxsMuteStatus(isMusicOn);
        }
    }
}