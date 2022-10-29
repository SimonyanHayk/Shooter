using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletLife = 3f;
    public float damage = 25f;

    public void Awake()
    {
        Destroy(gameObject, bulletLife);        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy;
            enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else if (collision.gameObject.GetComponent<ItemController>())
        {
            ItemController itemController = collision.gameObject.GetComponent<ItemController>();
            if (itemController != null)
            {
                itemController.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
