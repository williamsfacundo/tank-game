using UnityEngine;

using TankGame.Time;

namespace TankGame.Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileCore : MonoBehaviour
    {
        [SerializeField] [Range(1.0f, 10.0f)] private float projectileLifeTime;

        [SerializeField] [Range(10.0f, 100.0f)] private float projectileVelocity;

        private Rigidbody thisRigidBody;

        private Timer lifeTimeTimer;

        private void Awake()
        {
            thisRigidBody = GetComponent<Rigidbody>();            

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

            thisRigidBody.MovePosition(launcherTransform.position);

            thisRigidBody.velocity = launcherTransform.forward * projectileVelocity;

            lifeTimeTimer.ResetTime();
        }

        private void Deactivate() 
        {
            gameObject.SetActive(false);
        }
    }
}