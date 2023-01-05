using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Aim : MonoBehaviour
{
    public WeaponManager weponManager;
    public Weapon weapon;

    public TMP_Text bullet1Count;
    public TMP_Text bullet2Count;
    public TMP_Text bullet3Count;
    public TMP_Text bullet4Count;
    public TMP_Text bullet5Count;
    public TMP_Text bullet6Count;

    // Start is called before the first frame update
    void Start()
    {
        bullet1Count.enabled = false;
        bullet2Count.enabled = false;
        bullet3Count.enabled = false;
        bullet4Count.enabled = false;
        bullet5Count.enabled = false;
        bullet6Count.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        bullet1Count.text = weponManager.bullet_1count.ToString("F0");
        bullet2Count.text = weponManager.bullet_2count.ToString("F0");
        bullet3Count.text = weponManager.bullet_3count.ToString("F0");
        bullet4Count.text = weponManager.bullet_4count.ToString("F0");
        bullet5Count.text = weponManager.bullet_5count.ToString("F0");
        bullet6Count.text = weponManager.bullet_6count.ToString("F0");

        if(!weapon.bullet_1 && !weapon.bullet_2 && !weapon.bullet_3
                 && !weapon.bullet_4 && !weapon.bullet_5 && !weapon.bullet_6)
        {
            bullet1Count.enabled = false;
            bullet2Count.enabled = false;
            bullet3Count.enabled = false;
            bullet4Count.enabled = false;
            bullet5Count.enabled = false;
            bullet6Count.enabled = false;
        }
        else if (weapon.bullet_1)
        {
            bullet1Count.enabled = true;
        }
        else if (weapon.bullet_2)
        {
            bullet2Count.enabled = true;
        }
        else if (weapon.bullet_3)
        {
            bullet3Count.enabled = true;
        }
        else if (weapon.bullet_4)
        {
            bullet4Count.enabled = true;
        }
        else if (weapon.bullet_5)
        {
            bullet5Count.enabled = true;
        }
        else if (weapon.bullet_6)
        {
            bullet6Count.enabled = true;
        }

    }
}
