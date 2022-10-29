using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;


public class Enemy : MonoBehaviour
{
    enum EnemyTipe { HitScan, ProjectTile }

    [Header("EnemyAttackType")]
    [SerializeField] EnemyTipe enemyType;

    [CustomEditor(typeof(Enemy))]
    public class EnemyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Enemy enemy = (Enemy)target;

            if (enemy.enemyType == EnemyTipe.HitScan)
            {
                enemy.HitScan = true;
                enemy.ProjectTile = false;
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                enemy.HS_EnemyDamage = EditorGUILayout.FloatField("EnemyDamage", enemy.HS_EnemyDamage);
                enemy.Enemyhealth = EditorGUILayout.FloatField("Enemyhealth", enemy.Enemyhealth);
                enemy.HS_timeBetweenAttacks = EditorGUILayout.FloatField("TimeBetweenAttacks", enemy.HS_timeBetweenAttacks);
                enemy.HS_AttackRange = EditorGUILayout.FloatField("AttackRange", enemy.HS_AttackRange);
                enemy.HS_SightRange = EditorGUILayout.FloatField("SightRange", enemy.HS_SightRange);
                enemy.HS_VewAngle = EditorGUILayout.FloatField("VewAngle", enemy.HS_VewAngle);
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                enemy.EnemyObj = (GameObject)EditorGUILayout.ObjectField("PT_EnemyObj", enemy.EnemyObj, typeof(GameObject), true);
                enemy.PT_EnemyBulletPrefab = (GameObject)EditorGUILayout.ObjectField("BulletPrefab", enemy.PT_EnemyBulletPrefab, typeof(GameObject), true);
                enemy.PT_EnemyBulletReaspawnPoint = (Transform)EditorGUILayout.ObjectField("BulletReaspawnPoin", enemy.PT_EnemyBulletReaspawnPoint, typeof(Transform), true);
                enemy.agent = (NavMeshAgent)EditorGUILayout.ObjectField("PT_agent", enemy.agent, typeof(NavMeshAgent), true);
            }
            else if (enemy.enemyType == EnemyTipe.ProjectTile)
            {
                enemy.ProjectTile = true;
                enemy.HitScan = false;
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                enemy.Enemyhealth = EditorGUILayout.FloatField("Enemyhealth", enemy.Enemyhealth);
                enemy.PT_AttackRange = EditorGUILayout.FloatField("AttackRange", enemy.PT_AttackRange);
                enemy.PT_EnemyBulletSpeed = EditorGUILayout.FloatField("BulletSpeed", enemy.PT_EnemyBulletSpeed);
                enemy.PT_SightRange = EditorGUILayout.FloatField("SightRange", enemy.PT_SightRange);
                enemy.PT_VewAngle = EditorGUILayout.FloatField("VewAngle", enemy.PT_VewAngle);
                EditorGUILayout.Space();
                enemy.PT_WaitForStartAttackTime = EditorGUILayout.FloatField("WaitForStartAttackTime", enemy.PT_WaitForStartAttackTime);
                enemy.PT_timeBetweenAttacks = EditorGUILayout.FloatField("TimeBetweenAttacks", enemy.PT_timeBetweenAttacks);
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                enemy.EnemyObj = (GameObject)EditorGUILayout.ObjectField("PT_EnemyObj", enemy.EnemyObj, typeof(GameObject), true);
                enemy.PT_EnemyBulletPrefab = (GameObject)EditorGUILayout.ObjectField("BulletPrefab", enemy.PT_EnemyBulletPrefab, typeof(GameObject), true);
                enemy.PT_EnemyBulletReaspawnPoint = (Transform)EditorGUILayout.ObjectField("BulletReaspawnPoin", enemy.PT_EnemyBulletReaspawnPoint, typeof(Transform), true);
                enemy.agent = (NavMeshAgent)EditorGUILayout.ObjectField("PT_agent", enemy.agent, typeof(NavMeshAgent), true);
            }
        }
    }

    [HideInInspector]
    public float Enemyhealth;

    //Hit Scane Mode__________________________________________________________________V
    [HideInInspector]
    public bool HitScan;
    [HideInInspector]
    public float HS_timeBetweenAttacks;
    [HideInInspector]
    public float HS_EnemyDamage;
    [HideInInspector]
    public float HS_AttackRange;
    [HideInInspector]
    public float HS_SightRange;
    [HideInInspector]
    [Range(0, 360)] public float HS_VewAngle;
    [HideInInspector]
    public float HS_WaitForStartAttackTime;    
    
    //Project Tile Mode________________________________________________________________V

    [HideInInspector]
    public bool ProjectTile;

    [HideInInspector]
    public float PT_EnemyMaxHealth;

    //Attacking
    [HideInInspector]
    public float PT_timeBetweenAttacks;
    [HideInInspector]
    public float PT_WaitForStartAttackTime = 0.5f;

    //States    
    [HideInInspector]
    public float PT_AttackRange;
    [HideInInspector]
    public float PT_EnemyBulletSpeed;
    [HideInInspector]
    public float PT_SightRange;
    [HideInInspector]
    [Range(0, 360)] public float PT_VewAngle;

    [HideInInspector]
    public bool HS_playerInSightRange;
    [HideInInspector]
    public bool PT_playerInSightRange;

    //__________________________________________________________________

    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public GameObject EnemyObj;
    [HideInInspector]
    public GameObject PT_EnemyBulletPrefab;
    [HideInInspector]
    public Transform PT_EnemyBulletReaspawnPoint;

    public EnemyManager enemyManager;

    //__________________________________________________________________

    // Update is called once per frame
    public void Update()
    {
        HS_playerInSightRange = Physics.CheckSphere(EnemyObj.transform.position, HS_SightRange, enemyManager.PlayerLayer);
        PT_playerInSightRange = Physics.CheckSphere(EnemyObj.transform.position, PT_SightRange, enemyManager.PlayerLayer);

        if (HitScan)
        {
            enemyManager.EnemyHitScan(this);
        }

        if (ProjectTile)
        {
            enemyManager.EnemyProjectTile(this);
        }
    }

    public void TakeDamage(float amount)
    {
        Enemyhealth -= amount;

        if (Enemyhealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void ChasePlayer(EnemyManager enemyManager)
    {
        agent.SetDestination(enemyManager.PlayerTransform.position);
    }

    public void PT_ChasePlayer(EnemyManager enemyManager)
    {
        agent.SetDestination(enemyManager.PlayerTransform.position);
    }

}

