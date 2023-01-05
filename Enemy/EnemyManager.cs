using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    GameObject Player;    
    public LayerMask GroundLayer, PlayerLayer, StaticMeshLayer;
    public Transform PlayerTransform;
    
    // Enemy Hit Scan_________________________________________________________V

    public bool HS_playerInAttackRange;    
    public bool HS_CanSeePlayer;
    public bool HS_alreadyAttacked;
    private bool follow = false;

    [SerializeField] Animator enemyAnimator;

    // Start is called before the first frame update
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void EnemyHitScan(Enemy enemy)
    {
        MainHitScan(enemy);
    }

    private void MainHitScan(Enemy enemy)
    {
        HS_playerInAttackRange = Physics.CheckSphere(enemy.EnemyObj.transform.position, enemy.HS_AttackRange, PlayerLayer);

        if (HS_CanSeePlayer && !HS_playerInAttackRange) enemy.ChasePlayer(this);
        if (HS_CanSeePlayer && HS_playerInAttackRange)
        {
            AttackPlayer(enemy);
            follow = false;
        }
        
        if (enemy.HS_playerInSightRange)
        {
            Vector3 DirectionToPlayer = (PlayerTransform.position - enemy.EnemyObj.transform.position).normalized;

            if (Vector3.Angle(enemy.EnemyObj.transform.forward, DirectionToPlayer) < enemy.HS_VewAngle / 2)
            {
                float DistanceToPlayer = Vector3.Distance(enemy.EnemyObj.transform.position, PlayerTransform.position);

                if (!Physics.Raycast(enemy.EnemyObj.transform.position, DirectionToPlayer, DistanceToPlayer, StaticMeshLayer))
                    HS_CanSeePlayer = true;
                else
                    HS_CanSeePlayer = false;
            }
            else HS_CanSeePlayer = false;
        }
        else if (HS_CanSeePlayer)
            HS_CanSeePlayer = false;

        if (HS_alreadyAttacked && HS_playerInAttackRange && enemy.HS_playerInSightRange && !HS_CanSeePlayer)
        {
            follow = true;
        }

        if (follow)
        {
            HS_CanSeePlayer = true;
            enemy.HS_playerInSightRange = true;
            enemy.ChasePlayer(this);
        }
    }

    

    private void AttackPlayer(Enemy enemy)
    {
        //Make sure enemy dosen't move
        enemy.agent.SetDestination(enemy.EnemyObj.transform.position);
        enemy.EnemyObj.transform.LookAt(PlayerTransform.position);

        if (!HS_alreadyAttacked)
        {
            //Attack code
            enemy.EnemyObj.transform.LookAt(PlayerTransform.position);
            StartCoroutine(WaitForStartAttack(enemy));

            //Attack();
            HS_alreadyAttacked = true;
            Invoke(nameof(ResetAttack), enemy.HS_timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        HS_alreadyAttacked = false;
    }

    private IEnumerator WaitForStartAttack(Enemy enemy)
    {
        yield return new WaitForSeconds(enemy.HS_WaitForStartAttackTime);

        Player.GetComponent<PL_Health>().PlayerTakeDamage(enemy.HS_EnemyDamage);
    }
    

    //Enemy Project Tile ____________________________________________________________________V

    public bool PT_alreadyAttacked;
    public bool PT_MoveToPlayer;
    public bool PT_playerInAttackRange, PT_CanSeePlayer;

    public void EnemyProjectTile(Enemy enemy)
    {
        MainProjectTile(enemy);
    }

    private void MainProjectTile(Enemy enemy)
    {

        PT_playerInAttackRange = Physics.CheckSphere(enemy.EnemyObj.transform.position, enemy.PT_AttackRange, PlayerLayer);

        if (PT_CanSeePlayer && !PT_playerInAttackRange) enemy.ChasePlayer(this);
        if (PT_CanSeePlayer && PT_playerInAttackRange)
        {
            PT_AttackPlayer(enemy);
            follow = false;
        }

        if (enemy.PT_playerInSightRange)
        {
            Vector3 DirectionToPlayer = (Player.transform.position - enemy.EnemyObj.transform.position).normalized;

            if (Vector3.Angle(enemy.EnemyObj.transform.forward, DirectionToPlayer) < enemy.PT_VewAngle / 2)
            {
                float DistanceToPlayer = Vector3.Distance(enemy.EnemyObj.transform.position, Player.transform.position);

                if (!Physics.Raycast(transform.position, DirectionToPlayer, DistanceToPlayer, StaticMeshLayer))
                    PT_CanSeePlayer = true;
                else
                    PT_CanSeePlayer = false;
            }
            else PT_CanSeePlayer = false;
        }
        else if (PT_CanSeePlayer)
            PT_CanSeePlayer = false;

        if (PT_alreadyAttacked && PT_playerInAttackRange && enemy.PT_playerInSightRange && !PT_CanSeePlayer)
        {
            follow = true;
        }

        if (follow)
        {
            enemy.PT_playerInSightRange = true;
            PT_CanSeePlayer = true;
            enemy.ChasePlayer(this);
        }
    }

    private void PT_AttackPlayer(Enemy enemy)
    {
        //Make sure enemy dosen't move
        enemy.agent.SetDestination(enemy.EnemyObj.transform.position);
        enemy.EnemyObj.transform.LookAt(Player.transform.position);

        if (!PT_alreadyAttacked)
        {
            //Attack code
            if (enemy != null)
            {
                enemy.EnemyObj.transform.LookAt(Player.transform.position);
                StartCoroutine(PT_WaitForStartAttack(enemy));
                PT_alreadyAttacked = true;

                Invoke(nameof(PT_ResetAttack), enemy.PT_timeBetweenAttacks);
            }            
        }
    }

    private void PT_ResetAttack()
    {
        PT_alreadyAttacked = false;
    }

    private IEnumerator PT_WaitForStartAttack(Enemy enemy)
    {
        yield return new WaitForSeconds(enemy.PT_WaitForStartAttackTime);
        if( enemy.PT_EnemyBulletReaspawnPoint != null)
        {
            var bullet = Instantiate(enemy.PT_EnemyBulletPrefab, enemy.PT_EnemyBulletReaspawnPoint.position, enemy.PT_EnemyBulletReaspawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = enemy.PT_EnemyBulletReaspawnPoint.forward * enemy.PT_EnemyBulletSpeed;
        }
    }
}
