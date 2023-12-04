using UnityEngine;

using TankGame.Scenes;

namespace TankGame.Gameplay 
{
    public class GameplayEndGameTrigger : MonoBehaviour
    {
        private void Start()
        {
            SphereHealth.OnAllSpheresDisabled += TriggerEndGame;
        }

        private void OnDestroy()
        {
            SphereHealth.OnAllSpheresDisabled -= TriggerEndGame;
        }

        private void TriggerEndGame() 
        {
            ScenesLoader.LoadEndGameScene();
        }
    }
}