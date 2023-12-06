using System;

using UnityEngine;

namespace TankGame.Tank.Collisions 
{
    public class TankCollisionWithEnemy : MonoBehaviour
    {
        [SerializeField] private string enemyTag;

        public static event Action OnCollisionWithEnemy;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == enemyTag) 
            {
                OnCollisionWithEnemy?.Invoke();
            }            
        }
    }
}