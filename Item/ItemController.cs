using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using System;

public class ItemController : MonoBehaviour
{
    #region Inspector
    enum ItemType { Ammo, Healing, Armor, Item }

    [Header("ItemTipe")]
    [SerializeField] ItemType itemType;

    [CustomEditor(typeof(ItemController))]

    public class EnemyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ItemController itemController = (ItemController)target;

            if(itemController.itemType == ItemType.Ammo)
            {                
                WeaponManager WeaponManager;
                WeaponManager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();

                //ItemManager itemType = (ItemManager)target;

                itemController.ammo = true;
                itemController.addAmmoCount = EditorGUILayout.FloatField("AddAmmoCount", itemController.addAmmoCount);

                itemController.bulletTypes = EditorGUILayout.Foldout(itemController.bulletTypes, "bulletTypes", false);

                if (itemController.bulletTypes && !itemController.bullet_1 && !itemController.bullet_2 && !itemController.bullet_3
                     && !itemController.bullet_4 && !itemController.bullet_5 && !itemController.bullet_6)
                {
                    itemController.bullet_1 = EditorGUILayout.Toggle("bullet_1", itemController.bullet_1);
                    WeaponManager.bullet_1count = EditorGUILayout.FloatField("bullet_1count", WeaponManager.bullet_1count);

                    itemController.bullet_2 = EditorGUILayout.Toggle("bullet_2", itemController.bullet_2);
                    WeaponManager.bullet_2count = EditorGUILayout.FloatField("bullet_2count", WeaponManager.bullet_2count);

                    itemController.bullet_3 = EditorGUILayout.Toggle("bullet_3", itemController.bullet_3);
                    WeaponManager.bullet_3count = EditorGUILayout.FloatField("bullet_3count", WeaponManager.bullet_3count);

                    itemController.bullet_4 = EditorGUILayout.Toggle("bullet_4", itemController.bullet_4);
                    WeaponManager.bullet_4count = EditorGUILayout.FloatField("bullet_4count", WeaponManager.bullet_4count);

                    itemController.bullet_5 = EditorGUILayout.Toggle("bullet_5", itemController.bullet_5);
                    WeaponManager.bullet_5count = EditorGUILayout.FloatField("bullet_5count", WeaponManager.bullet_5count);

                    itemController.bullet_6 = EditorGUILayout.Toggle("bullet_6", itemController.bullet_6);
                    WeaponManager.bullet_6count = EditorGUILayout.FloatField("bullet_6count", WeaponManager.bullet_6count);
                }
                else if (itemController.bulletTypes && itemController.bullet_1)
                {
                    itemController.bullet_1 = EditorGUILayout.Toggle("bullet_1", itemController.bullet_1);
                    WeaponManager.bullet_1count = EditorGUILayout.FloatField("bullet_1count", WeaponManager.bullet_1count);
                }
                else if (itemController.bulletTypes && itemController.bullet_2)
                {
                    itemController.bullet_2 = EditorGUILayout.Toggle("bullet_2", itemController.bullet_2);
                    WeaponManager.bullet_2count = EditorGUILayout.FloatField("bullet_2count", WeaponManager.bullet_2count);
                }
                else if (itemController.bulletTypes && itemController.bullet_3)
                {
                    itemController.bullet_3 = EditorGUILayout.Toggle("bullet_3", itemController.bullet_3);
                    WeaponManager.bullet_3count = EditorGUILayout.FloatField("bullet_3count", WeaponManager.bullet_3count);
                }
                else if (itemController.bulletTypes && itemController.bullet_4)
                {
                    itemController.bullet_4 = EditorGUILayout.Toggle("bullet_4", itemController.bullet_4);
                    WeaponManager.bullet_4count = EditorGUILayout.FloatField("bullet_4count", WeaponManager.bullet_4count);
                }
                else if (itemController.bulletTypes && itemController.bullet_5)
                {
                    itemController.bullet_5 = EditorGUILayout.Toggle("bullet_5", itemController.bullet_5);
                    WeaponManager.bullet_5count = EditorGUILayout.FloatField("bullet_5count", WeaponManager.bullet_5count);
                }
                else if (itemController.bulletTypes && itemController.bullet_6)
                {
                    itemController.bullet_6 = EditorGUILayout.Toggle("bullet_6", itemController.bullet_6);
                    WeaponManager.bullet_6count = EditorGUILayout.FloatField("bullet_6count", WeaponManager.bullet_6count);
                }

            }

            if (itemController.itemType == ItemType.Healing)
            {
                itemController.health = true;
                itemController.healingAmount = EditorGUILayout.FloatField("HealingAmount", itemController.healingAmount);
                itemController.extraHealingAmount = EditorGUILayout.FloatField("ExtraHealingAmount", itemController.extraHealingAmount);

            }

            if (itemController.itemType == ItemType.Armor)
            {
                itemController.armor = true;
                itemController.addArmorAmount = EditorGUILayout.FloatField("AddArmorAmount", itemController.addArmorAmount);
                itemController.extraArmorAmount = EditorGUILayout.FloatField("ExtraArmorAmount", itemController.extraArmorAmount);

            }

            if (itemController.itemType == ItemType.Item)
            {
                itemController.item = true;
                itemController.targetHealth = EditorGUILayout.FloatField("Targetealth", itemController.targetHealth);
                itemController.canPickUpRange = EditorGUILayout.FloatField("CanPickUpRange", itemController.canPickUpRange);
            }
        }
    }

    #endregion

    [HideInInspector]
    public float addAmmoCount;

    [HideInInspector]
    public bool bulletTypes;

    [HideInInspector]
    public bool bullet_1;
    [HideInInspector]
    public bool bullet_2;
    [HideInInspector]
    public bool bullet_3;
    [HideInInspector]
    public bool bullet_4;
    [HideInInspector]
    public bool bullet_5;
    [HideInInspector]
    public bool bullet_6;

    //_________________________________________

    [HideInInspector]
    public float healingAmount;
    [HideInInspector]
    public float extraHealingAmount;

   //_____________________________________________

    [HideInInspector]
    public float addArmorAmount;
    [HideInInspector]
    public float extraArmorAmount;

    //__________________________________________________

    [HideInInspector]
    public float targetHealth;
    [HideInInspector]
    public bool canSee;

    [HideInInspector]
    public float canPickUpRange = 3f;

    public void TakeDamage(float amount)
    {
        if (item)
        {
            targetHealth -= amount;

            if (targetHealth <= 0f)
            {
                Die();
            }
        }        
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    //___________________________________________________

    [HideInInspector]
    public bool ammo = false;
    [HideInInspector]
    public bool health = false;
    [HideInInspector]
    public bool armor = false;
    [HideInInspector]
    public bool item = false;

    public ItemManager itemManager;
    public WeaponManager weaponManager;
    public PL_Health playerHealth;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            if (ammo)
            {
                itemManager.AddAmmo(weaponManager, this);                
            }

            if (health)
            {
                itemManager.HealthUp(playerHealth, this);
            }

            if (armor)
            {
                itemManager.AddArmor(playerHealth, this); 
            }
        }
    }
}
