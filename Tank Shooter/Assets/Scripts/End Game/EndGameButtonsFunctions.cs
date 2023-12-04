using UnityEngine;

using UnityEngine.UI;

using TankGame.Scenes;

namespace TankGame.EndGame 
{
    public class EndGameButtonsFunctions : MonoBehaviour
    {
        [SerializeField] private Button mainMenuButton;

        private void Start()
        {
            if (mainMenuButton != null) 
            {
                mainMenuButton.onClick.AddListener(ChangeSceneToMainMenu);
            }
            else 
            {
                Debug.Log("Main menu button was not assigned!");
            }
        }

        private void OnDestroy()
        {
            if (mainMenuButton != null) 
            {
                mainMenuButton.onClick.RemoveListener(ChangeSceneToMainMenu);
            }
        }

        private void ChangeSceneToMainMenu() 
        {
            ScenesLoader.LoadMainMenuScene();
        }
    }
}