using Unity.VisualScripting;
using UnityEngine;

namespace TankGame.Gameplay 
{
    public class GameplayCanvasManager : MonoBehaviour
    {
        [SerializeField] private KeyCode[] pauseGameKeys;        

        [SerializeField] private GameObject pauseMenuUI;

        [SerializeField] private GameObject gameplayUI;

        private void Awake()
        {
            if (pauseMenuUI == null)
            {
                Debug.Log("No pause menu UI game object was selected!");
            }
            else 
            {
                pauseMenuUI.SetActive(false);
            }

            if (gameplayUI == null)
            {
                Debug.Log("No gameplay UI game object was selected!");
            }
            else
            {
                gameplayUI.SetActive(true);            
            }
        }

        private void Start()
        {
            UnityEngine.Time.timeScale = 1.0f;
        }

        private void Update()
        {
            PauseResumeGameplayInput();
        }

        public void PauseResumeGameplay()
        {
            SwitchUIs();

            StopResumeGameplayTime();
        }

        private void PauseResumeGameplayInput() 
        {
            for (short i = 0; i < pauseGameKeys.Length; i++)
            {
                if (Input.GetKeyDown(pauseGameKeys[i]))
                {
                    SwitchUIs();

                    StopResumeGameplayTime();

                    break;
                }
            }
        }        

        private void SwitchUIs() 
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

            gameplayUI.SetActive(!gameplayUI.activeSelf);
        }

        private void StopResumeGameplayTime() 
        {
            if (pauseMenuUI.activeSelf) 
            {
                UnityEngine.Time.timeScale = 0.0f;
            }
            else 
            {
                UnityEngine.Time.timeScale = 1.0f;
            }
        }
    }
}