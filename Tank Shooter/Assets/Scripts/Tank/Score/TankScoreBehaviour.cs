using System;

using UnityEngine;

namespace TankGame.Tank.Score 
{
    public class TankScoreBehaviour : MonoBehaviour
    {
        [SerializeField] [Range(1, 10000)] private int pointsPerObjectiveDestroyed;

        public event Action OnTankScoreChanged;

        private static int spheresDestroyed = 0;

        private static int tankScore = 0;

        public static int SpheresDestroyed 
        {
            get 
            {
                return spheresDestroyed;
            }
        }

        public static int TankScore 
        {
            get 
            {
                return tankScore;
            }
        }

        private void Start()
        {
            tankScore = 0;

            spheresDestroyed = 0;

            OnTankScoreChanged.Invoke();

            SphereHealth.OnSphereDestroyed += RiseSpheresDestroyCount;

            SphereHealth.OnSphereDestroyed += AddScore;
        }

        private void OnDestroy()
        {
            SphereHealth.OnSphereDestroyed -= RiseSpheresDestroyCount;

            SphereHealth.OnSphereDestroyed -= AddScore;
        }

        private void AddScore() 
        {
            tankScore += pointsPerObjectiveDestroyed;

            OnTankScoreChanged?.Invoke();
        }

        private void RiseSpheresDestroyCount() 
        {
            spheresDestroyed++;
        }
    }
}