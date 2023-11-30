using UnityEngine;

using TankGame.Time;

namespace TankGame.Projectile
{
    public class ProjectileCore : MonoBehaviour
    {
        [SerializeField] [Range(1.0f, 10.0f)] private float projectileLifeTime;

        private Timer lifeTimeTimer;

        private void Awake()
        {
            lifeTimeTimer = new Timer(projectileLifeTime, true, false);
        }

        private void Start()
        {
            lifeTimeTimer.OnTimerEnds += Deactivate;

        }

        private void Update()
        {
            lifeTimeTimer.UpdateTimer();
        }

        private void OnDestroy()
        {
            lifeTimeTimer.OnTimerEnds -= Deactivate;
        }

        public void Activate(Transform launcherTransform) 
        {
            gameObject.SetActive(true);

            lifeTimeTimer.ResetTime();
        }

        private void Deactivate() 
        {
            gameObject.SetActive(false);
        }
    }
}