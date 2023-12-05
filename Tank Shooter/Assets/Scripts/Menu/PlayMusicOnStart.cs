using UnityEngine;

using TankGame.Sound;

namespace TankGame.Menu 
{
    public class PlayMusicOnStart : MonoBehaviour
    {
        [SerializeField] private string musicName;

        private void Start()
        {
            AudioManager.Instance.SetMusic(musicName);

            AudioManager.Instance.PlayMusic();
        }
    }
}