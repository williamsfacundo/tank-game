using UnityEngine;

namespace TankGame.Sphere.Movement
{
    public class SphereMoveTowardsObject : ISphereMoveBehaviour
    {
        private Rigidbody sphereRigidBody;

        private Transform targetTransform;
        
        private float sphereMoveSpeed;        

        public SphereMoveTowardsObject(Rigidbody sphereRigidBody, Transform targetTransform, float sphereMoveSpeed)
        {
            this.sphereRigidBody = sphereRigidBody;

            this.targetTransform = targetTransform;

            this.sphereMoveSpeed = sphereMoveSpeed;           
        }

        public void MoveBehaviour()
        {
            sphereRigidBody.transform.LookAt(targetTransform.transform);

            sphereRigidBody.velocity = sphereRigidBody.transform.forward * sphereMoveSpeed;
        }
    }
}