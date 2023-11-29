using UnityEngine;

using TankGame.Tank.Input;

namespace TankGame.Tank.Movement 
{
    [RequireComponent(typeof(Rigidbody), typeof(TankInputDetection))]
    public class TankRotation : MonoBehaviour
    {
        [SerializeField][Range(40f, 120.0f)] private float rotationAcceleration;        

        private Rigidbody rigidBody;

        private TankInputDetection inputDetection;

        private Vector3 auxRotationVector;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();

            inputDetection = GetComponent<TankInputDetection>();
        }

        private void Start()
        {
            auxRotationVector = new Vector3(0.0f, rotationAcceleration, 0.0f);
        }

        private void FixedUpdate()
        {
            RotateTank();           
        }

        private void RotateTank()
        {
            rigidBody.angularVelocity = auxRotationVector * Time.deltaTime * inputDetection.RotateAxisValue;            
        }
    }
}