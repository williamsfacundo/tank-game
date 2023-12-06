using UnityEngine;

using TankGame.Time;
using TankGame.Interfaces;

namespace TankGame.Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public class ProjectileCore : MonoBehaviour
    {
        [SerializeField] [Range(1.0f, 10.0f)] private float projectileLifeTime;

        [SerializeField] [Range(10.0f, 100.0f)] private float projectileVelocity;

        private Rigidbody thisRigidBody;

        private ParticleSystem[] particles;

        private Timer lifeTimeTimer;        

        private void Awake()
        {
            thisRigidBody = GetComponent<Rigidbody>();

            particles = GetComponentsInChildren<ParticleSystem>();

            lifeTimeTimer = new Timer(projectileLifeTime, true, false);
        }

        private void Start()
        {
            lifeTimeTimer.OnTimerEnds += Deactivate;

            for (short i = 0; i < particles.Length; i++)
            {
                particles[i].Clear();

                particles[i].Play();
            }
        }

        private void OnEnable()
        {
            for (short i = 0; i < particles.Length; i++)
            {
                particles[i].Clear();

                particles[i].Play();
            }
        }

        private void OnDisable()
        {
            for (short i = 0; i < particles.Length; i++)
            {
                particles[i].Stop();                
            }
        }

        private void Update()
        {
            lifeTimeTimer.UpdateTimer();            
        }

        private void OnCollisionEnter(Collision collision)
        {
            Deactivate();

            IDamaged damagedObject = collision.gameObject.GetComponent<IDamaged>();
            
            if (damagedObject != null)
            {
                damagedObject.DamageReceived();
            }
        }

        private void OnDestroy()
        {
            lifeTimeTimer.OnTimerEnds -= Deactivate;
        }

        public void Activate(Transform launcherTransform) 
        {
            thisRigidBody.transform.position = launcherTransform.position;            

            thisRigidBody.velocity = launcherTransform.forward * projectileVelocity;            

            gameObject.SetActive(true);

            lifeTimeTimer.ResetTime();
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}