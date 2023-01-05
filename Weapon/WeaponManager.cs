using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WeaponManager : MonoBehaviour
{        
    public Camera fpsCam;
    public LayerMask enemy;
    bool alreadyAttacked;

    public GameObject BulletHole;
    [SerializeField] PlayableDirector timeline;

    //_____Boolets Var____________________________V

    [HideInInspector]
    public float bullet_1count;
    [HideInInspector]
    public float bullet_2count;
    [HideInInspector]
    public float bullet_3count;
    [HideInInspector]
    public float bullet_4count;
    [HideInInspector]
    public float bullet_5count;
    [HideInInspector]
    public float bullet_6count;

    [HideInInspector]
    public float bullet_1MaxCount = 100f;
    [HideInInspector]
    public float bullet_2MaxCount = 100f;
    [HideInInspector]
    public float bullet_3MaxCount = 100f;
    [HideInInspector]
    public float bullet_4MaxCount = 100f;
    [HideInInspector]
    public float bullet_5MaxCount = 100f;
    [HideInInspector]
    public float bullet_6MaxCount = 100f;

    public void HitScanAttack(Weapon weapon)
    {
        if (!alreadyAttacked)
        {
            //Attack code
            HitScanWeapon(weapon);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 1/weapon.hs_FireRate);
        }
    }

    private void HitScanWeapon(Weapon weapon)
    {
        AmmoSpending(weapon);

        if (weapon.shotGun || weapon.alternativeShotGun)
        {
            FiringShotGunHitScan(weapon);
        }
        else if (!weapon.shotGun || !weapon.alternativeShotGun)
        {
            FiringHitScan(weapon);
        }
    }

    private void FiringShotGunHitScan(Weapon weapon)
    {
        Vector3 FireDirection = fpsCam.transform.forward;
        Quaternion StartRotation = Quaternion.LookRotation(FireDirection);
        Quaternion RandomAngle;
        Quaternion FireRotation;

        for (int i = 0; i < weapon.shotGunPalletsPerShot; i++)
        {
            RandomAngle = Random.rotation;
            FireRotation = Quaternion.RotateTowards(StartRotation, RandomAngle, Random.Range(0.0f, weapon.hs_fireSpreadAngle));

            RaycastHit Hit;
            if (Physics.Raycast(fpsCam.transform.position, FireRotation * Vector3.forward, out Hit, weapon.hs_fireDistance))
            {
                Debug.Log(Hit.transform.name);

                timeline.Play();

                ItemController itemController = Hit.transform.GetComponent<ItemController>();
                if (itemController != null)
                    itemController.TakeDamage(weapon.damage);

                Enemy enemy = Hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                    enemy.TakeDamage(weapon.damage);

                if (Hit.rigidbody != null)
                    Hit.rigidbody.AddForce(-Hit.normal * weapon.hs_ImpactForce);

                GameObject impactGO = Instantiate(weapon.hs_ImpactEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
                Destroy(impactGO, 0.03f);
            }
        }
    }

    private void FiringHitScan(Weapon weapon)
    {
        Vector3 FireDirection = fpsCam.transform.forward;
        Quaternion StartRotation = Quaternion.LookRotation(FireDirection);
        Quaternion RandomAngle = Random.rotation;
        Quaternion FireRotation = Quaternion.RotateTowards(StartRotation, RandomAngle, Random.Range(0.0f, weapon.hs_fireSpreadAngle));

        RaycastHit Hit;
        if (Physics.Raycast(fpsCam.transform.position, FireRotation * Vector3.forward, out Hit, weapon.hs_fireDistance))
        {
            Debug.Log(Hit.transform.name);

            timeline.Play();

            ItemController itemController = Hit.transform.GetComponent<ItemController>();
            if (itemController != null)
            {
                itemController.TakeDamage(weapon.damage);
            }

            Enemy enemy = Hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(weapon.damage);
            }
            else
            {
                Debug.Log("Hit a wall");
                Instantiate(BulletHole, Hit.point + (Hit.normal * .01f), Quaternion.FromToRotation(Vector3.up, Hit.normal));
            }

            if (Hit.rigidbody != null)
            {
                Hit.rigidbody.AddForce(-Hit.normal * weapon.hs_ImpactForce);
            }

            GameObject impactGO = Instantiate(weapon.hs_ImpactEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
            Destroy(impactGO, 0.03f);
        }
    }

    //Alternative HitScan Shooting + Ammo usage per shot____________________________________________________V

    public IEnumerator AlternativeHitScan(Weapon weapon)
    {
        for (int i = 0; i < weapon.ammoUsagePerShot; i++)
        {
            if (weapon.alternativeCanShoot)
            {
                yield return new WaitForSeconds(1 / weapon.alternativeHs_FireRate);
                HitScanAttack(weapon);
            }
        }
    }


    //ProjectileWeapon______________________________________________________________________________V

    public void ProjectileWeapon(Weapon weapon)
    {
        if (!alreadyAttacked)
        {
            //Attack code
            StartCoroutine(WaitForStartAttack(weapon));

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), weapon.timeBetweenAttacks);
        }
    }

    private IEnumerator WaitForStartAttack(Weapon weapon)
    {
        yield return new WaitForSeconds(weapon.waitForStartAttackTime);

        var bullet = Instantiate(weapon.bulletPrefab, weapon.bulletReaspawnPoint.position, weapon.bulletReaspawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = weapon.bulletReaspawnPoint.forward * weapon.bulletSpeed;

        timeline.Play();

        AmmoSpending(weapon);
    }

    public void ProjectileThrowMode(Weapon weapon)
    {
        if (!alreadyAttacked)
        {
            //Attack code
            Throwing(weapon);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), weapon.timeBetweenThrows);
        }
    }

    private void Throwing(Weapon weapon)
    {
        var ThrowObj = Instantiate(weapon.throwObjPrefab, weapon.throwObjectRespawnPoint.position, weapon.throwObjectRespawnPoint.rotation);
        ThrowObj.GetComponent<Rigidbody>().velocity = weapon.throwObjectRespawnPoint.forward * weapon.throwingForce;

        timeline.Play();

        if (weapon.splashDamage)
        {
            SplashDamage(weapon);
            AmmoSpending(weapon);
        }
    }

    private void SplashDamage(Weapon weapon)
    {
        PL_ThrowObj pl_ThrowObj = GameObject.FindWithTag("ThrowObj").GetComponent<PL_ThrowObj>();

        if (pl_ThrowObj != null)
        {
            foreach (var Obj in pl_ThrowObj.InSplashRange)
            {
                Enemy enemy = Obj.GetComponent<Enemy>();
                Debug.Log(Obj.transform.name);

                if (enemy != null)
                {
                    enemy.TakeDamage(weapon.splashDamageAmount);
                }
            }
        }
    }
    
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    //_______________________________________________________________Cool Down________________

    public IEnumerator PrimaryCooldown(Weapon weapon)
    {
        yield return new WaitForSeconds(weapon.primaryCooldownTimer);
        weapon.primaryCooldown = false;
    }

    public IEnumerator AlternativeCooldown(Weapon weapon)
    {
        yield return new WaitForSeconds(weapon.alternativeCooldownTimer);
        weapon.alternativeCooldown = false;
    }

    //___________________________Boolets__________________________V

    private void AmmoSpending(Weapon weapon)
    {
        if (weapon.bullet_1 && bullet_1count > 0)
        {
            bullet_1count--;
        }
        else if (weapon.bullet_2 && bullet_2count > 0)
        {
            bullet_2count--;
        }
        else if (weapon.bullet_3 && bullet_3count > 0)
        {
            bullet_3count--;
        }
        else if (weapon.bullet_4 && bullet_4count > 0)
        {
            bullet_4count--;
        }
        else if (weapon.bullet_5 && bullet_5count > 0)
        {
            bullet_5count--;
        }
        else if (weapon.bullet_6 && bullet_6count > 0)
        {
            bullet_6count--;
        }

        weapon.shotCount += 1f;
    }

    public void AmmoCheck(Weapon weapon)
    {
        if (weapon.bullet_1 && bullet_1count > 0 || weapon.bullet_2 && bullet_2count > 0 || weapon.bullet_3 && bullet_3count > 0 ||
            weapon.bullet_4 && bullet_4count > 0 || weapon.bullet_5 && bullet_5count > 0 || weapon.bullet_6 && bullet_6count > 0)
        {
            if (weapon.primaryCooldown == false)
            {
                weapon.primaryCanShoot = true;
            }
            else weapon.primaryCanShoot = false;

            if (weapon.alternativeCooldown == false)
            {
                weapon.alternativeCanShoot = true;
            }
            else weapon.alternativeCanShoot = false;
        }
        else
        {
            weapon.primaryCanShoot = false;
            weapon.alternativeCanShoot = false;
        }
    }
}
