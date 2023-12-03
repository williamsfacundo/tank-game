using UnityEngine;

namespace TankGame.Sphere.Movement 
{
    public class SphereJump : ISphereMoveBehaviour
    {
        private Rigidbody sphereRigidBody;

        private float sphereJumpForce;

        public SphereJump(Rigidbody sphereRigidBody, float jumpForce) 
        {
            this.sphereRigidBody = sphereRigidBody;

            sphereJumpForce = jumpForce;
        }

        public void MoveBehaviour()
        {
            if (sphereRigidBody.velocity.y <= 0.0f) 
            {
                sphereRigidBody.AddForce(Vector3.up * sphereJumpForce, ForceMode.Acceleration);
            }
        }
    }
}