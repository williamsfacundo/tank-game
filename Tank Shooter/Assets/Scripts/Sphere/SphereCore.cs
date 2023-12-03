using UnityEngine;

using TankGame.ScriptableObjects;
using TankGame.Sphere.Movement;

namespace TankGame.Sphere 
{
    [RequireComponent(typeof(Rigidbody))]
    public class SphereCore : MonoBehaviour
    {
        private const int SphereMoveBehavioursCount = 2;

        [SerializeField] private SphereParametersScriptableObject sphereStats;

        [SerializeField] private Transform sphereBottomTransform;

        private ISphereMoveBehaviour sphereMoveBehaviour;

        private void Awake()
        {  
            sphereMoveBehaviour = ReturnRandomMoveBehaviour();
        }

        private void FixedUpdate()
        {
            sphereMoveBehaviour.MoveBehaviour();
        }

        private ISphereMoveBehaviour ReturnRandomMoveBehaviour() 
        {
            switch (Random.Range(0, SphereMoveBehavioursCount)) 
            {
                case 0:
                    return new SphereMoveTowardsObject(GetComponent<Rigidbody>(), GameObject.Find(sphereStats.TargetName).transform, sphereStats.SphereMoveSpeed);
                case 1:
                    return new SphereJump(GetComponent<Rigidbody>(), sphereBottomTransform, sphereStats);
                default:
                    return new SphereMoveTowardsObject(GetComponent<Rigidbody>(), GameObject.Find(sphereStats.TargetName).transform, sphereStats.SphereMoveSpeed);
            }
        }
    }
}