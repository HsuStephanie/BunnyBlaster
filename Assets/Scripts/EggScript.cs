using UnityEngine;

public class EggScript : MonoBehaviour
{
    
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private Transform pivotPoint;

    
    // Start is called before the first frame update
    void Start()
    {
       // Apply random rotation to start the egg spinning
        float randomXRotation = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(randomXRotation, 90f, 90f);

    }

    // Update is called once per frame
    void Update()
    {
       
        Rotate();
      
    }
    
 
    void Rotate()
    {
        float angle = rotationSpeed * Time.deltaTime;
        transform.RotateAround(pivotPoint.position, Vector3.forward, angle);
    }
    
}
