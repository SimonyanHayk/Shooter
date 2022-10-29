using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public WeaponUnlock weaponUnlock;
    public List<GameObject> weapon = new List<GameObject>();

    private bool weapon1Active = false;
    private bool weapon2Active = false;
    private bool weapon3Active = false;
    private bool weapon4Active = false;
    private bool weapon5Active = false;
    private bool weapon6Active = false;
    private bool weapon7Active = false;
    private bool weapon8Active = false;
    private bool weapon9Active = false;
    private bool weapon0Active = false;

    public bool unlock1 = false;
    public bool unlock2 = false;
    public bool unlock3 = false;
    public bool unlock4 = false;
    public bool unlock5 = false;
    public bool unlock6 = false;
    public bool unlock7 = false;
    public bool unlock8 = false;
    public bool unlock9 = false;
    public bool unlock0 = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in weapon)
            obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HotKeys();
    }

    public void GetReady()
    {
        weapon[0].SetActive(false);
        weapon[1].SetActive(false);
        weapon[2].SetActive(false);
        weapon[3].SetActive(false);
        weapon[4].SetActive(false);
        weapon[5].SetActive(false);
        weapon[6].SetActive(false);
        weapon[7].SetActive(false);
        weapon[8].SetActive(false);
        weapon[9].SetActive(false);

        weapon1Active = false;
        weapon2Active = false;
        weapon3Active = false;
        weapon4Active = false;
        weapon5Active = false;
        weapon6Active = false;
        weapon7Active = false;
        weapon8Active = false;
        weapon9Active = false;
        weapon0Active = false;
    }

    #region HotKeys
    public void HotKeys()
    {
       foreach(GameObject obj in weapon)
       {
            if (weapon.IndexOf(obj) == 0)
            {
                if (unlock1)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha1) && !weapon1Active)
                    {
                        GetReady();

                        weapon[0].SetActive(true);
                        weapon1Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha1) && weapon1Active)
                    {
                        weapon[0].SetActive(false);
                        weapon1Active = false;
                    }
                }                
            }

            if (weapon.IndexOf(obj) == 1)
            {
                if (unlock2)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha2) && !weapon2Active)
                    {
                        GetReady();

                        weapon[1].SetActive(true);
                        weapon2Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) && weapon2Active)
                    {
                        weapon[1].SetActive(false);
                        weapon2Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 2)
            {
                if (unlock3)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha3) && !weapon3Active)
                    {
                        GetReady();

                        weapon[2].SetActive(true);
                        weapon3Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha3) && weapon3Active)
                    {
                        weapon[2].SetActive(false);
                        weapon3Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 3)
            {
                if (unlock4)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha4) && !weapon4Active)
                    {
                        GetReady();

                        weapon[3].SetActive(true);
                        weapon4Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha4) && weapon4Active)
                    {
                        weapon[3].SetActive(false);
                        weapon4Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 4)
            {
                if (unlock5)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha5) && !weapon5Active)
                    {
                        GetReady();

                        weapon[4].SetActive(true);
                        weapon5Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha5) && weapon5Active)
                    {
                        weapon[4].SetActive(false);
                        weapon5Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 5)
            {
                if (unlock6)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha6) && !weapon6Active)
                    {
                        GetReady();

                        weapon[5].SetActive(true);
                        weapon6Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha6) && weapon6Active)
                    {
                        weapon[5].SetActive(false);
                        weapon6Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 6)
            {
                if (unlock7)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha7) && !weapon7Active)
                    {
                        GetReady();

                        weapon[6].SetActive(true);
                        weapon7Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha7) && weapon7Active)
                    {
                        weapon[6].SetActive(false);
                        weapon7Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 7)
            {
                if (unlock8)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha8) && !weapon8Active)
                    {
                        GetReady();

                        weapon[7].SetActive(true);
                        weapon8Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha8) && weapon8Active)
                    {
                        weapon[7].SetActive(false);
                        weapon8Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 8)
            {
                if (unlock9)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha9) && !weapon9Active)
                    {
                        GetReady();

                        weapon[8].SetActive(true);
                        weapon9Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha9) && weapon9Active)
                    {
                        weapon[8].SetActive(false);
                        weapon9Active = false;
                    }
                }
            }

            if (weapon.IndexOf(obj) == 9)
            {
                if (unlock0)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha0) && !weapon0Active)
                    {
                        GetReady();

                        weapon[9].SetActive(true);
                        weapon0Active = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha0) && weapon0Active)
                    {
                        weapon[9].SetActive(false);
                        weapon0Active = false;
                    }
                }
            }
       }        
    }

    #endregion

}
