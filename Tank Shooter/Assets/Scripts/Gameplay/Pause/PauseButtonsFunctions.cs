using UnityEngine;

using TankGame.Scenes;

namespace TankGame.Gameplay.Pause 
{
    public class PauseButtonsFunctions : MonoBehaviour
    {
        private GameplayCanvasManager gameplayCanvasManager;

        private void Awake()
        {
            gameplayCanvasManager = GameObject.FindWithTag("GameController").GetComponent<GameplayCanvasManager>();
        }

        public void ResumeGameplay() 
        {
            gameplayCanvasManager.PauseResumeGameplay();
        }

        public void ChangeSceneToMainMenu() 
        {
            ScenesLoader.LoadMainMenuScene();
        }
    }
}