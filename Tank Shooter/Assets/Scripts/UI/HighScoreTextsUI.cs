using UnityEngine;

using TMPro;

using TankGame.EndGame;

namespace TankGame.UI
{
    [RequireComponent(typeof(EndGameHighScoreManager))]
    public class HighScoreTextsUI : MonoBehaviour
    {
        private EndGameHighScoreManager highScoreManager;

        [SerializeField] private TextMeshProUGUI[] highScoreTexts;

        [SerializeField] private GameObject highScoreAchievedNotificationUI;

        bool areEnoughTexts;

        private void Awake()
        {
            areEnoughTexts = false;

            highScoreManager = GetComponent<EndGameHighScoreManager>();

            highScoreManager.OnHighScoreChanged += UpdateHighScoreTexts;            

            if (highScoreTexts == null) 
            {
                Debug.LogError("No high score texts were assigned!");
            }
            else if (highScoreTexts.Length != 3) 
            {
                Debug.LogError("3 high score text must be assigned! Currently there are only " + highScoreTexts.Length);
            }
            else 
            {
                areEnoughTexts = true;
            }

            if (highScoreAchievedNotificationUI == null) 
            {
                Debug.LogError("No high score achieved notification UI gameobject was assigned!");
            }
        }

        private void OnDestroy()
        {
            highScoreManager.OnHighScoreChanged -= UpdateHighScoreTexts;
        }

        private void UpdateHighScoreTexts()
        {
            if (highScoreManager != null && areEnoughTexts) 
            {
                highScoreTexts[0].text = highScoreManager.HighScore1.ToString();

                highScoreTexts[1].text = highScoreManager.HighScore2.ToString();

                highScoreTexts[2].text = highScoreManager.HighScore3.ToString();
            }

            if (highScoreAchievedNotificationUI != null) 
            {
                highScoreAchievedNotificationUI.SetActive(highScoreManager.NewHighScoreAchieved);
            }
        }
    }
}