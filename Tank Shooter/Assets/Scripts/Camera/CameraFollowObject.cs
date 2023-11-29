using UnityEngine;
using UnityEngine.Rendering;

namespace TankGame.Camera 
{
    public class CameraFollowObject : MonoBehaviour
    {
        [SerializeField] private string targetObjectName;

        [SerializeField] private Vector3 cameraDistanceOffset;

        [SerializeField] private Vector3 cameraRotation;

        private GameObject targetObject; 

        private void Awake()
        {
            targetObject = GameObject.Find(targetObjectName);

            if (targetObject == null) 
            {
                Debug.Log("None game object with the name " + targetObjectName + " was found!");
            }
        }

        private void Start()
        {
            transform.eulerAngles = cameraRotation;
        }

        private void LateUpdate()
        {
            if (targetObject != null) 
            {
                transform.position = targetObject.transform.position + cameraDistanceOffset;
            }
        }
    }
}