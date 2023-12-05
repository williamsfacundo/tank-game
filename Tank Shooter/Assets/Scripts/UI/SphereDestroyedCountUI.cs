using UnityEngine;

using TMPro;
using TankGame.Tank.Score;

namespace TankGame.UI 
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SphereDestroyedCountUI : MonoBehaviour
    {
        private TextMeshProUGUI sphereText;

        private TankScoreBehaviour tankScoreBehaviour;

        private void Awake()
        {
            sphereText = GetComponent<TextMeshProUGUI>();

            tankScoreBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<TankScoreBehaviour>();

            tankScoreBehaviour.OnTankScoreChanged += UpdateSphereText;
        }

        private void OnDestroy()
        {
            tankScoreBehaviour.OnTankScoreChanged -= UpdateSphereText;
        }

        private void UpdateSphereText()
        {
            sphereText.text = TankScoreBehaviour.SpheresDestroyed.ToString();
        }
    }
}