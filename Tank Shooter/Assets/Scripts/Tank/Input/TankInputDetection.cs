using UnityEngine;

namespace TankGame.Tank.Input
{
    public class TankInputDetection : MonoBehaviour
    {
        [SerializeField] private string moveInputAxis;

        [SerializeField] private string rotateInputAxis;

        [SerializeField] private string shootInputAxis;     

        private float moveAxisValue;

        private float rotateAxisValue;

        private float shootAxisValue;

        public float MoveAxisValue
        {
            get 
            {
                return moveAxisValue;
            }
        }

        public float RotateAxisValue 
        {
            get 
            {
                return rotateAxisValue;
            }
        }

        public float ShootAxisValue 
        {
            get 
            {
                return shootAxisValue;
            }
        }

        private void Update()
        {
            moveAxisValue = UnityEngine.Input.GetAxisRaw(moveInputAxis);            

            rotateAxisValue = UnityEngine.Input.GetAxisRaw(rotateInputAxis);            

            shootAxisValue = UnityEngine.Input.GetAxisRaw(shootInputAxis);            
        }
    }
}