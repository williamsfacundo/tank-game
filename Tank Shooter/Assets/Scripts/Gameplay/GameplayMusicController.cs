using TankGame.Sound;
using UnityEngine;

namespace TankGame.Gameplay 
{
    [RequireComponent(typeof(GameplayCanvasManager))]
    public class GameplayMusicController : MonoBehaviour
    {
        [SerializeField] private string gameplayMusicName;

        [SerializeField] private string pauseMusicName;

        private GameplayCanvasManager canvasManager;

        private void Awake()
        {
            canvasManager = GetComponent<GameplayCanvasManager>();
        }

        private void Start()
        {
            canvasManager.OnGameplayActivated += PlayGameplayMusic;

            canvasManager.OnPauseActivated += PlayPauseMenuMusic;
        }

        private void OnDestroy()
        {
            canvasManager.OnGameplayActivated -= PlayGameplayMusic;

            canvasManager.OnPauseActivated += PlayPauseMenuMusic;
        }

        public void PlayGameplayMusic() 
        {
            AudioManager.Instance.SetMusic(gameplayMusicName);

            AudioManager.Instance.PlayMusic();
        }

        public void PlayPauseMenuMusic() 
        {
            AudioManager.Instance.SetMusic(pauseMusicName);

            AudioManager.Instance.PlayMusic();
        }
    }
}