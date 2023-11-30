using UnityEngine;

namespace TankGame.Projectile 
{
    public class ProjectileInstances : MonoBehaviour
    {
        public static int InstancesEnable = 0;

        private void OnEnable()
        {
            InstancesEnable++;
        }

        private void OnDisable()
        {
            InstancesEnable--;
        }
    }
}