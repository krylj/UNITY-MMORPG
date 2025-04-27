using UnityEngine;
using System.Collections;
using System;

public class Mob : MonoBehaviour
{
    public string mobName = "DefaultMob"; public int maxHP = 100; public int currentHP; public int attackPower = 10; public float attackRange = 2.0f; public float detectionRange = 10.0f; public float moveSpeed = 3.0f;

    private Transform player;
    private bool isChasing = false;
    private bool isAttacking = false;

    void Start()
    {
        currentHP = maxHP;
        
    }

    void Update()
    {
        if (player == null)
        {
            try
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            catch (Exception e)
            {
                return;
            }
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && !isAttacking)
        {
            isChasing = true;
        }
        else if (distanceToPlayer > detectionRange)
        {
            isChasing = false;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.LookAt(player);

            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                StartCoroutine(AttackPlayer());
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1.0f);
        Debug.Log(mobName + " attacks the player for " + attackPower + " damage!");
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log(mobName + " takes " + damage + " damage!");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(mobName + " hasdied!");
    
        Destroy(gameObject);
    }

}
