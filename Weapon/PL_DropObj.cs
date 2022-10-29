using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_DropObj : MonoBehaviour
{
    public float BulletLife = 3f;
    public float Damage = 25f;
    public Collider[] InSplashRange;
    

    public void Update()
    {
        Weapon weapon;
        weapon = GameObject.FindWithTag("Wepon").GetComponent<Weapon>();
        if (weapon.splashDamage)
        {
            InSplashRange = Physics.OverlapSphere(transform.position, weapon.splashRadius);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, BulletLife);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Weapon weapon;
        weapon = GameObject.FindWithTag("Wepon").GetComponent<Weapon>();
        if (weapon.hitDamage)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                Enemy enemy;
                enemy = collision.gameObject.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
