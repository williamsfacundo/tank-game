using System;

using UnityEngine;

namespace TankGame.Tank.Turret
{
    public class TurretRotationSystem : MonoBehaviour
    {       
        public event Action OnNeededRotationAchieved;

        private const float MaxTime = 1.0f;

        private Quaternion necessaryRotation;

        private float time;

        private bool isRotating;

        private void Awake()
        {
            enabled = false;
        }

        private void Start()
        {
            isRotating = false;
        }

        void Update()
        {
            if (isRotating) 
            {
                time += UnityEngine.Time.deltaTime;

                if (time > MaxTime) 
                {
                    time = MaxTime;
                    
                    isRotating = false;

                    enabled = false;

                    transform.rotation = Quaternion.Slerp(transform.rotation, necessaryRotation, time);

                    OnNeededRotationAchieved?.Invoke();
                }
                else 
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, necessaryRotation, time);
                }
            }
        }

        public void StartRotationSequence(Vector3 targetPosition)
        {
            if (!isRotating) 
            {
                time = 0.0f;

                enabled = true;

                isRotating = true;

                CalculateRotation(targetPosition);
            }
        }

        private void CalculateRotation(Vector3 targetPosition)
        {
            Vector3 targetPositionWithSameY = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

            Vector3 direction = targetPositionWithSameY - transform.position;

            necessaryRotation = Quaternion.LookRotation(direction);
        }
    }
}