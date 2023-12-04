using System;

using UnityEngine;

namespace TankGame.Tank.Score 
{
    public class TankScoreBehaviour : MonoBehaviour
    {
        [SerializeField] [Range(1, 10000)] private int pointsPerObjectiveDestroyed;

        private int tankScore;

        public event Action OnTankScoreChanged;

        public int TankScore 
        {
            get 
            {
                return tankScore;
            }
        }

        private void Start()
        {
            tankScore = 0;

            SphereHealth.OnSphereDestroyed += AddScore;
        }

        private void OnDestroy()
        {
            SphereHealth.OnSphereDestroyed -= AddScore;
        }

        private void AddScore() 
        {
            tankScore += pointsPerObjectiveDestroyed;

            OnTankScoreChanged?.Invoke();
        }
    }
}