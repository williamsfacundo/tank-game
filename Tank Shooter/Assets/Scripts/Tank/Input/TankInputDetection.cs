using System;

using UnityEngine;

using TankGame.Enumerators;

namespace TankGame.Tank.Input
{
    public class TankInputDetection : MonoBehaviour
    {
        [SerializeField] private string moveInputAxis;

        [SerializeField] private string rotateInputAxis;

        [SerializeField] private MouseButtonEnum shootInputButton;     

        private float moveAxisValue;

        private float rotateAxisValue;

        public event Action OnShootClicked;

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

        private void Update()
        {
            moveAxisValue = UnityEngine.Input.GetAxisRaw(moveInputAxis);            

            rotateAxisValue = UnityEngine.Input.GetAxisRaw(rotateInputAxis);

            if (UnityEngine.Input.GetMouseButton((int)shootInputButton))
            {
                OnShootClicked?.Invoke();
            }            
        }
    }
}