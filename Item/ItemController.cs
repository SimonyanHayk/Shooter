using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using System;

public class ItemController : MonoBehaviour
{
    //#region Inspector
    //enum ItemType { Ammo, Healing, Armor, Item }

    //[Header("ItemTipe")]
    //[SerializeField] ItemType itemType;

    //[CustomEditor(typeof(ItemController))]

    //public class EnemyEditor : Editor
    //{
    //    public override void OnInspectorGUI()
    //    {
    //        base.OnInspectorGUI();

    //        ItemController itemController = (ItemController)target;

    //        if (itemController.itemType == ItemType.Ammo)
    //        {
    //            WeaponManager weaponManager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();

    //            itemController.ammo = true;
    //            //itemController.addAmmoCount = EditorGUILayout.FloatField("AddAmmoCount", itemController.addAmmoCount);

    //            itemController.bulletTypes = EditorGUILayout.Foldout(itemController.bulletTypes, "BulletTypes", false);

    //            if (itemController.bulletTypes && !itemController.bullet_1 && !itemController.bullet_2 && !itemController.bullet_3
    //                 && !itemController.bullet_4 && !itemController.bullet_5 && !itemController.bullet_6)
    //            {
    //                itemController.bullet_1 = EditorGUILayout.Toggle("bullet_1", itemController.bullet_1);

    //                itemController.bullet_2 = EditorGUILayout.Toggle("bullet_2", itemController.bullet_2);

    //                itemController.bullet_3 = EditorGUILayout.Toggle("bullet_3", itemController.bullet_3);

    //                itemController.bullet_4 = EditorGUILayout.Toggle("bullet_4", itemController.bullet_4);

    //                itemController.bullet_5 = EditorGUILayout.Toggle("bullet_5", itemController.bullet_5);

    //                itemController.bullet_6 = EditorGUILayout.Toggle("bullet_6", itemController.bullet_6);
    //            }
    //            else if (itemController.bulletTypes && itemController.bullet_1)
    //            {
    //                itemController.bullet_1 = EditorGUILayout.Toggle("bullet_1", itemController.bullet_1);
    //                itemController.addAmmoCount = EditorGUILayout.FloatField("AddBullet_1count", itemController.addAmmoCount);
    //            }
    //            else if (itemController.bulletTypes && itemController.bullet_2)
    //            {
    //                itemController.bullet_2 = EditorGUILayout.Toggle("bullet_2", itemController.bullet_2);
    //                itemController.addAmmoCount = EditorGUILayout.FloatField("AddBullet_1count", itemController.addAmmoCount);
    //            }
    //            else if (itemController.bulletTypes && itemController.bullet_3)
    //            {
    //                itemController.bullet_3 = EditorGUILayout.Toggle("bullet_3", itemController.bullet_3);
    //                itemController.addAmmoCount = EditorGUILayout.FloatField("AddBullet_1count", itemController.addAmmoCount);
    //            }
    //            else if (itemController.bulletTypes && itemController.bullet_4)
    //            {
    //                itemController.bullet_4 = EditorGUILayout.Toggle("bullet_4", itemController.bullet_4);
    //                itemController.addAmmoCount = EditorGUILayout.FloatField("AddBullet_1count", itemController.addAmmoCount);
    //            }
    //            else if (itemController.bulletTypes && itemController.bullet_5)
    //            {
    //                itemController.bullet_5 = EditorGUILayout.Toggle("bullet_5", itemController.bullet_5);
    //                itemController.addAmmoCount = EditorGUILayout.FloatField("AddBullet_1count", itemController.addAmmoCount);
    //            }
    //            else if (itemController.bulletTypes && itemController.bullet_6)
    //            {
    //                itemController.bullet_6 = EditorGUILayout.Toggle("bullet_6", itemController.bullet_6);
    //                itemController.addAmmoCount = EditorGUILayout.FloatField("AddBullet_1count", itemController.addAmmoCount);
    //            }
    //        }

    //        if (itemController.itemType == ItemType.Healing)
    //        {
    //            itemController.health = true;
    //            itemController.healingAmount = EditorGUILayout.FloatField("HealingAmount", itemController.healingAmount);
    //            itemController.extraHealingAmount = EditorGUILayout.FloatField("ExtraHealingAmount", itemController.extraHealingAmount);

    //        }

    //        if (itemController.itemType == ItemType.Armor)
    //        {
    //            itemController.armor = true;
    //            itemController.addArmorAmount = EditorGUILayout.FloatField("AddArmorAmount", itemController.addArmorAmount);
    //            itemController.extraArmorAmount = EditorGUILayout.FloatField("ExtraArmorAmount", itemController.extraArmorAmount);

    //        }

    //        if (itemController.itemType == ItemType.Item)
    //        {
    //            itemController.item = true;
    //            itemController.targetHealth = EditorGUILayout.FloatField("Targetealth", itemController.targetHealth);
    //            itemController.canPickUpRange = EditorGUILayout.FloatField("CanPickUpRange", itemController.canPickUpRange);
    //        }
    //    }
    //}

    //#endregion

    //[HideInInspector]
    //public float addAmmoCount;

    //[HideInInspector]
    //public bool bulletTypes;

    //[HideInInspector]
    //public bool bullet_1;
    //[HideInInspector]
    //public bool bullet_2;
    //[HideInInspector]
    //public bool bullet_3;
    //[HideInInspector]
    //public bool bullet_4;
    //[HideInInspector]
    //public bool bullet_5;
    //[HideInInspector]
    //public bool bullet_6;

    ////_________________________________________

    //[HideInInspector]
    //public float healingAmount;
    //[HideInInspector]
    //public float extraHealingAmount;

    ////_____________________________________________

    //[HideInInspector]
    //public float addArmorAmount;
    //[HideInInspector]
    //public float extraArmorAmount;

    ////__________________________________________________

    //[HideInInspector]
    //public float targetHealth;
    //[HideInInspector]
    //public bool canSee;

    //[HideInInspector]
    //public float canPickUpRange = 3f;
     
    ////___________________________________________________

    //[HideInInspector]
    //public bool ammo = false;
    //[HideInInspector]
    //public bool health = false;
    //[HideInInspector]
    //public bool armor = false;
    //[HideInInspector]
    //public bool item = false;

    //public ItemManager itemManager;
    //public WeaponManager weaponManager;
    //public PL_Health playerHealth;
    //public Camera mainCam;

    //[HideInInspector]
    //public bool pickedUp;

    public ItemManager itemManager;
    public PL_Health playerHealth;
    public Camera mainCam;
    public WeaponManager weaponManager;

    public ItemData itemData;
    
    public void TakeDamage(float amount)
    {
        if (itemData.item)
        {
            itemData.targetHealth -= amount;

            if (itemData.targetHealth <= 0f)
            {
                Die();
            }
        }        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
        
    public void Update()
    {
        if (itemData.item)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //PickUp the item
                ItemItem();
            }

            // script for drop the item
            if (Input.GetKeyUp(KeyCode.E))
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                itemData.pickedUp = false;
            }

            if (itemData.pickedUp)
            {
                // Script for move the Item
                if (Vector3.Distance(itemManager.holdPoint.transform.position, gameObject.transform.position) > 0.1f)
                {
                    Vector3 moveDirection = (itemManager.holdPoint.transform.position - gameObject.transform.position);
                    gameObject.GetComponent<Rigidbody>().AddForce(moveDirection * 150f);
                }
            }
        }        
    }

    public void ItemItem()
    {
        RaycastHit See;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out See, itemData.canPickUpRange))
        {
            if (itemData.item)
            {
                gameObject.transform.position = itemManager.holdPoint.transform.position;
                gameObject.GetComponent<Rigidbody>().drag = 10;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                itemData.pickedUp = true;
            }
        }        
    }


    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            if (itemData.ammo)
            {
                itemManager.AddAmmo(weaponManager, this);                
            }

            if (itemData.health)
            {
                itemManager.HealthUp(playerHealth, this);
            }

            if (itemData.armor)
            {
                itemManager.AddArmor(playerHealth, this); 
            }
        }
    }
}
