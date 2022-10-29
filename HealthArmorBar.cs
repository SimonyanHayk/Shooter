using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthArmorBar : MonoBehaviour
{
    public TMP_Text Health;
    public TMP_Text Armor;

    public GameObject Player;
    public PL_Health PlayerHealth;


    // Update is called once per frame
    void Update()
    {
        Health.text = PlayerHealth.mainHealth.ToString("F0");
        Armor.text = PlayerHealth.mainArmor.ToString("F0");
    }



}
