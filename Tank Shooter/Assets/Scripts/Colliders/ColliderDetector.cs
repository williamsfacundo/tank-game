using System;

using UnityEngine;

using TankGame.Enumerators;

//Code used in another of my projects, refactored for it´s proper use in this one
//Link: https://github.com/lobinuxsoft/weather-guardian/blob/development/Assets/Scripts/Utils/ColliderDetector.cs

namespace TankGame.Colliders 
{
    [RequireComponent(typeof(Collider))]
    public class ColliderDetector : MonoBehaviour
    {
        [SerializeField] private DetectionTypeEnum detectionType;

        [SerializeField] private bool makeItTrigger;
        
        [SerializeField] private string tagToDetect;

        public event Action<GameObject> onEnter;
        public event Action<GameObject> onStay;
        public event Action<GameObject> onExit;

        private Collider thisCollider;

        private void Awake() 
        {
            thisCollider = GetComponent<Collider>();

            thisCollider.isTrigger = makeItTrigger;            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if ((detectionType & DetectionTypeEnum.ENTER) == 0) return;

            if (!collision.collider.CompareTag(tagToDetect)) return;

            onEnter?.Invoke(collision.collider.gameObject);
        }

        private void OnCollisionStay(Collision collision)
        {
            if ((detectionType & DetectionTypeEnum.STAY) == 0) return;

            if (!collision.collider.CompareTag(tagToDetect)) return;

            onStay?.Invoke(collision.collider.gameObject);
        }

        private void OnCollisionExit(Collision collision)
        {
            if ((detectionType & DetectionTypeEnum.EXIT) == 0) return;

            if (!collision.collider.CompareTag(tagToDetect)) return;

            onExit?.Invoke(collision.collider.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if ((detectionType & DetectionTypeEnum.ENTER) == 0) return;

            if (!other.CompareTag(tagToDetect)) return;

            onEnter?.Invoke(other.gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            if ((detectionType & DetectionTypeEnum.STAY) == 0) return;

            if (!other.CompareTag(tagToDetect)) return;

            onStay?.Invoke(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            if ((detectionType & DetectionTypeEnum.EXIT) == 0) return;

            if (!other.CompareTag(tagToDetect)) return;

            onExit?.Invoke(other.gameObject);
        }
    }
}