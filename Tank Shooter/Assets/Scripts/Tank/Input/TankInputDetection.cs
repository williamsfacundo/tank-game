using System;

using UnityEngine;

namespace TankGame.Tank.Input
{
    public class TankInputDetection : MonoBehaviour
    {
        [SerializeField] private string moveHorizontallyInputAxis;

        [SerializeField] private string moveVerticallyInputAxis;

        [SerializeField] private string shootInputAxis;      

        private float moveHorizontallyAxisValue;

        private float moveVerticallyAxisValue;

        private float shootAxisValue;

        public float MoveHorizontallyAxisValue 
        {
            get           
            {
                return moveHorizontallyAxisValue;
            }
        }

        public float MoveVerticallyAxisValue 
        {
            get 
            {
                return moveVerticallyAxisValue;
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
            moveHorizontallyAxisValue = UnityEngine.Input.GetAxisRaw(moveHorizontallyInputAxis);            

            moveVerticallyAxisValue = UnityEngine.Input.GetAxisRaw(moveVerticallyInputAxis);            

            shootAxisValue = UnityEngine.Input.GetAxisRaw(shootInputAxis);            
        }
    }
}