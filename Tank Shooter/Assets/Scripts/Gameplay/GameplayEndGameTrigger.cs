using UnityEngine;

using TankGame.Scenes;

namespace TankGame.Gameplay 
{
    [RequireComponent(typeof(GameplayTimer))]
    public class GameplayEndGameTrigger : MonoBehaviour
    {
        private GameplayTimer gameplayTimer;

        private void Awake()
        {
            gameplayTimer = GetComponent<GameplayTimer>();
        }

        private void Start()
        {
            SphereHealth.OnAllSpheresDisabled += TriggerEndGame;

            gameplayTimer.endGameTimer.OnTimerEnds += TriggerEndGame;
        }

        private void OnDestroy()
        {
            SphereHealth.OnAllSpheresDisabled -= TriggerEndGame;

            gameplayTimer.endGameTimer.OnTimerEnds -= TriggerEndGame;
        }

        private void TriggerEndGame() 
        {
            ScenesLoader.LoadEndGameScene();
        }
    }
}