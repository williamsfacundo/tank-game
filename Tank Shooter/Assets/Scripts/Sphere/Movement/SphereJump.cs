using TankGame.ScriptableObjects;
using UnityEngine;

namespace TankGame.Sphere.Movement 
{
    public class SphereJump : ISphereMoveBehaviour
    {
        private const float additionalSecuritySpace = 0.15f;

        private Rigidbody sphereRigidBody;

        private Transform sphereBottomTransform;

        private Ray rayToFloor;

        private LayerMask floorLayerMask;
        
        private float sphereJumpForce;

        private float floorDistanceToTriggerJump;

        private float distanceToFloor;

        public SphereJump(Rigidbody sphereRigidBody, Transform sphereBottomTransform,SphereParametersScriptableObject sphereStats) 
        {
            this.sphereRigidBody = sphereRigidBody;

            this.sphereBottomTransform = sphereBottomTransform;

            rayToFloor = new Ray(sphereBottomTransform.position, Vector3.down);

            this.floorLayerMask = sphereStats.FloorLayerMask;

            this. sphereJumpForce = sphereStats.SphereJumpForce;

            this.floorDistanceToTriggerJump = sphereStats.FloorDistanceToTriggerJump;

            distanceToFloor = 0.0f;
        }

        public void MoveBehaviour()
        {
            rayToFloor.origin = sphereBottomTransform.position;

            if (Physics.Raycast(rayToFloor, out RaycastHit hit, Mathf.Infinity, floorLayerMask)) 
            {
                distanceToFloor = hit.distance;
            }

            if (distanceToFloor <= floorDistanceToTriggerJump) 
            {
                sphereRigidBody.MovePosition(sphereRigidBody.transform.position + new Vector3(0.0f, Mathf.Abs(distanceToFloor - floorDistanceToTriggerJump) + additionalSecuritySpace, 0.0f));

                sphereRigidBody.AddForce(Vector3.up * sphereJumpForce, ForceMode.Impulse);
            }
        }
    }
}