using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Aim : MonoBehaviour
{
    WeaponManager weponManager;
    Weapon wepon;

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

        weponManager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();
        wepon = GameObject.FindWithTag("Wepon").GetComponent<Weapon>();
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

        if(!wepon.bullet_1 && !wepon.bullet_2 && !wepon.bullet_3
                 && !wepon.bullet_4 && !wepon.bullet_5 && !wepon.bullet_6)
        {
            bullet1Count.enabled = false;
            bullet2Count.enabled = false;
            bullet3Count.enabled = false;
            bullet4Count.enabled = false;
            bullet5Count.enabled = false;
            bullet6Count.enabled = false;
        }
        else if (wepon.bullet_1)
        {
            bullet1Count.enabled = true;
        }
        else if (wepon.bullet_2)
        {
            bullet2Count.enabled = true;
        }
        else if (wepon.bullet_3)
        {
            bullet3Count.enabled = true;
        }
        else if (wepon.bullet_4)
        {
            bullet4Count.enabled = true;
        }
        else if (wepon.bullet_5)
        {
            bullet5Count.enabled = true;
        }
        else if (wepon.bullet_6)
        {
            bullet6Count.enabled = true;
        }

    }
}
