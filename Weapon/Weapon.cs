using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Weapon : MonoBehaviour
{
    #region WeaponInspector

    enum ItemType { HitScan, Projectile, ProjectileDropMode }

    [Header("WeaponType")]
    [SerializeField] ItemType itemType;

    [CustomEditor(typeof(Weapon))]
    public class WeaponEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            WeaponManager WeaponManager;
            WeaponManager = GameObject.FindWithTag("Manager").GetComponent<WeaponManager>();

            Weapon weapon = (Weapon)target;

            weapon.bulletTypes = EditorGUILayout.Foldout(weapon.bulletTypes, "bulletTypes", false);

            if (weapon.bulletTypes && !weapon.bullet_1 && !weapon.bullet_2 && !weapon.bullet_3
                 && !weapon.bullet_4 && !weapon.bullet_5 && !weapon.bullet_6)
            {
                weapon.bullet_1 = EditorGUILayout.Toggle("bullet_1", weapon.bullet_1);
                WeaponManager.bullet_1count = EditorGUILayout.FloatField("bullet_1count", WeaponManager.bullet_1count);

                weapon.bullet_2 = EditorGUILayout.Toggle("bullet_2", weapon.bullet_2);
                WeaponManager.bullet_2count = EditorGUILayout.FloatField("bullet_2count", WeaponManager.bullet_2count);

                weapon.bullet_3 = EditorGUILayout.Toggle("bullet_3", weapon.bullet_3);
                WeaponManager.bullet_3count = EditorGUILayout.FloatField("bullet_3count", WeaponManager.bullet_3count);

                weapon.bullet_4 = EditorGUILayout.Toggle("bullet_4", weapon.bullet_4);
                WeaponManager.bullet_4count = EditorGUILayout.FloatField("bullet_4count", WeaponManager.bullet_4count);

                weapon.bullet_5 = EditorGUILayout.Toggle("bullet_5", weapon.bullet_5);
                WeaponManager.bullet_5count = EditorGUILayout.FloatField("bullet_5count", WeaponManager.bullet_5count);

                weapon.bullet_6 = EditorGUILayout.Toggle("bullet_6", weapon.bullet_6);
                WeaponManager.bullet_6count = EditorGUILayout.FloatField("bullet_6count", WeaponManager.bullet_6count);
            }
            else if (weapon.bulletTypes && weapon.bullet_1)
            {
                weapon.bullet_1 = EditorGUILayout.Toggle("bullet_1", weapon.bullet_1);
                WeaponManager.bullet_1count = EditorGUILayout.FloatField("bullet_1count", WeaponManager.bullet_1count);
            }
            else if (weapon.bulletTypes && weapon.bullet_2)
            {
                weapon.bullet_2 = EditorGUILayout.Toggle("bullet_2", weapon.bullet_2);
                WeaponManager.bullet_2count = EditorGUILayout.FloatField("bullet_2count", WeaponManager.bullet_2count);
            }
            else if (weapon.bulletTypes && weapon.bullet_3)
            {
                weapon.bullet_3 = EditorGUILayout.Toggle("bullet_3", weapon.bullet_3);
                WeaponManager.bullet_3count = EditorGUILayout.FloatField("bullet_3count", WeaponManager.bullet_3count);
            }
            else if (weapon.bulletTypes && weapon.bullet_4)
            {
                weapon.bullet_4 = EditorGUILayout.Toggle("bullet_4", weapon.bullet_4);
                WeaponManager.bullet_4count = EditorGUILayout.FloatField("bullet_4count", WeaponManager.bullet_4count);
            }
            else if (weapon.bulletTypes && weapon.bullet_5)
            {
                weapon.bullet_5 = EditorGUILayout.Toggle("bullet_5", weapon.bullet_5);
                WeaponManager.bullet_5count = EditorGUILayout.FloatField("bullet_5count", WeaponManager.bullet_5count);
            }
            else if (weapon.bulletTypes && weapon.bullet_6)
            {
                weapon.bullet_6 = EditorGUILayout.Toggle("bullet_6", weapon.bullet_6);
                WeaponManager.bullet_6count = EditorGUILayout.FloatField("bullet_6count", WeaponManager.bullet_6count);
            }

            //__________________________________________________Main___V

            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            if (weapon.itemType == ItemType.HitScan)
            {
                hitScan = true;
                projectile = false;
                projectilDropMode = false;

                weapon.shotGun = EditorGUILayout.Toggle("ShotGun", weapon.shotGun);
                if (weapon.shotGun)
                {
                    weapon.originalBulletsPerShot = EditorGUILayout.FloatField("bulletsPerShot", weapon.originalBulletsPerShot);
                }
                weapon.originalDamage = EditorGUILayout.FloatField("Damage", weapon.originalDamage);
                weapon.originalHs_fireSpreadAngle = EditorGUILayout.FloatField("FireSpreadAngle", weapon.originalHs_fireSpreadAngle);
                weapon.originalHs_fireDistance = EditorGUILayout.FloatField("FireDistance", weapon.originalHs_fireDistance);
                weapon.originalHs_FireRate = EditorGUILayout.FloatField("FireRate", weapon.originalHs_FireRate);
                weapon.originalHs_ImpactForce = EditorGUILayout.FloatField("ImpactForce", weapon.originalHs_ImpactForce);
                weapon.hs_ImpactEffect = (GameObject)EditorGUILayout.ObjectField("ImpactEffect", weapon.hs_ImpactEffect, typeof(GameObject), true);
            }
            else if (weapon.itemType == ItemType.Projectile)
            {
                projectile = true;
                hitScan = false;
                projectilDropMode = false;

                weapon.original_BulletPrefab = (GameObject)EditorGUILayout.ObjectField("BulletPrefab", weapon.original_BulletPrefab, typeof(GameObject), false);
                weapon.original_BulletReaspawnPoint = (Transform)EditorGUILayout.ObjectField("BulletReaspawnPoin", weapon.original_BulletReaspawnPoint, typeof(Transform), true);
                EditorGUILayout.Space();
                weapon.original_WaitForStartAttackTime = EditorGUILayout.FloatField("WaitForStartAttackTime", weapon.original_WaitForStartAttackTime);
                weapon.original_TimeBetweenAttacks = EditorGUILayout.FloatField("TimeBetweenAttacks", weapon.original_TimeBetweenAttacks);
                weapon.original_BulletSpeed = EditorGUILayout.FloatField("BulletSpeed", weapon.original_BulletSpeed);
            }
            else if (weapon.itemType == ItemType.ProjectileDropMode)
            {
                projectilDropMode = true;
                hitScan = false;
                projectile = false;

                if (!weapon.hitDamage)
                {
                    weapon.splashDamage = true;
                }
                else if (!weapon.splashDamage)
                {
                    weapon.hitDamage = true;
                }

                weapon.hitDamage = EditorGUILayout.Foldout(weapon.hitDamage, "HitDamage", true);
                if (weapon.hitDamage)
                {
                    weapon.splashDamage = false;
                    weapon.dropObjPrefab = (GameObject)EditorGUILayout.ObjectField("DropObjPrefab", weapon.dropObjPrefab, typeof(GameObject), false);
                    weapon.dropObjectRespawnPoint = (Transform)EditorGUILayout.ObjectField("DropObjectRespawnPoint", weapon.dropObjectRespawnPoint, typeof(Transform), true);
                    EditorGUILayout.Space();
                    weapon.dropAngle = EditorGUILayout.FloatField("DropAngle", weapon.dropAngle);
                    weapon.waitForDrop = EditorGUILayout.FloatField("WaitForDrop", weapon.waitForDrop);
                    weapon.timeBetweenDrops = EditorGUILayout.FloatField("TimeBetweenDrops", weapon.timeBetweenDrops);
                    weapon.dropForce = EditorGUILayout.FloatField("DropForce", weapon.dropForce);
                }

                weapon.splashDamage = EditorGUILayout.Foldout(weapon.splashDamage, "SplashDamage", false);
                if (weapon.splashDamage)
                {
                    weapon.hitDamage = false;

                    weapon.splashDamageAmount = EditorGUILayout.FloatField("SplashDamageAmount", weapon.splashDamageAmount);
                    weapon.dropForce = EditorGUILayout.FloatField("DropForce", weapon.dropForce);
                    weapon.splashRadius = EditorGUILayout.FloatField("SplashRadius", weapon.splashRadius);
                    weapon.splashTimer = EditorGUILayout.FloatField("SplashTimer", weapon.splashTimer);
                    EditorGUILayout.Space();
                    weapon.dropAngle = EditorGUILayout.FloatField("DropAngle", weapon.dropAngle);
                    weapon.waitForDrop = EditorGUILayout.FloatField("WaitForDrop", weapon.waitForDrop);
                    weapon.timeBetweenDrops = EditorGUILayout.FloatField("TimeBetweenDrops", weapon.timeBetweenDrops);
                    EditorGUILayout.Space();
                    weapon.dropObjPrefab = (GameObject)EditorGUILayout.ObjectField("DropObjPrefab", weapon.dropObjPrefab, typeof(GameObject), false);
                    weapon.dropObjectRespawnPoint = (Transform)EditorGUILayout.ObjectField("DropObjectRespawnPoint", weapon.dropObjectRespawnPoint, typeof(Transform), true);
                }
            }



            //__________________________________________________Alternative___V

            weapon.alternativeShot = EditorGUILayout.Toggle("AlternativeShot", weapon.alternativeShot);

            if (weapon.alternativeShot)
            {
                if (!weapon.alterantiveHitScan && !weapon.alternativeProjectile && !weapon.alternativeProjectileDropMode)
                {
                    weapon.alterantiveHitScan = EditorGUILayout.Toggle("HitScan", weapon.alterantiveHitScan);
                    weapon.alternativeProjectile = EditorGUILayout.Toggle("Projectile", weapon.alternativeProjectile);
                    weapon.alternativeProjectileDropMode = EditorGUILayout.Toggle("ProjectileDropMode", weapon.alternativeProjectileDropMode);
                }               
                else if (weapon.alterantiveHitScan)
                {
                    weapon.alterantiveHitScan = EditorGUILayout.Toggle("HitScan", weapon.alterantiveHitScan);
                    weapon.alternativeShotGun = EditorGUILayout.Toggle("Alternative ShotGun", weapon.alternativeShotGun);
                    if (weapon.alternativeShotGun)
                    {
                        weapon.alternativeBulletsPerShot = EditorGUILayout.FloatField("BulletsPerShot", weapon.alternativeBulletsPerShot);
                    }

                    weapon.alternativeDamage = EditorGUILayout.FloatField("Damage", weapon.alternativeDamage);
                    weapon.alternativeHs_fireSpreadAngle = EditorGUILayout.FloatField("FireSpreadAngle", weapon.alternativeHs_fireSpreadAngle);
                    weapon.alternativeHs_fireDistance = EditorGUILayout.FloatField("FireDistance", weapon.alternativeHs_fireDistance);
                    weapon.alternativeHs_FireRate = EditorGUILayout.FloatField("FireRate", weapon.alternativeHs_FireRate);
                    weapon.alternativeHs_ImpactForce = EditorGUILayout.FloatField("ImpactForce", weapon.alternativeHs_ImpactForce);
                }
                else if (weapon.alternativeProjectile)
                {
                    weapon.alternativeProjectile = EditorGUILayout.Toggle("Projectile", weapon.alternativeProjectile);

                    weapon.alternativeBulletPrefab = (GameObject)EditorGUILayout.ObjectField("BulletPrefab", weapon.alternativeBulletPrefab, typeof(GameObject), false);
                    weapon.alternativeBulletReaspawnPoint = (Transform)EditorGUILayout.ObjectField("BulletReaspawnPoin", weapon.alternativeBulletReaspawnPoint, typeof(Transform), true);
                    EditorGUILayout.Space();
                    weapon.alternativeWaitForStartAttackTime = EditorGUILayout.FloatField("WaitForStartAttackTime", weapon.alternativeWaitForStartAttackTime);
                    weapon.alternativeTimeBetweenAttacks = EditorGUILayout.FloatField("TimeBetweenAttacks", weapon.alternativeTimeBetweenAttacks);
                    weapon.alternativeBulletSpeed = EditorGUILayout.FloatField("BulletSpeed", weapon.alternativeBulletSpeed);

                }
                else if (weapon.alternativeProjectileDropMode)
                {
                    weapon.alternativeProjectileDropMode = EditorGUILayout.Toggle("ProjectileDropMode", weapon.alternativeProjectileDropMode);


                }
            }
        }
    }

    #endregion


    //____________Original var___________using for Left click shooting_________________V
    #region


    [HideInInspector]
    public float originalBulletsPerShot;
    [HideInInspector]
    public float originalDamage;
    [HideInInspector]
    public float originalHs_fireSpreadAngle;
    [HideInInspector]
    public float originalHs_fireDistance;
    [HideInInspector]
    public float originalHs_FireRate;
    [HideInInspector]
    public float originalHs_ImpactForce;



    [HideInInspector]
    public GameObject original_BulletPrefab;
    [HideInInspector]
    public Transform original_BulletReaspawnPoint;

    [HideInInspector]
    public float original_WaitForStartAttackTime;
    [HideInInspector]
    public float original_TimeBetweenAttacks;
    [HideInInspector]
    public float original_BulletSpeed;



    #endregion

    //___________Alternative Var__________using for Right click shooting____________V
    #region AlternativeVar

    bool alternativeFire;
    bool alternativeDrop;

    [HideInInspector]
    public bool alternativeShot;

    [HideInInspector]
    public bool alterantiveHitScan;
    [HideInInspector]
    public bool alternativeShotGun;

    [HideInInspector]
    public float alternativeBulletsPerShot;
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



    [HideInInspector]
    public bool alternativeProjectile;

    [HideInInspector]
    public GameObject alternativeBulletPrefab;
    [HideInInspector]
    public Transform alternativeBulletReaspawnPoint;

    [HideInInspector]
    public float alternativeWaitForStartAttackTime;
    [HideInInspector]
    public float alternativeTimeBetweenAttacks;
    [HideInInspector]
    public float alternativeBulletSpeed;



    [HideInInspector]
    public bool alternativeProjectileDropMode;


    


    #endregion

    //__________Main Var_________Take value from _Original_ & _Alternative_ variables___________V

    #region MainVar

    bool fire;
    bool drop;

    [HideInInspector]
    public bool canShoot;

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

    public static bool hitScan = true;

    [HideInInspector]
    public bool shotGun;
    [HideInInspector]
    public float bulletsPerShot;
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

    public static bool projectilDropMode;

    [HideInInspector]
    public bool hitDamage;
    [HideInInspector]
    public bool splashDamage;

    [HideInInspector]
    public GameObject dropObjPrefab;
    [HideInInspector]
    public Transform dropObjectRespawnPoint;

    [HideInInspector]
    public float dropAngle;
    [HideInInspector]
    public float waitForDrop;
    [HideInInspector]
    public float timeBetweenDrops;
    [HideInInspector]
    public float splashTimer;
    [HideInInspector]
    public float splashRadius;
    [HideInInspector]
    public float splashDamageAmount;
    [HideInInspector]
    public float dropForce;

    [HideInInspector]
    public bool coolDown;
    [HideInInspector]
    public float shotCount = 0f;

    public float coolStartAfterShots;
    public float coolDownTimer;

    public WeaponManager weaponManager;

    #endregion



    // Update is called once per frame
    public void Update()
    {

        if (shotCount >= coolStartAfterShots)
        {
            shotCount = 0f;
            coolDown = true;
            StartCoroutine(CoolDown());
        }

        weaponManager.Aim(this);

        //_________________________________________________________MainShooting_____V

        fire = Input.GetKey(KeyCode.Mouse0);        

        if (fire)
        {
            OriginalShooting();

            if (canShoot)
            {
                if (hitScan)
                {                   
                    weaponManager.HitScanAttack(this);
                }

                if (projectile)
                {                    
                    weaponManager.ProjectTileWeapon(this);
                }                
            }
        }

        drop = Input.GetKeyUp(KeyCode.Mouse0);

        if (drop)
        {
            OriginalShooting();
            if (projectilDropMode)
            {                
                weaponManager.ProjTileDropMode(this);
            }
        }

        //______________________________________________________________AlternativeShooting_____V

        alternativeFire = Input.GetKey(KeyCode.Mouse1);

        if (alternativeFire)
        {
            AlternativeShooting();
            if (canShoot)
            {
                if (alterantiveHitScan)
                {                    
                    weaponManager.HitScanAttack(this);
                }

                if (alternativeProjectile)
                {
                    weaponManager.ProjectTileWeapon(this);
                }
            }
        }

        alternativeDrop = Input.GetKeyUp(KeyCode.Mouse1);

        if (alternativeDrop)
        {
            AlternativeShooting();
            if (alternativeProjectileDropMode)
            {                
                weaponManager.ProjTileDropMode(this);
            }
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTimer);
        coolDown = false;
    }

    public void OriginalShooting()
    {
        bulletsPerShot = originalBulletsPerShot;
        damage = originalDamage;
        hs_fireSpreadAngle = originalHs_fireSpreadAngle;
        hs_fireDistance = originalHs_fireDistance;
        hs_FireRate = originalHs_FireRate;
        hs_ImpactForce = originalHs_ImpactForce;


        bulletPrefab = original_BulletPrefab;
        bulletReaspawnPoint = original_BulletReaspawnPoint;

        waitForStartAttackTime = original_WaitForStartAttackTime;
        timeBetweenAttacks = original_TimeBetweenAttacks;
        bulletSpeed = original_BulletSpeed;

    }

    public void AlternativeShooting()
    {
        bulletsPerShot = alternativeBulletsPerShot;
        damage = alternativeDamage;
        hs_fireSpreadAngle = alternativeHs_fireSpreadAngle;
        hs_fireDistance = alternativeHs_fireDistance;
        hs_FireRate = alternativeHs_FireRate;
        hs_ImpactForce = alternativeHs_ImpactForce;

        bulletPrefab = alternativeBulletPrefab;
        bulletReaspawnPoint = alternativeBulletReaspawnPoint;

        waitForStartAttackTime = alternativeWaitForStartAttackTime;
        timeBetweenAttacks = alternativeTimeBetweenAttacks;
        bulletSpeed = alternativeBulletSpeed;
    }
}

