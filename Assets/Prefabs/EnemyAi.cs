using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Combat Settings")]
    public float aggroRange = 10f;      // Dosah, ve kterém zaène nepøítel reagovat na hráèe
    public float attackRange = 2f;     // Dosah, ve kterém nepøítel útoèí
    public int damage = 10;            // Poškození zpùsobené hráèem
    public int maxHP = 50;             // Maximální poèet životù nepøítele
    private int currentHP;             // Aktuální životy nepøítele

    [Header("Movement Settings")]
    public float movementSpeed = 3f;  // Rychlost pohybu nepøítele
    public float movementRange = 15f; // Vzdálenost, do které se mùže nepøítel pohybovat od svého výchozího bodu
    private Vector3 startingPosition; // Startovní pozice nepøítele

    [Header("Player Reference")]
    public Transform player;          // Odkaz na hráèe

    void Start()
    {
        startingPosition = transform.position; // Uložení startovní pozice nepøítele
        currentHP = maxHP; // Inicializace životù
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distanceFromStart = Vector3.Distance(transform.position, startingPosition);

        if (distanceToPlayer <= aggroRange && distanceFromStart <= movementRange)
        {
            if (distanceToPlayer > attackRange)
            {
                // Pronásledování hráèe
                ChasePlayer();
            }
            else
            {
                // Útok na hráèe
                AttackPlayer();
            }
        }
        else if (distanceFromStart > movementRange)
        {
            // Návrat do výchozí pozice
            ReturnToStart();
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    void AttackPlayer()
    {
        Debug.Log("Nepøítel útoèí! Zpùsobuje " + damage + " poškození.");
        // Zde mùžete pøidat logiku pro snížení HP hráèe
    }

    void ReturnToStart()
    {
        Vector3 direction = (startingPosition - transform.position).normalized;
        transform.position += direction * movementSpeed * Time.deltaTime;

        // Pokud je nepøítel velmi blízko startovní pozice, zastavte ho
        if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
        {
            transform.position = startingPosition;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Nepøítel dostal " + damage + " poškození! Zbývající HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Nepøítel zemøel!");
        Destroy(gameObject); // Smazání nepøítele
    }
}
