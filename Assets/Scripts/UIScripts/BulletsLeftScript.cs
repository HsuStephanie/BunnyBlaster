
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BulletsLeftScript : MonoBehaviour
{
     [SerializeField] public TextMeshProUGUI bulletsLeftText;
    [SerializeField] private int bulletsLeft = 20;

    [SerializeField] public TargetMovementScript targetMovementScript;
    
    // Start is called before the first frame update
    void Start()
    {
        targetMovementScript = GameObject.FindGameObjectWithTag("target").GetComponent<TargetMovementScript>();
       
        bulletsLeftText.text = bulletsLeft.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (bulletsLeft >=1)
        {
            bulletsLeftText.text = (bulletsLeft - targetMovementScript.countProjectiles).ToString();
        }
        
    }

    
}
