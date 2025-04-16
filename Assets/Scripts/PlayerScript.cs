using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
 {
//     [Header("Speed")]
//     [SerializeField] private float speed = 0.50f;


//     [Header ("Boundaries")]
//     [SerializeField] private int xRange = 1;

        [Header ("Target")]
        
        [SerializeField] private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target");
    }


    // Update is called once per frame
    void Update()
    {
        
    }


 }