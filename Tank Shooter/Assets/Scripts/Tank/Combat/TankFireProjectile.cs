using UnityEngine;

using TankGame.Time;

namespace TankGame.Tank.Combat 
{
    [RequireComponent(typeof(ProjectilesPool))]
    public class TankFireProjectile : MonoBehaviour
    {
        [SerializeField] [Range(0.1f, 10.0f)] private float inBetweenShotsCoolDown;

        private ProjectilesPool projectilesPool;        

        private Timer coolDownTimer;

        public Timer CoolDownTimer 
        {
            get 
            { 
                return coolDownTimer;
            }
        }

        private void Awake()
        {
            projectilesPool = GetComponent<ProjectilesPool>();                       

            coolDownTimer = new Timer(inBetweenShotsCoolDown, true, true);
        }

        private void Update()
        {
            coolDownTimer.UpdateTimer();
        }

        public void FireProjectile() 
        {
            projectilesPool.ActivateProjectile();

            coolDownTimer.ResetTime();
        }
    }
}