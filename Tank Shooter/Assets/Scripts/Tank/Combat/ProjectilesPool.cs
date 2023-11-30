using System.Collections.Generic;

using UnityEngine;

using TankGame.Projectile;

namespace TankGame.Tank.Combat 
{
    public class ProjectilesPool : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        
        [SerializeField] private Transform canyonTipTransform;

        [SerializeField] [Range(1, 20)] private short poolSize;

        private List<ProjectileCore> projectiles;

        public int MaxProjectiles 
        {
            get 
            {
                return projectiles.Count;
            }
        }

        private void Awake()
        {
            if (canyonTipTransform == null)
            {
                Debug.LogError("Canyon tip transform was not assigned!");
            }

            if (projectilePrefab.GetComponent<ProjectileCore>() == null) 
            {
                Debug.LogError("The prefab selected do not contain projectile core component!");
            }
            else 
            {
                CreateProjectilesList();
            }           
        }

        public void ActivateProjectile() 
        {
            for (int i = 0; i < projectiles.Count; i++) 
            {
                if (!projectiles[i].gameObject.activeSelf) 
                {
                    projectiles[i].Activate(canyonTipTransform);

                    break;
                } 
            }                        
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