using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

public class TargetMovementScript : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speed = 10f;


    [Header ("Boundaries")]
    [SerializeField] private float minXRange = -2.4f;
    [SerializeField] private float maxXRange = 2.0f;
    [SerializeField] private float minYRange = 0f;
    [SerializeField] private float maxYRange = 2.3f;

    [SerializeField] private float zPos= -1.85f;


    [Header ("Player")]
    [SerializeField] private GameObject player;

    [Header ("Projectile")]
    [SerializeField] private GameObject projectile;
    [SerializeField] public int countProjectiles=0;
    [SerializeField] public bool shooting = true;

    public bool hasAddedBullets = false;

    [Header("Scripts")]
    [SerializeField] GameManager gameManagerScript;
    [SerializeField] SpawnManager spawnManagerScript;
    [SerializeField] BulletsLeftScript bulletsLeftScript;

    [Header("Audio")]
    [SerializeField] SoundManager soundManagerScript;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        spawnManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnManager>();
        bulletsLeftScript = GameObject.FindGameObjectWithTag("manager").GetComponent<BulletsLeftScript>();
        soundManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundManager>();
        shooting = true;
        audioSource = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        TargetMovement();
        InstantiateProjectile();

       if (!gameManagerScript.countdownActive && spawnManagerScript.numberOfEggs==0)
        {
            if (!hasAddedBullets)
            {
                hasAddedBullets = true;
                bulletsLeftScript.bulletsLeft+=10;
                audioSource.PlayOneShot(soundManagerScript.addBulletsSound);
            }
        }
        if (bulletsLeftScript.bulletsLeft==0)
        {
            shooting= false;
        }
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

        // Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // transform.position += moveDirection * speed * Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z + -1.845f;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = Vector3.MoveTowards(transform.position, worldMousePos, speed * Time.deltaTime);
       
    }

    private void InstantiateProjectile ()
    {
       
        if (!gameManagerScript.gameOver && shooting)
        {
            if (bulletsLeftScript.bulletsLeft >0)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    audioSource.PlayOneShot(soundManagerScript.shootSound);
                    bulletsLeftScript.bulletsLeft-=1;
                    Instantiate(projectile,player.transform.position,Quaternion.identity);
                }
            }
        }
       
    }

}

   


