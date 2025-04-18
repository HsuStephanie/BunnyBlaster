using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] public float rotationAngle = 15f; // Maximum angle of rotation
    [SerializeField] public float rotationSpeed = 2f;  // Speed of the rotation

    [SerializeField] float currentRotation = 0f;

    [SerializeField] float direction = 1f;

    [SerializeField] private Transform pivotPoint;


    void Update()
    {
         float angle = rotationSpeed * Time.deltaTime * direction;

        // Rotate around the pivot object's position, along its forward (Z) axis
        transform.RotateAround(pivotPoint.position, Vector3.forward, angle);

        currentRotation += angle;

        if (Mathf.Abs(currentRotation) >= rotationAngle)
        {
            direction *= -1f; // Reverse direction
        }

        
    }
}
