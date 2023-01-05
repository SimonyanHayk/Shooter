using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject holdPoint;
    public ItemData itemData;

    #region Item

    public void Update()
    {
        
    }

    #endregion

    #region AddAmmo

    public void AddAmmo(WeaponManager weaponManager, ItemController itemController)
    {
        if (itemData.bullet_1)
        {
            if (weaponManager.bullet_1count < weaponManager.bullet_1MaxCount)
            {
                weaponManager.bullet_1count += itemData.addAmmoCount;

                if (weaponManager.bullet_1count >= weaponManager.bullet_1MaxCount)
                {
                    weaponManager.bullet_1count = weaponManager.bullet_1MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemData.bullet_2)
        {
            if (weaponManager.bullet_2count < weaponManager.bullet_2MaxCount)
            {
                weaponManager.bullet_2count += itemData.addAmmoCount;

                if (weaponManager.bullet_2count >= weaponManager.bullet_2MaxCount)
                {
                    weaponManager.bullet_2count = weaponManager.bullet_2MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemData.bullet_3)
        {
            if (weaponManager.bullet_3count < weaponManager.bullet_3MaxCount)
            {
                weaponManager.bullet_3count += itemData.addAmmoCount;

                if (weaponManager.bullet_3count >= weaponManager.bullet_3MaxCount)
                {
                    weaponManager.bullet_3count = weaponManager.bullet_3MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemData.bullet_4)
        {
            if (weaponManager.bullet_4count < weaponManager.bullet_4MaxCount)
            {
                weaponManager.bullet_4count += itemData.addAmmoCount;

                if (weaponManager.bullet_4count >= weaponManager.bullet_4MaxCount)
                {
                    weaponManager.bullet_4count = weaponManager.bullet_4MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemData.bullet_5)
        {
            if (weaponManager.bullet_5count < weaponManager.bullet_5MaxCount)
            {
                weaponManager.bullet_5count += itemData.addAmmoCount;

                if (weaponManager.bullet_5count >= weaponManager.bullet_5MaxCount)
                {
                    weaponManager.bullet_5count = weaponManager.bullet_5MaxCount;
                }

                Destroy(itemController.gameObject);
            }
        }

        if (itemData.bullet_6)
        {
            if (weaponManager.bullet_6count < weaponManager.bullet_6MaxCount)
            {
                weaponManager.bullet_6count += itemData.addAmmoCount;

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
            PlayerHealth.extraHealth += itemData.extraHealingAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.health <= itemData.healingAmount + itemData.extraHealingAmount)
        {
            PlayerHealth.health += itemData.healingAmount + itemData.extraHealingAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.extraHealth < PlayerHealth.extraHealthMax && PlayerHealth.health >= PlayerHealth.healthMax - itemData.extraHealingAmount ||
            PlayerHealth.extraHealth < PlayerHealth.extraHealthMax && PlayerHealth.health >= PlayerHealth.healthMax - itemData.healingAmount)
        {
            PlayerHealth.health += itemData.healingAmount;

            if (PlayerHealth.health <= PlayerHealth.healthMax)
            {
                PlayerHealth.extraHealth += itemData.extraHealingAmount - PlayerHealth.healthMax + PlayerHealth.health;
                PlayerHealth.health += PlayerHealth.healthMax - PlayerHealth.health;
            }
            else if (PlayerHealth.health >= PlayerHealth.healthMax)
            {
                PlayerHealth.extraHealth += itemData.extraHealingAmount;
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
            PlayerHealth.extraArmor += itemData.extraArmorAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.armor < itemData.addArmorAmount + itemData.extraArmorAmount)
        {
            PlayerHealth.armor += itemData.addArmorAmount + itemData.extraArmorAmount;
            Destroy(itemController.gameObject);
        }
        else if (PlayerHealth.extraArmor < PlayerHealth.extraArmorMax && PlayerHealth.armor >= PlayerHealth.armorMax - itemData.extraArmorAmount ||
            PlayerHealth.extraArmor < PlayerHealth.extraArmorMax && PlayerHealth.armor >= PlayerHealth.armorMax - itemData.addArmorAmount)
        {
            PlayerHealth.armor += itemData.addArmorAmount;

            if (PlayerHealth.armor <= PlayerHealth.armorMax)
            {
                PlayerHealth.extraArmor += itemData.extraArmorAmount - PlayerHealth.armorMax + PlayerHealth.armor;
                PlayerHealth.armor += PlayerHealth.armorMax - PlayerHealth.armor;
            }
            else if (PlayerHealth.armor >= PlayerHealth.armorMax)
            {
                PlayerHealth.extraArmor += itemData.extraArmorAmount;
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
