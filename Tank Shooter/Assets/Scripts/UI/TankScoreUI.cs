using UnityEngine;

using TMPro;

using TankGame.Tank.Score;

namespace TankGame.UI 
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TankScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI tankScoreText;

        private TankScoreBehaviour tankScoreBehaviour;

        private void Awake()
        {
            tankScoreText = GetComponent<TextMeshProUGUI>();

            tankScoreBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<TankScoreBehaviour>();            
        }

        private void Start()
        {
            UpdateTankScoreText();

            tankScoreBehaviour.OnTankScoreChanged += UpdateTankScoreText;
        }

        private void OnDestroy()
        {
            tankScoreBehaviour.OnTankScoreChanged -= UpdateTankScoreText;
        }

        private void UpdateTankScoreText()
        {
            tankScoreText.text = TankScoreBehaviour.TankScore.ToString();
        }
    }
}