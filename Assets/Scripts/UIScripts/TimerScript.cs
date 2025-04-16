
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] public bool timerOn;
    [SerializeField] public float timeLeft = 30f;

    [SerializeField] public GameManager gameManagerScript;

    
    // Start is called before the first frame update
    void Start()
    {
        // timerText.text = timeLeft.ToString() + "s";
        gameManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        timerOn= true;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            
            if (timeLeft >0f)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);       
            }

            else
            {
                timerOn= false;
                timeLeft = 0;
                Debug.Log("Time's up");
            }
          
        }
        
    }

    void UpdateTimer(float currentTime)
    {
       currentTime = Mathf.Max(0, currentTime); // Clamp to 0
        float seconds = Mathf.FloorToInt(currentTime % 60);
        float minutes = Mathf.FloorToInt(currentTime / 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

}
