using System.Collections.Generic;

using UnityEngine;

using TankGame.Projectile;

namespace TankGame.Tank.Combat 
{
    public class ProjectilesPool : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;

        [SerializeField] [Range(1, 20)] private short poolSize;

        private List<ProjectileCore> projectiles;

        private void Awake()
        {
            if (projectilePrefab.GetComponent<ProjectileCore>() == null) 
            {
                Debug.LogError("The prefab selected do not contain projectile core component!");
            }
            else 
            {
                CreateProjectilesList();
            }           
        }

        public bool ActivateProjectile(Transform launcherTransform) 
        {
            for (int i = 0; i < projectiles.Count; i++) 
            {
                if (!projectiles[i].gameObject.activeSelf) 
                {
                    projectiles[i].Activate(launcherTransform);

                    return true;
                } 
            }

            return false;
        }

        private void CreateProjectilesList() 
        {
            projectiles = new List<ProjectileCore>();

            for (int i = 0; i < poolSize; i++)
            {
                projectiles.Add(Instantiate(projectilePrefab).GetComponent<ProjectileCore>());

                projectiles[i].gameObject.SetActive(false);
            }
        }
    }
}