using UnityEngine;

using TankGame.Sound;

namespace TankGame.Menu 
{
    public class PlayMainMenuMusic : MonoBehaviour
    {
        [SerializeField] private string menuMusicName;

        private void Start()
        {
            AudioManager.Instance.SetMusic(menuMusicName);

            AudioManager.Instance.PlayMusic();
        }
    }
}