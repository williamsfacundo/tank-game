using UnityEngine.SceneManagement;

namespace TankGame.Scenes
{
    public static class ScenesLoader
    {
        public static void LoadMainMenuScene() 
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        public static void LoadGameplayScene()
        {
            SceneManager.LoadScene("GameplayScene");
        }

        public static void LoadEndGameScene()
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}