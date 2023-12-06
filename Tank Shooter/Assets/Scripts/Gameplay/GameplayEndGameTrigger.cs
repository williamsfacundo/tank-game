using UnityEngine;

using TankGame.Scenes;
using TankGame.Tank.Collisions;

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

            TankCollisionWithEnemy.OnCollisionWithEnemy += TriggerEndGame;
        }

        private void OnDestroy()
        {
            SphereHealth.OnAllSpheresDisabled -= TriggerEndGame;

            gameplayTimer.endGameTimer.OnTimerEnds -= TriggerEndGame;

            TankCollisionWithEnemy.OnCollisionWithEnemy -= TriggerEndGame;
        }

        private void TriggerEndGame() 
        {
            ScenesLoader.LoadEndGameScene();
        }
    }
}