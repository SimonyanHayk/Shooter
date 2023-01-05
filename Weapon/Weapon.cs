using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Weapon : MonoBehaviour
{
    public WeaponManager weaponManager;
    [SerializeField] GameObject movementScript;

    #region WeaponInspector

    enum ItemType { HitScan, Projectile, ProjectileThrowMode }

    [Header("WeaponType")]
    [SerializeField] ItemType itemType;

    [CustomEditor(typeof(Weapon))]
    public class WeaponEditor : Editor
    {        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            WeaponManager weaponManager;
            //weaponManager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();
            
            Weapon weapon = (Weapon)target;
            weaponManager = weapon.weaponManager;

            //___________________________________CD_____________________________

            if (!weapon.primaryCD && !weapon.alternativeCD)
            {
                weapon.primaryCD = EditorGUILayout.Toggle("Primery CD", weapon.primaryCD);
                weapon.alternativeCD = EditorGUILayout.Toggle("Alternative CD", weapon.alternativeCD);
            }

            if (weapon.primaryCD && weapon.alternativeCD)
            {
                weapon.primaryCD = EditorGUILayout.Toggle("Primery CD", weapon.primaryCD);
                weapon.primaryCdStartAfterShots = EditorGUILayout.FloatField("Primery CD starts after shoots", weapon.primaryCdStartAfterShots);
                weapon.primaryCooldownTimer = EditorGUILayout.FloatField("Primery CD timer ", weapon.primaryCooldownTimer);
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                weapon.alternativeCD = EditorGUILayout.Toggle("Alternative CD", weapon.alternativeCD);
                weapon.alternativeCdStartAfterShots = EditorGUILayout.FloatField("Alternative CD starts after shoots", weapon.alternativeCdStartAfterShots);
                weapon.alternativeCooldownTimer = EditorGUILayout.FloatField("Alternative CD timer ", weapon.alternativeCooldownTimer);
                EditorGUILayout.Space();
            }

            if (weapon.primaryCD && !weapon.alternativeCD)
            {
                weapon.primaryCD = EditorGUILayout.Toggle("Primery CD", weapon.primaryCD);
                weapon.primaryCdStartAfterShots = EditorGUILayout.FloatField("Primery CD starts after shoots", weapon.primaryCdStartAfterShots);
                weapon.primaryCooldownTimer = EditorGUILayout.FloatField("Primery CD timer ", weapon.primaryCooldownTimer);
                EditorGUILayout.Space();
                weapon.alternativeCD = EditorGUILayout.Toggle("Alternative CD", weapon.alternativeCD);
            }
           
            if (weapon.alternativeCD && !weapon.primaryCD)
            {
                weapon.primaryCD = EditorGUILayout.Toggle("Primery CD", weapon.primaryCD);
                EditorGUILayout.Space();
                weapon.alternativeCD = EditorGUILayout.Toggle("Alternative CD", weapon.alternativeCD);
                weapon.alternativeCdStartAfterShots = EditorGUILayout.FloatField("Alternative CD starts after shoots", weapon.alternativeCdStartAfterShots);
                weapon.alternativeCooldownTimer = EditorGUILayout.FloatField("Alternative CD timer ", weapon.alternativeCooldownTimer);
                EditorGUILayout.Space();
            }

            //______________________________________Bullets_________________

            weapon.bulletTypes = EditorGUILayout.Foldout(weapon.bulletTypes, "BulletTypes", false);

            if (weapon.bulletTypes && !weapon.bullet_1 && !weapon.bullet_2 && !weapon.bullet_3
                 && !weapon.bullet_4 && !weapon.bullet_5 && !weapon.bullet_6)
            {
                weapon.bullet_1 = EditorGUILayout.Toggle("bullet_1", weapon.bullet_1);
                weaponManager.bullet_1count = EditorGUILayout.FloatField("bullet_1count", weaponManager.bullet_1count);
                EditorGUILayout.Space();
                weapon.bullet_2 = EditorGUILayout.Toggle("bullet_2", weapon.bullet_2);
                weaponManager.bullet_2count = EditorGUILayout.FloatField("bullet_2count", weaponManager.bullet_2count);
                EditorGUILayout.Space();
                weapon.bullet_3 = EditorGUILayout.Toggle("bullet_3", weapon.bullet_3);
                weaponManager.bullet_3count = EditorGUILayout.FloatField("bullet_3count", weaponManager.bullet_3count);
                EditorGUILayout.Space();
                weapon.bullet_4 = EditorGUILayout.Toggle("bullet_4", weapon.bullet_4);
                weaponManager.bullet_4count = EditorGUILayout.FloatField("bullet_4count", weaponManager.bullet_4count);
                EditorGUILayout.Space();
                weapon.bullet_5 = EditorGUILayout.Toggle("bullet_5", weapon.bullet_5);
                weaponManager.bullet_5count = EditorGUILayout.FloatField("bullet_5count", weaponManager.bullet_5count);
                EditorGUILayout.Space();
                weapon.bullet_6 = EditorGUILayout.Toggle("bullet_6", weapon.bullet_6);
                weaponManager.bullet_6count = EditorGUILayout.FloatField("bullet_6count", weaponManager.bullet_6count);
                EditorGUILayout.Space();
            }
            else if (weapon.bulletTypes && weapon.bullet_1)
            {
                weapon.bullet_1 = EditorGUILayout.Toggle("bullet_1", weapon.bullet_1);
                weaponManager.bullet_1count = EditorGUILayout.FloatField("bullet_1count", weaponManager.bullet_1count);
            }
            else if (weapon.bulletTypes && weapon.bullet_2)
            {
                weapon.bullet_2 = EditorGUILayout.Toggle("bullet_2", weapon.bullet_2);
                weaponManager.bullet_2count = EditorGUILayout.FloatField("bullet_2count", weaponManager.bullet_2count);
            }
            else if (weapon.bulletTypes && weapon.bullet_3)
            {
                weapon.bullet_3 = EditorGUILayout.Toggle("bullet_3", weapon.bullet_3);
                weaponManager.bullet_3count = EditorGUILayout.FloatField("bullet_3count", weaponManager.bullet_3count);
            }
            else if (weapon.bulletTypes && weapon.bullet_4)
            {
                weapon.bullet_4 = EditorGUILayout.Toggle("bullet_4", weapon.bullet_4);
                weaponManager.bullet_4count = EditorGUILayout.FloatField("bullet_4count", weaponManager.bullet_4count);
            }
            else if (weapon.bulletTypes && weapon.bullet_5)
            {
                weapon.bullet_5 = EditorGUILayout.Toggle("bullet_5", weapon.bullet_5);
                weaponManager.bullet_5count = EditorGUILayout.FloatField("bullet_5count", weaponManager.bullet_5count);
            }
            else if (weapon.bulletTypes && weapon.bullet_6)
            {
                weapon.bullet_6 = EditorGUILayout.Toggle("bullet_6", weapon.bullet_6);
                weaponManager.bullet_6count = EditorGUILayout.FloatField("bullet_6count", weaponManager.bullet_6count);
            }

            //__________________________________________________Main___V

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            if (weapon.itemType == ItemType.HitScan)
            {
                hitScan = true;
                projectile = false;
                projectilThrowMode = false;

                weapon.shotGun = EditorGUILayout.Toggle("ShotGun", weapon.shotGun);
                if (weapon.shotGun)
                {
                    weapon.primaryShotGunlBulletsPerShot = EditorGUILayout.FloatField("ShotGunBulletsPerShot", weapon.primaryShotGunlBulletsPerShot);
                }
                weapon.primaryDamage = EditorGUILayout.FloatField("Damage", weapon.primaryDamage);
                weapon.primaryHs_fireSpreadAngle = EditorGUILayout.FloatField("FireSpreadAngle", weapon.primaryHs_fireSpreadAngle);
                weapon.primaryHs_fireDistance = EditorGUILayout.FloatField("FireDistance", weapon.primaryHs_fireDistance);
                weapon.primaryHs_FireRate = EditorGUILayout.FloatField("FireRate", weapon.primaryHs_FireRate);
                weapon.primaryHs_ImpactForce = EditorGUILayout.FloatField("ImpactForce", weapon.primaryHs_ImpactForce);
                weapon.hs_ImpactEffect = (GameObject)EditorGUILayout.ObjectField("ImpactEffect", weapon.hs_ImpactEffect, typeof(GameObject), true);
            }
            else if (weapon.itemType == ItemType.Projectile)
            {
                projectile = true;
                hitScan = false;
                projectilThrowMode = false;

                weapon.bulletPrefab = (GameObject)EditorGUILayout.ObjectField("BulletPrefab", weapon.bulletPrefab, typeof(GameObject), false);
                weapon.bulletReaspawnPoint = (Transform)EditorGUILayout.ObjectField("BulletReaspawnPoin", weapon.bulletReaspawnPoint, typeof(Transform), true);
                EditorGUILayout.Space();
                weapon.primary_WaitForStartAttackTime = EditorGUILayout.FloatField("WaitForStartAttackTime", weapon.primary_WaitForStartAttackTime);
                weapon.primary_TimeBetweenAttacks = EditorGUILayout.FloatField("TimeBetweenAttacks", weapon.primary_TimeBetweenAttacks);
                weapon.primary_BulletSpeed = EditorGUILayout.FloatField("BulletSpeed", weapon.primary_BulletSpeed);
            }
            else if (weapon.itemType == ItemType.ProjectileThrowMode)
            {
                projectilThrowMode = true;
                hitScan = false;
                projectile = false;

                if(!weapon.hitDamage && !weapon.splashDamage)
                {
                    weapon.hitDamage = EditorGUILayout.Toggle("HitDamage", weapon.hitDamage);
                    weapon.splashDamage = EditorGUILayout.Toggle("SplashDamage", weapon.splashDamage);
                }

                if (weapon.hitDamage)
                {
                    weapon.hitDamage = EditorGUILayout.Toggle("HitDamage", weapon.hitDamage);
                    EditorGUILayout.Space();
                    weapon.throwAngle = EditorGUILayout.FloatField("ThrowAngle", weapon.throwAngle);
                    weapon.timeBetweenThrows = EditorGUILayout.FloatField("TimeBetweenThrows", weapon.timeBetweenThrows);
                    weapon.throwingForce = EditorGUILayout.FloatField("ThrowForce", weapon.throwingForce);
                }
                
                if (weapon.splashDamage)
                {
                    weapon.splashDamage = EditorGUILayout.Toggle("SplashDamage", weapon.splashDamage);
                    EditorGUILayout.Space();
                    weapon.throwAngle = EditorGUILayout.FloatField("ThrowAngle", weapon.throwAngle); ;
                    weapon.timeBetweenThrows = EditorGUILayout.FloatField("TimeBetweenThrows", weapon.timeBetweenThrows);
                    EditorGUILayout.Space();
                }
            }

            //__________________________________________________Alternative___V

            weapon.alternativeShot = EditorGUILayout.Toggle("AlternativeShot", weapon.alternativeShot);

            if (weapon.alternativeShot)
            {
                if (!weapon.alterantiveHitScan && !weapon.alternativeProjectile && !weapon.alternativeProjectileThrowMode)
                {
                    weapon.alterantiveHitScan = EditorGUILayout.Toggle("HitScan", weapon.alterantiveHitScan);
                    weapon.alternativeProjectile = EditorGUILayout.Toggle("Projectile", weapon.alternativeProjectile);
                    weapon.alternativeProjectileThrowMode = EditorGUILayout.Toggle("ProjectileThrowMode", weapon.alternativeProjectileThrowMode);
                }
                else if (weapon.alterantiveHitScan)
                {
                    weapon.alterantiveHitScan = EditorGUILayout.Toggle("HitScan", weapon.alterantiveHitScan);
                    weapon.alternativeShotGun = EditorGUILayout.Toggle("Alternative ShotGun", weapon.alternativeShotGun);
                    if (weapon.alternativeShotGun)
                    {
                        weapon.alternativeShotGunBulletsPerShot = EditorGUILayout.FloatField("ShotGunBulletsPerShot", weapon.alternativeShotGunBulletsPerShot);
                    }

                    weapon.alternativeAmmoUsagePerShot = EditorGUILayout.FloatField("Ammo Usage Per Shot", weapon.alternativeAmmoUsagePerShot);
                    weapon.alternativeDamage = EditorGUILayout.FloatField("Damage", weapon.alternativeDamage);
                    weapon.alternativeHs_fireSpreadAngle = EditorGUILayout.FloatField("FireSpreadAngle", weapon.alternativeHs_fireSpreadAngle);
                    weapon.alternativeHs_fireDistance = EditorGUILayout.FloatField("FireDistance", weapon.alternativeHs_fireDistance);
                    weapon.alternativeHs_FireRate = EditorGUILayout.FloatField("FireRate", weapon.alternativeHs_FireRate);
                    weapon.alternativeHs_ImpactForce = EditorGUILayout.FloatField("ImpactForce", weapon.alternativeHs_ImpactForce);
                }
                else if (weapon.alternativeProjectile)
                {
                    weapon.alternativeProjectile = EditorGUILayout.Toggle("Projectile", weapon.alternativeProjectile);

                    //weapon.alternativeBulletPrefab = (GameObject)EditorGUILayout.ObjectField("BulletPrefab", weapon.alternativeBulletPrefab, typeof(GameObject), false);
                    //weapon.alternativeBulletReaspawnPoint = (Transform)EditorGUILayout.ObjectField("BulletReaspawnPoin", weapon.alternativeBulletReaspawnPoint, typeof(Transform), true);
                    EditorGUILayout.Space();
                    weapon.alternativeWaitForStartAttackTime = EditorGUILayout.FloatField("WaitForStartAttackTime", weapon.alternativeWaitForStartAttackTime);
                    weapon.alternativeTimeBetweenAttacks = EditorGUILayout.FloatField("TimeBetweenAttacks", weapon.alternativeTimeBetweenAttacks);
                    weapon.alternativeBulletSpeed = EditorGUILayout.FloatField("BulletSpeed", weapon.alternativeBulletSpeed);

                }
                else if (weapon.alternativeProjectileThrowMode)
                {
                    weapon.alternativeProjectileThrowMode = EditorGUILayout.Toggle("ProjectileThrowMode", weapon.alternativeProjectileThrowMode);
                }
            }
        }
    }

    #endregion


    //____________primary var___________using for Left click shooting_________________V
    #region Primasry

    //Hitscane Var
    [HideInInspector]
    public float primaryShotGunlBulletsPerShot;
    [HideInInspector]
    public float primaryDamage;
    [HideInInspector]
    public float primaryHs_fireSpreadAngle;
    [HideInInspector]
    public float primaryHs_fireDistance;
    [HideInInspector]
    public float primaryHs_FireRate;
    [HideInInspector]
    public float primaryHs_ImpactForce;


    //Projetile var
    [HideInInspector]
    public float primary_WaitForStartAttackTime;
    [HideInInspector]
    public float primary_TimeBetweenAttacks;
    [HideInInspector]
    public float primary_BulletSpeed;


    #endregion

    //___________Alternative Var__________using for Right click shooting____________V
    #region AlternativeVar

    bool alternativeFire;
    bool alternativeThrow;

    //Hit scane alterantive var
    [HideInInspector]
    public bool alternativeShot;

    [HideInInspector]
    public bool alterantiveHitScan = false;
    [HideInInspector]
    public bool alternativeShotGun = false;
    [HideInInspector]
    public float alternativeAmmoUsagePerShot;
    [HideInInspector]
    public float alternativeShotGunBulletsPerShot;
    [HideInInspector]
    public float alternativeDamage;
    [HideInInspector]
    public float alternativeHs_fireSpreadAngle;
    [HideInInspector]
    public float alternativeHs_fireDistance;
    [HideInInspector]
    public float alternativeHs_FireRate;
    [HideInInspector]
    public float alternativeHs_ImpactForce;


    //Projectile alterantive var
    [HideInInspector]
    public bool alternativeProjectile = false;

    [HideInInspector]
    public float alternativeWaitForStartAttackTime;
    [HideInInspector]
    public float alternativeTimeBetweenAttacks;
    [HideInInspector]
    public float alternativeBulletSpeed;



    [HideInInspector]
    public bool alternativeProjectileThrowMode = false;


    #endregion

    //__________Main Var_________Take value from _primary_ & _Alternative_ variables___________V

    #region MainVar

    bool fire;
    bool throwing;
    
    [HideInInspector]
    public bool primaryCD;
    [HideInInspector]
    public bool alternativeCD;

    [HideInInspector]
    public bool primaryCanShoot;
    [HideInInspector]
    public bool alternativeCanShoot;

    
    [HideInInspector]
    public float shotCount = 0f;

    [HideInInspector]
    public bool primaryCooldown;

    [HideInInspector]
    public float primaryCdStartAfterShots;
    [HideInInspector]
    public float primaryCooldownTimer;


    [HideInInspector]
    public bool alternativeCooldown;

    [HideInInspector]
    public float alternativeCdStartAfterShots;
    [HideInInspector]
    public float alternativeCooldownTimer;

    // Bulets
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


    //Hit scane var
    public static bool hitScan = true;

    [HideInInspector]
    public bool shotGun;
    [HideInInspector]
    public float shotGunPalletsPerShot;
    [HideInInspector]
    public float ammoUsagePerShot;
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public float hs_fireSpreadAngle;
    [HideInInspector]
    public float hs_fireDistance;
    [HideInInspector]
    public float hs_FireRate;
    [HideInInspector]
    public float hs_ImpactForce;
    [HideInInspector]
    public GameObject hs_ImpactEffect;

    //Projectile var
    public static bool projectile;

    [HideInInspector]
    public GameObject bulletPrefab;
    [HideInInspector]
    public Transform bulletReaspawnPoint;
    [HideInInspector]
    public float waitForStartAttackTime;
    [HideInInspector]
    public float timeBetweenAttacks;
    [HideInInspector]
    public float bulletSpeed;


    //Throw Mode var
    public static bool projectilThrowMode;

    [HideInInspector]
    public bool hitDamage;
    [HideInInspector]
    public bool splashDamage;

    [HideInInspector]
    public GameObject throwObjPrefab;
    [HideInInspector]
    public Transform throwObjectRespawnPoint;

    [HideInInspector]
    public float throwAngle;
    [HideInInspector]
    public float timeBetweenThrows;
    [HideInInspector]
    public float splashTimer;
    [HideInInspector]
    public float splashRadius;
    [HideInInspector]
    public float splashDamageAmount;
    [HideInInspector]
    public float throwingForce;

    [SerializeField] Animator gunAnimator;
    [SerializeField] ParticleSystem muzzleFlash;

    #endregion
    
    // Update is called once per frame
    public void Update()
    {
        fire = Input.GetKey(KeyCode.Mouse0);
        
        if (fire && primaryCD && shotCount >= primaryCdStartAfterShots)
        {
            shotCount = 0f;
            primaryCooldown = true;
            StartCoroutine(weaponManager.PrimaryCooldown(this));
        }

        if (alternativeFire && alternativeCD && shotCount >= alternativeCdStartAfterShots)
        {
            shotCount = 0f;
            alternativeCooldown = true;
            StartCoroutine(weaponManager.AlternativeCooldown(this));
        }

        weaponManager.AmmoCheck(this);

        if (fire)
        {
            Debug.Log("Bool is " + primaryCanShoot);
            if (primaryCanShoot)
            {
                if (hitScan)
                {
                    weaponManager.HitScanAttack(this);
                    gunAnimator.SetTrigger("Shoot");
                    gunAnimator.SetBool("Shoot", false);
                    Debug.Log("Shooting");
                    muzzleFlash.Play();
                }
                if (projectile)
                {
                    weaponManager.ProjectileWeapon(this);
                    Debug.Log("Shooting Projectiles");
                }
            }
        }
                
        if (projectilThrowMode)
        {
            throwing = Input.GetKeyUp(KeyCode.Mouse0);
            PrimaryShooting();
            if (throwing)
            {
                weaponManager.ProjectileThrowMode(this);
            }            
        }
        
        //______________________________________________________________AlternativeShooting_____V


        if (alternativeCanShoot)
        {
            alternativeFire = Input.GetKey(KeyCode.Mouse1);

            if (alterantiveHitScan)
            {                
                if (alternativeFire)
                {
                    AlternativeShooting();
                    StartCoroutine(weaponManager.AlternativeHitScan(this));
                }                
            }

            if (alternativeProjectile)
            {                
                if (alternativeFire)
                {
                    AlternativeShooting();                    
                    weaponManager.ProjectileWeapon(this);
                }                
            }
        }

        if (alternativeProjectileThrowMode)
        {            
            alternativeThrow = Input.GetKeyUp(KeyCode.Mouse1);

            if (alternativeThrow)
            {
                AlternativeShooting();
                weaponManager.ProjectileThrowMode(this);
            }
        }
    }

    public void PrimaryShooting()
    {
        shotGunPalletsPerShot = primaryShotGunlBulletsPerShot;
        damage = primaryDamage;
        hs_fireSpreadAngle = primaryHs_fireSpreadAngle;
        hs_fireDistance = primaryHs_fireDistance;
        hs_FireRate = primaryHs_FireRate;
        hs_ImpactForce = primaryHs_ImpactForce;

        //bulletPrefab = primary_BulletPrefab;
        //bulletReaspawnPoint = primary_BulletReaspawnPoint;

        waitForStartAttackTime = primary_WaitForStartAttackTime;
        timeBetweenAttacks = primary_TimeBetweenAttacks;
        bulletSpeed = primary_BulletSpeed;
    }

    public void AlternativeShooting()
    {
        ammoUsagePerShot = alternativeAmmoUsagePerShot;
        shotGunPalletsPerShot = alternativeShotGunBulletsPerShot;
        damage = alternativeDamage;
        hs_fireSpreadAngle = alternativeHs_fireSpreadAngle;
        hs_fireDistance = alternativeHs_fireDistance;
        hs_FireRate = alternativeHs_FireRate;
        hs_ImpactForce = alternativeHs_ImpactForce;

        //bulletPrefab = alternativeBulletPrefab;
        //bulletReaspawnPoint = alternativeBulletReaspawnPoint;

        waitForStartAttackTime = alternativeWaitForStartAttackTime;
        timeBetweenAttacks = alternativeTimeBetweenAttacks;
        bulletSpeed = alternativeBulletSpeed;
    }
}



