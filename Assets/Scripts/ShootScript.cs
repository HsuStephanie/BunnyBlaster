using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootScript : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private Vector3 spawnPos;

    [Header("Target")]
    private GameObject target;
    public Vector3 targetPos;

    [Header("Player")]
    [SerializeField] private GameObject player;

    void Awake()
    {
        target = GameObject.FindWithTag("target");
        player = GameObject.FindWithTag("Player");
        
    }


    void Start()
    {  
        spawnPos = player.transform.position; //okay
        targetPos = target.transform.position; 
       
    }

    void Update()
    {
        MoveBullet();
    
    }
    // public void InitBulletTarget(Vector3 target)
    // {
    //     targetPos = target;
    // }
    private void MoveBullet()
    {
        // GameObject bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, bulletSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("egg"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("background"))
        {
            Destroy(gameObject);
        }
    }

  
}

