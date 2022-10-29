using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject PlayerHealth;

    public float Damage = 25;
    public float Life = 3f;

    public void Awake()
    {
        Destroy(gameObject, Life);
    }

    public void Start()
    {
        PlayerHealth = GameObject.Find("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.GetComponent<PL_Health>().PlayerTakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
