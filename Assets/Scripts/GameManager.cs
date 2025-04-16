using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] public bool gameOver = false;
    [SerializeField] TimerScript timerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        timerScript = GameObject.FindGameObjectWithTag("manager").GetComponent<TimerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
 
    }
}
