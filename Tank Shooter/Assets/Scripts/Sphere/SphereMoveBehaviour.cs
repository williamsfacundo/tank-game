using UnityEngine;

namespace TankGame.Sphere 
{
    [RequireComponent(typeof(Rigidbody))]
    public class SphereMoveBehaviour : MonoBehaviour
    {
        [SerializeField][Range(1.0f, 50.0f)] private float speed;

        [SerializeField] private string targetName;

        private GameObject targetObject;

        private Rigidbody myRigidbody;

        private void Awake()
        {
            targetObject = GameObject.Find(targetName);

            myRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            transform.LookAt(targetObject.transform);

            myRigidbody.velocity = transform.forward * speed;
        }
    }
}