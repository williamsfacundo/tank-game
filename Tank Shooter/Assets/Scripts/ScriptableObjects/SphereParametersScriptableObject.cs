using System.ComponentModel;
using UnityEngine;

namespace TankGame.ScriptableObjects 
{
    [CreateAssetMenu(fileName = "SphereStats", menuName = "ScriptableObjects/SphereParameters", order = 1)]
    public class SphereParametersScriptableObject : ScriptableObject
    {
        public LayerMask FloorLayerMask;

        [Range(1.0f, 30.0f)] public float SphereMoveSpeed;

        [Range(1.0f, 100.0f)] public float SphereJumpForce;

        [Range(0.1f, 5.0f)] public float FloorDistanceToTriggerJump;

        public string TargetName;
    }
}