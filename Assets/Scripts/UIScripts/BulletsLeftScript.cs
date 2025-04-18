
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BulletsLeftScript : MonoBehaviour
{
     [SerializeField] public TextMeshProUGUI bulletsLeftText;
    [SerializeField] public int bulletsLeft;

    [SerializeField] public TargetMovementScript targetMovementScript;
    
    // Start is called before the first frame update
    void Start()
    {
        targetMovementScript = GameObject.FindGameObjectWithTag("target").GetComponent<TargetMovementScript>();

        bulletsLeft = 10;
       
        bulletsLeftText.text = bulletsLeft.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (bulletsLeft >=0)
        {

            bulletsLeftText.text = bulletsLeft.ToString();
        }
        
    }
    
}
