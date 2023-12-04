using UnityEngine;

using TankGame.Scenes;
using UnityEngine.UI;

namespace TankGame.Menu 
{
    public class MenuButtonsFunctions : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        [SerializeField] private Button exitButton;        

        private void Start()
        {
            playButton.onClick.AddListener(StartGameplayOnClick);

            exitButton.onClick.AddListener(ExitGameOnClick);            
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveAllListeners();

            exitButton.onClick.RemoveAllListeners();
        }

        private void StartGameplayOnClick() 
        {
            ScenesLoader.LoadGameplayScene();
        }

        private void ExitGameOnClick() 
        {
            Application.Quit();
        }
    }
}