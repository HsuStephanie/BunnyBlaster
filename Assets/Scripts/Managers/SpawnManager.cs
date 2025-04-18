
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn positions")]

    [SerializeField] private float minXRange = -1.9f;
    [SerializeField] private float maxXRange = 2.3f;

    [SerializeField] private float minYRange = 0.5f;
    [SerializeField] private float maxYRange = 1.84f;


    [SerializeField] private float ZRange = -1.72f;

    [SerializeField] private Vector3 spawnPos;

    [Header("Spawn limit")]
    [SerializeField] private int amountToSpawn = 5;

    [SerializeField] private float speed;

    [SerializeField] public int numberOfEggs;

    private bool isSpawning = false;
    

    [Header("Target script")]
    [SerializeField] public TargetMovementScript targetMovementScript;

    [Header("GameManager Script")]
    [SerializeField] GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        targetMovementScript = GameObject.FindGameObjectWithTag("target").GetComponent<TargetMovementScript>();
        gameManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
    }

    void Update()
    {
         int numberOfEggs = GameObject.FindGameObjectsWithTag("egg").Length;
        
        if (!gameManagerScript.countdownActive)
        {
            if (!isSpawning && numberOfEggs ==0)
            {
                SpawnEgg();
            }
            
            if (numberOfEggs ==0)
            {
                isSpawning = false;
                targetMovementScript.hasAddedBullets=false;    
            }
        }
       
       
    }

    //want to spawn random eggs from the pooler
    private void SpawnEgg()
    {
        isSpawning = true;
        for (int i= 0; i<amountToSpawn; i++)
        {
            GameObject pooledTarget = ObjectPooler.SharedInstance.GetPooledObject("egg");
            if (pooledTarget !=null)
            {
                pooledTarget.SetActive(true);

                spawnPos = new Vector3 (Random.Range(minXRange, maxXRange),Random.Range(minYRange, maxYRange),ZRange);
                pooledTarget.transform.position = spawnPos;
                
            }
        }

    }

}
