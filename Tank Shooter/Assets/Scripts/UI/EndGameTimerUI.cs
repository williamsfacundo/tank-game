using UnityEngine;

using TMPro;

using TankGame.Gameplay;

namespace TankGame.UI 
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class EndGameTimerUI : MonoBehaviour
    {
        private TextMeshProUGUI endGameTimerText;

        private GameplayTimer gameplayTimer;

        private void Awake()
        {
            endGameTimerText = GetComponent<TextMeshProUGUI>();

            gameplayTimer = GameObject.Find("Gameplay Manager").GetComponent<GameplayTimer>();
        }

        void Start()
        {
            UpdateEndGameTimerText();
        }

        void Update()
        {
            UpdateEndGameTimerText();
        }

        private void UpdateEndGameTimerText()
        {
            endGameTimerText.text = ((int)gameplayTimer.endGameTimer.CurrentTime).ToString();
        }
    }
}