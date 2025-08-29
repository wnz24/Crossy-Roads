using UnityEngine;

namespace Benjathemaker
{
    public class SimpleGemSpin : MonoBehaviour
    {
        [Header("Rotation Settings")]
        public float rotationSpeed = 90f; 
        public Vector3 rotationAxis = Vector3.up; 

        void Update()
        {
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        }
    }
}
