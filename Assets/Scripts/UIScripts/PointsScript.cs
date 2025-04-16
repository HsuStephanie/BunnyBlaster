
using TMPro;
using UnityEngine;


public class PointsScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
      
    }

    void Update()
    {
        
    }


    public void AddPoint(int points)
    {
        score +=points;
        scoreText.text = score.ToString();

    }

}
