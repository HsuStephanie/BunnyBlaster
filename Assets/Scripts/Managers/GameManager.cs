using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public bool gameOver;

    [Header("Scripts")]
    [SerializeField] TimerScript timerScript;
    [SerializeField] SoundManager soundManagerScript;

    [Header("UI")]
    [SerializeField] private Button resetButton;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TextMeshProUGUI countDownText;

    [Header("Game objects")]
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject gamePanel;

    [Header("AudioSource")]
    [SerializeField] AudioSource audioSource;
    

    [SerializeField] private float timeRemaining = 3;
    public bool countdownActive = true;

    void Start()
    {
        timerScript = GameObject.FindGameObjectWithTag("manager").GetComponent<TimerScript>();
        audioSource = gameObject.GetComponent<AudioSource>();
        soundManagerScript = gameObject.GetComponent<SoundManager>();
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        if (countdownActive)
        {
            CountDown();
        }

        if (timerScript.timeLeft == 0 && !gameOver)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            audioSource.PlayOneShot(soundManagerScript.gameOverSound);
            
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void CountDown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            countDownText.text = Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            countdownActive = false;
            countDownText.text = "";
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
            target.SetActive(true);
            gameOver = false;
        }
    }

    IEnumerator StartCountdown()
    {
        // Optional: small delay before countdown begins
        yield return new WaitForSeconds(0.5f);
        countdownActive = true;
    }

}
