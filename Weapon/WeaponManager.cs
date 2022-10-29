using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WeaponManager : MonoBehaviour
{        
    public Camera fpsCam;
    public LayerMask enemy;
    bool alreadyAttacked;

    [SerializeField] PlayableDirector timeline;
    
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
        AimWaste(weapon);

        if (weapon.shotGun || weapon.alternativeShotGun)
        {
            for (int i = 0; i < weapon.bulletsPerShot; i++)
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
        else if (!weapon.shotGun || !weapon.alternativeShotGun)
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

                if (Hit.rigidbody != null)
                {
                    Hit.rigidbody.AddForce(-Hit.normal * weapon.hs_ImpactForce);
                }

                GameObject impactGO = Instantiate(weapon.hs_ImpactEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
                Destroy(impactGO, 0.03f);
            }
        }
    }

    //ProjectTileWeapon______________________________________________________________________________V

    public void ProjectTileWeapon(Weapon weapon)
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

        AimWaste(weapon);
    }

    public void ProjTileDropMode(Weapon weapon)
    {
        if (!alreadyAttacked)
        {
            //Attack code
            StartCoroutine(WaitForDrop(weapon));

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), weapon.timeBetweenDrops);
        }
    }

    private IEnumerator WaitForDrop(Weapon weapon)
    {
        yield return new WaitForSeconds(weapon.waitForDrop);
        
        var DropObj = Instantiate(weapon.dropObjPrefab, weapon.dropObjectRespawnPoint.position, weapon.dropObjectRespawnPoint.rotation);
        DropObj.GetComponent<Rigidbody>().velocity = weapon.dropObjectRespawnPoint.forward * weapon.dropForce;

        timeline.Play();

        if (weapon.splashDamage)
        {            
            StartCoroutine(DropSplashDamage(weapon));
            AimWaste(weapon);
        }
    }

    PL_DropObj pl_DropObj;

    private IEnumerator DropSplashDamage(Weapon weapon)
    {
        yield return new WaitForSeconds(weapon.splashTimer);

        pl_DropObj = GameObject.FindWithTag("DropObj").GetComponent<PL_DropObj>();

        foreach (var Obj in pl_DropObj.InSplashRange)
        {
            Enemy enemy = Obj.GetComponent<Enemy>();
            Debug.Log(Obj.transform.name);

            if (enemy != null)
            {
                enemy.TakeDamage(weapon.splashDamageAmount);
            }
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

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

    private void AimWaste(Weapon weapon)
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

    public void Aim(Weapon weapon)
    {
        if (weapon.bullet_1 && bullet_1count > 0 || weapon.bullet_2 && bullet_2count > 0 || weapon.bullet_3 && bullet_3count > 0 ||
            weapon.bullet_4 && bullet_4count > 0 || weapon.bullet_5 && bullet_5count > 0 || weapon.bullet_6 && bullet_6count > 0)
        {
            if (weapon.coolDown == false)
            {
                weapon.canShoot = true;
            }
            else weapon.canShoot = false;
        }
        else weapon.canShoot = false;
    }
}
