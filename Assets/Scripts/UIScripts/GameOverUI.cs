
using System.Threading;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI finalScoreText;

    [SerializeField] private int finalScore;

    [SerializeField] private float timer;
    [SerializeField] private float countSpeed = 0.5f;

    [SerializeField] PointsScript pointsScript;
    [SerializeField] GameManager gameManagerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        pointsScript = GameObject.FindGameObjectWithTag("manager").GetComponent<PointsScript>();
        gameManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        finalScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.gameOver)
        {
            CountUp();
        finalScoreText.text = "Your Score:" + " " + finalScore.ToString();
        }
        
    }

    void CountUp()
    {
        if (finalScore < pointsScript.score)
        {
            timer += Time.deltaTime;

            if (timer >= countSpeed)
            {
                finalScore++;
                timer = 0f;
            }
        }
    }

}
