using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerController plyer;
    public Image image;
    public TextMeshProUGUI healthtext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       image.fillAmount = 0.5f+( plyer.health / plyer.maxHealth)/2f;
        healthtext.text = plyer.health.ToString();
    }
}
