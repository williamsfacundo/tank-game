using UnityEngine;

using TankGame.Time;

namespace TankGame.Gameplay 
{
    public class GameplayTimer : MonoBehaviour
    {
        [SerializeField] private float gameDuration;

        public Timer endGameTimer;

        private void Awake()
        {
            endGameTimer = new Timer(gameDuration, true, false);
        }

        void Update()
        {
            endGameTimer.UpdateTimer();                    
        }
    }
}