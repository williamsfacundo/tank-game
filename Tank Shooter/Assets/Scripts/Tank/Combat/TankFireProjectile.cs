using UnityEngine;

using TankGame.Tank.Input;
using TankGame.Time;

namespace TankGame.Tank.Combat 
{
    [RequireComponent(typeof(ProjectilesPool), typeof(TankInputDetection))]
    public class TankFireProjectile : MonoBehaviour
    {
        [SerializeField] private Transform canyonTipTransform;

        [SerializeField] [Range(0.1f, 10.0f)] private float inBetweenShotsCoolDown;

        private ProjectilesPool projectilesPool;

        private TankInputDetection inputDetection;

        private Timer coolDownTimer;

        private bool wasProjectileFired;

        private void Awake()
        {
            if (canyonTipTransform == null) 
            {
                Debug.LogError("Canyon tip transform was not assigned!");
            }

            projectilesPool = GetComponent<ProjectilesPool>();

            inputDetection = GetComponent<TankInputDetection>();

            coolDownTimer = new Timer(inBetweenShotsCoolDown, true, true);
        }

        private void Start()
        {
            inputDetection.onShootClicked += FireProjectile;
        }

        private void Update()
        {
            coolDownTimer.UpdateTimer();
        }

        private void OnDestroy()
        {
            inputDetection.onShootClicked -= FireProjectile;
        }

        private void FireProjectile() 
        {
            if (!coolDownTimer.IsRunning)
            {
                wasProjectileFired = projectilesPool.ActivateProjectile(canyonTipTransform);

                if (wasProjectileFired) 
                {
                    coolDownTimer.ResetTime();
                }
            }
        }
    }
}