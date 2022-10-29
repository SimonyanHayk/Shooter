using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUnlock : MonoBehaviour
{
    public WeaponSwitch weaponSwitch;
    public List<GameObject> weaponUnlock = new List<GameObject>();

    #region unlock

    public void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject obj in weaponUnlock)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (weaponUnlock.IndexOf(obj) == 0)
                {
                    if (gameObject == weaponUnlock[0])
                    {
                        weaponSwitch.unlock1 = true;
                        Destroy(weaponUnlock[0]);
                    }                    
                }

                if (weaponUnlock.IndexOf(obj) == 1)
                {
                    if (gameObject == weaponUnlock[1])
                    {
                        weaponSwitch.unlock2 = true;
                        Destroy(weaponUnlock[1]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj) == 2)
                {
                    if (gameObject == weaponUnlock[2])
                    {
                        weaponSwitch.unlock3 = true;
                        Destroy(weaponUnlock[2]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj) == 3)
                {
                    if (gameObject == weaponUnlock[3])
                    {
                        weaponSwitch.unlock4 = true;
                        Destroy(weaponUnlock[3]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj) == 4)
                {
                    if (gameObject == weaponUnlock[4])
                    {
                        weaponSwitch.unlock5 = true;
                        Destroy(weaponUnlock[4]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj) == 5)
                {
                    if (gameObject == weaponUnlock[5])
                    {
                        weaponSwitch.unlock6 = true;
                        Destroy(weaponUnlock[5]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj) == 6)
                {
                    if (gameObject == weaponUnlock[6])
                    {
                        weaponSwitch.unlock7 = true;
                        Destroy(weaponUnlock[6]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj) == 7)
                {
                    if (gameObject == weaponUnlock[7])
                    {
                        weaponSwitch.unlock8 = true;
                        Destroy(weaponUnlock[7]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj) == 8)
                {
                    if (gameObject == weaponUnlock[8])
                    {
                        weaponSwitch.unlock9 = true;
                        Destroy(weaponUnlock[8]);
                    }                        
                }

                if (weaponUnlock.IndexOf(obj, 9) == 9)
                {
                    if (gameObject == weaponUnlock[9])
                    {
                        weaponSwitch.unlock0 = true;
                        Destroy(weaponUnlock[9]);
                    }                        
                }
            }
        }
    }

    #endregion

}
