using System.Collections;
using System.Security.Principal;
using UnityEngine;

public class TargetMovementScript : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speed = 10f;


    [Header ("Boundaries")]
    [SerializeField] private float minXRange = -2.4f;
    [SerializeField] private float maxXRange = 2.0f;
    [SerializeField] private float minYRange = 0.3f;
    [SerializeField] private float maxYRange = 1.85f;

    [SerializeField] private float zPos= -1.85f;


    [Header ("Player")]
    [SerializeField] private GameObject player;

    [Header ("Projectile")]
    [SerializeField] private GameObject projectile;
    [SerializeField] public int maxProjectiles = 19;
    [SerializeField] public int countProjectiles=0;
    [SerializeField] public bool shooting = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        TargetMovement();
        InstantiateProjectile();

    }

    private void TargetMovement()
    {
        //check for out of bounds
        if (transform.position.x < minXRange)
        {
            transform.position = new Vector3(minXRange, transform.position.y, zPos);
        }
        if (transform.position.x > maxXRange)
        {
            transform.position = new Vector3(maxXRange, transform.position.y, zPos);
        }


        if (transform.position.y <minYRange)
        {
            transform.position = new Vector3 (transform.position.x, minYRange, zPos);
        }
        if (transform.position.y > maxYRange)
        {
            transform.position = new Vector3 (transform.position.x, maxYRange, zPos);
        }

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += moveDirection * speed * Time.deltaTime;
        
        
    }

    private void InstantiateProjectile ()
    {
       
        if (countProjectiles <=maxProjectiles)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
            shooting = true;
            countProjectiles+=1;
            Instantiate(projectile,player.transform.position,Quaternion.identity);
            shooting = false;
            }
           
        }
       
        
    }



}

   


