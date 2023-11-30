using UnityEngine;

using TankGame.Colliders;

namespace TankGame.Tank.Environment
{
    public class TankBehaviourWithEnvironment : MonoBehaviour
    {
        [SerializeField] private Vector3 initialPosition;

        private ColliderDetector colliderDetector;

        private void Awake()
        {
            colliderDetector = FindObjectOfType<ColliderDetector>();

            if (colliderDetector == null) 
            {
                Debug.Log("No collider detector was found in scene!");
            }
        }

        private void Start()
        {
            if (colliderDetector != null) 
            {
                colliderDetector.onExit += ResetPosition;
            }
        }

        private void OnDestroy()
        {
            if (colliderDetector != null)
            {
                colliderDetector.onExit -= ResetPosition;
            }
        }

        private void ResetPosition(GameObject gameObject) 
        {
            transform.position = initialPosition;
        }
    }
}