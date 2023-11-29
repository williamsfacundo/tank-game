using UnityEngine;

using TankGame.Tank.Input;

namespace TankGame.Tank.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(TankInputDetection))]
    public class TankFrontalMovement : MonoBehaviour
    {
        [SerializeField] [Range(10f, 100.0f)] private float moveAcceleration;

        [SerializeField] [Range(1.0f, 50.0f)] private float maxMoveAcceleration;

        private Rigidbody rigidBody;

        private TankInputDetection inputDetection;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();

            inputDetection = GetComponent<TankInputDetection>();
        }

        private void Start()
        {
            rigidBody.isKinematic = false;            
        }        

        private void FixedUpdate()
        {
            AccelerateTank();
        }

        private void AccelerateTank() 
        {
            if (rigidBody.velocity.magnitude < maxMoveAcceleration) 
            {
                rigidBody.velocity += transform.forward * moveAcceleration * UnityEngine.Time.deltaTime * inputDetection.MoveAxisValue;
            }
        }
    }
}