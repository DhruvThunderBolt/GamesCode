using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    public GameObject AttackPoint;

    public CharacterAnimations enemyAnims;
    public NavMeshAgent navAgent;
    private Transform playerTarget;
    private float moveSpeed = 3.5f;

    public float attackDistance = 1f;
    public float chaseAfterAttackDistance = 1f;

    private float waitBeforeAttackTime = 3f;
    private float attackTimer;

    public EnemyState enemyState;

    void Awake()
    {
        enemyAnims = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PlayerTag).transform;
    }

    void Start() 
    {
        enemyState = EnemyState.CHASE;

        attackTimer = waitBeforeAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState == EnemyState.CHASE)
        {
            ChasePlayer();
        }
        else if(enemyState == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = moveSpeed;

        if(navAgent.velocity.sqrMagnitude == 0)
        {
            enemyAnims.Walk(false);
        }
        else
        {
            enemyAnims.Walk(true);
        }

        if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK;
        }
    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        enemyAnims.Walk(false);

        attackTimer += Time.deltaTime;

        transform.LookAt(playerTarget.position);

        if(attackTimer >= waitBeforeAttackTime)
        {
            if(Random.Range(0,2) == 0)
            {
                enemyAnims.Attack1();
            }
            else
            {
                enemyAnims.Attack2();
            }
            attackTimer = 0f;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chaseAfterAttackDistance)
        {
            navAgent.isStopped = false;
            enemyState = EnemyState.CHASE;
        }
    }

    void ActivateAttackPoint()
    {
        AttackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if(AttackPoint.activeInHierarchy)
        {
            AttackPoint.SetActive(false);
        }
    }
}
