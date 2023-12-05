using UnityEngine;

using TMPro;

using TankGame.Tank.Score;

namespace TankGame.EndGame 
{
    public class EndGameTextsSetters : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI spheresDestroyedText;

        void Start()
        {
            spheresDestroyedText.text = TankScoreBehaviour.SpheresDestroyed.ToString();
        }
    }
}