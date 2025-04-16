using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShootScript : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private float bulletSpeed = 2.0f;
    [SerializeField] private Vector3 spawnPos;

    [Header("Target")]
    private GameObject target;
    public Vector3 targetPos;

    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Move Direction")]
    private Vector3 moveDirection;

    [Header ("PointsScript")]
    [SerializeField] public PointsScript pointsScript;

    void Awake()
    {
        target = GameObject.FindWithTag("target");
        player = GameObject.FindWithTag("Player");
        GameObject UIManager = GameObject.FindGameObjectWithTag("manager");
        if (UIManager !=null)
        {
            pointsScript = UIManager.GetComponent<PointsScript>();
        }
        
    }


    void Start()
    {  
        spawnPos = player.transform.position;
        targetPos = new Vector3 (target.transform.position.x,target.transform.position.y, target.transform.position.z);
        moveDirection = (targetPos - spawnPos).normalized;
       
    }

    void Update()
    {
        MoveBullet();
    
    }
  
    private void MoveBullet()
    {
        // Move in the direction of the target indefinitely
        transform.position += moveDirection * bulletSpeed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("egg"))
        {
            pointsScript.AddPoint(1);
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
        if (other.gameObject.CompareTag("background"))
        {
            Debug.Log("Hit background");
            Destroy(gameObject);
        }
    }

   




}

