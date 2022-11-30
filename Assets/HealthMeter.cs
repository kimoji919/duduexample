using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    public float healthMeter = 80.0f;
    public float HealthPoints = 100.0f;  
    public Image healthPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Harm()
    {
        healthMeter += -5;
        Amount();
 
        Debug.Log("扣血-5");
    }
    public void Amount()
    {
        healthPoint.fillAmount = healthMeter /HealthPoints;
    }
}

