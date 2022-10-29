using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool pickedUp;
    
    public GameObject holdPoint;
    public Camera mainCam;

    #region Item

    public void Update()
    {
        //ItemMain();
    }

    public void ItemMain(ItemController itemController)
    {        
        //itemController = FindObjectOfType<GameObject>().GetComponent<ItemController>();

        if (itemController.item)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit See;
                if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out See, itemController.canPickUpRange))
                {
                    if (itemController != null)
                    {
                        if (itemController.item)
                        {
                            Pickup();
                            pickedUp = true;
                        }
                    }
                }

                if (pickedUp)
                    MoveItem(itemController);

                if (Input.GetKeyUp(KeyCode.F))
                    DropItem();

            }
        }
        
    }

    public void Pickup()
    {
        gameObject.transform.position = holdPoint.transform.position;
        gameObject.GetComponent<Rigidbody>().drag = 10;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void MoveItem(ItemController itemController)
    {
        if (pickedUp)
        {
            if (Vector3.Distance(holdPoint.transform.position, gameObject.transform.position) > 0.1f)
            {
                Vector3 moveDirection = (holdPoint.transform.position - gameObject.transform.position);
                gameObject.GetComponent<Rigidbody>().AddForce(moveDirection * 150f);
            }
        }
    }

    private void DropItem()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        pickedUp = false;
    }

    #endregion

    #region AddAmmo

    public void AddAmmo(WeaponManager weaponManager, ItemController itemController)
    {
        if (itemController.bullet_1)
        {
            if (weaponManager.bullet_1count < weaponManager.bullet_1MaxCount)
            {
                weaponManager.bullet_1count += itemController.addAmmoCount;

                if (weaponManager.bullet_1count >= weaponManager.bullet_1MaxCount)
                {
                    weaponManager.bullet_1count = weaponManager.bullet_1MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemController.bullet_2)
        {
            if (weaponManager.bullet_2count < weaponManager.bullet_2MaxCount)
            {
                weaponManager.bullet_2count += itemController.addAmmoCount;

                if (weaponManager.bullet_2count >= weaponManager.bullet_2MaxCount)
                {
                    weaponManager.bullet_2count = weaponManager.bullet_2MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemController.bullet_3)
        {
            if (weaponManager.bullet_3count < weaponManager.bullet_3MaxCount)
            {
                weaponManager.bullet_3count += itemController.addAmmoCount;

                if (weaponManager.bullet_3count >= weaponManager.bullet_3MaxCount)
                {
                    weaponManager.bullet_3count = weaponManager.bullet_3MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemController.bullet_4)
        {
            if (weaponManager.bullet_4count < weaponManager.bullet_4MaxCount)
            {
                weaponManager.bullet_4count += itemController.addAmmoCount;

                if (weaponManager.bullet_4count >= weaponManager.bullet_4MaxCount)
                {
                    weaponManager.bullet_4count = weaponManager.bullet_4MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemController.bullet_5)
        {
            if (weaponManager.bullet_5count < weaponManager.bullet_5MaxCount)
            {
                weaponManager.bullet_5count += itemController.addAmmoCount;

                if (weaponManager.bullet_5count >= weaponManager.bullet_5MaxCount)
                {
                    weaponManager.bullet_5count = weaponManager.bullet_5MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemController.bullet_6)
        {
            if (weaponManager.bullet_6count < weaponManager.bullet_6MaxCount)
            {
                weaponManager.bullet_6count += itemController.addAmmoCount;

                if (weaponManager.bullet_6count >= weaponManager.bullet_6MaxCount)
                {
                    weaponManager.bullet_6count = weaponManager.bullet_6MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }
    }
    #endregion

    #region Healing

    public void HealthUp(PL_Health PlayerHealth, ItemController itemController)
    {
        if (PlayerHealth.health >= PlayerHealth.healthMax && PlayerHealth.extraHealth < PlayerHealth.extraHealthMax)
        {
            PlayerHealth.extraHealth += itemController.extraHealingAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.health <= itemController.healingAmount + itemController.extraHealingAmount)
        {
            PlayerHealth.health += itemController.healingAmount + itemController.extraHealingAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.extraHealth < PlayerHealth.extraHealthMax && PlayerHealth.health >= PlayerHealth.healthMax - itemController.extraHealingAmount ||
            PlayerHealth.extraHealth < PlayerHealth.extraHealthMax && PlayerHealth.health >= PlayerHealth.healthMax - itemController.healingAmount)
        {
            PlayerHealth.health += itemController.healingAmount;

            if (PlayerHealth.health <= PlayerHealth.healthMax)
            {
                PlayerHealth.extraHealth += itemController.extraHealingAmount - PlayerHealth.healthMax + PlayerHealth.health;
                PlayerHealth.health += PlayerHealth.healthMax - PlayerHealth.health;
            }
            else if (PlayerHealth.health >= PlayerHealth.healthMax)
            {
                PlayerHealth.extraHealth += itemController.extraHealingAmount;
            }

            Destroy(itemController.gameObject);
        }

        if (PlayerHealth.extraHealth > 100)
        {
            PlayerHealth.extraHealth = 100;
        }

        if (PlayerHealth.health > 100)
        {
            PlayerHealth.health = 100;
        }
    }

    #endregion

    #region Armor

    public void AddArmor(PL_Health PlayerHealth, ItemController itemController)
    {
        if (PlayerHealth.armor >= PlayerHealth.armorMax && PlayerHealth.extraArmor < PlayerHealth.extraArmorMax)
        {
            PlayerHealth.extraArmor += itemController.extraArmorAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.armor < itemController.addArmorAmount + itemController.extraArmorAmount)
        {
            PlayerHealth.armor += itemController.addArmorAmount + itemController.extraArmorAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.extraArmor < PlayerHealth.extraArmorMax && PlayerHealth.armor >= PlayerHealth.armorMax - itemController.extraArmorAmount ||
            PlayerHealth.extraArmor < PlayerHealth.extraArmorMax && PlayerHealth.armor >= PlayerHealth.armorMax - itemController.addArmorAmount)
        {
            PlayerHealth.armor += itemController.addArmorAmount;

            if (PlayerHealth.armor <= PlayerHealth.armorMax)
            {
                PlayerHealth.extraArmor += itemController.extraArmorAmount - PlayerHealth.armorMax + PlayerHealth.armor;
                PlayerHealth.armor += PlayerHealth.armorMax - PlayerHealth.armor;
            }
            else if (PlayerHealth.armor >= PlayerHealth.armorMax)
            {
                PlayerHealth.extraArmor += itemController.extraArmorAmount;
            }
            Destroy(itemController.gameObject);
        }

        if (PlayerHealth.armor > 100)
        {
            PlayerHealth.armor = 100;
        }

        if (PlayerHealth.extraArmor > 100)
        {
            PlayerHealth.extraArmor = 100;
        }
    }

    #endregion


}
