using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementScript : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public LayerMask layersToHit;
    
     // Update is called once per frame
    void Update()
    {
            screenPosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hitData, 100, layersToHit))
            {
                worldPosition = hitData.point;
            }
            transform.position = worldPosition;
    }
}

