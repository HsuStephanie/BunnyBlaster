using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speed = 0.50f;


    [Header ("Boundaries")]
    [SerializeField] private int xRange = 1;

    


    // Update is called once per frame
    void Update()
    {
        //check for out of bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += moveDirection * speed * Time.deltaTime;
        
        
        Input.GetKeyDown(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(1))
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
             if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }
    }

}
