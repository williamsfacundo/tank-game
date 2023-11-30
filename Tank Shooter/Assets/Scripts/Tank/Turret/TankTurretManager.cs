using UnityEngine;

using TankGame.Tank.Input;
using TankGame.Tank.Combat;
using TankGame.Projectile;

namespace TankGame.Tank.Turret 
{
    [RequireComponent(typeof(TankInputDetection), typeof(TankFireProjectile), typeof(ProjectilesPool))]
    public class TankTurretManager : MonoBehaviour
    {
        [SerializeField] private TurretRotationSystem rotationSystem;

        private TankInputDetection inputDetection;

        private TankFireProjectile fireProjectile;

        private ProjectilesPool projectilesPool;

        private void Awake()
        {
            if (rotationSystem == null) 
            {
                Debug.LogError("Turret rotation behaviour was not assigned!");
            }

            inputDetection = GetComponent<TankInputDetection>();

            fireProjectile = GetComponent<TankFireProjectile>();

            projectilesPool = GetComponent<ProjectilesPool>();
        }

        private void Start()
        {
            rotationSystem.OnNeededRotationAchieved += fireProjectile.FireProjectile;

            inputDetection.OnShootClicked += ActivateTurretRotationIfRequirementsAreMet;
        }

        private void OnDestroy()
        {
            rotationSystem.OnNeededRotationAchieved -= fireProjectile.FireProjectile;

            inputDetection.OnShootClicked -= ActivateTurretRotationIfRequirementsAreMet;
        }

        private void ActivateTurretRotationIfRequirementsAreMet() 
        {
            bool objectHit;

            Vector3 positionForTurretRotation = GetPositionFromCameraRayHitObjectInScene(out objectHit);

            if (!fireProjectile.CoolDownTimer.IsRunning && ProjectileInstances.InstancesEnable < projectilesPool.MaxProjectiles && objectHit) 
            {
                rotationSystem.StartRotationSequence(positionForTurretRotation);
            }
        }

        private Vector3 GetPositionFromCameraRayHitObjectInScene(out bool objectHit) 
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);

            RaycastHit hit;

            objectHit = false;


            if (Physics.Raycast(ray, out hit))
            {
                objectHit = true;

                return hit.point;
            }

            return Vector3.zero;
        }
    }
}