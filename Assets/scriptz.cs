using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Combat Settings")]
    public float aggroRange = 10f;      // Dosah, ve kterém začne nepřítel reagovat na hráče
    public float attackRange = 2f;     // Dosah, ve kterém nepřítel útočí
    public int damage = 10;            // Poškození způsobené hráčem
    public int maxHP = 50;             // Maximální počet životů nepřítele
    private int currentHP;             // Aktuální životy nepřítele

    [Header("Movement Settings")]
    public float movementSpeed = 3f;  // Rychlost pohybu nepřítele
    public float movementRange = 15f; // Vzdálenost, do které se může nepřítel pohybovat od svého výchozího bodu
    private Vector3 startingPosition; // Startovní pozice nepřítele

    [Header("Player Reference")]
    public Transform player;          // Odkaz na hráče

    void Start()
    {
        startingPosition = transform.position; // Uložení startovní pozice nepřítele
        currentHP = maxHP; // Inicializace životů
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distanceFromStart = Vector3.Distance(transform.position, startingPosition);

        if (distanceToPlayer <= aggroRange && distanceFromStart <= movementRange)
        {
            if (distanceToPlayer > attackRange)
            {
                // Pronásledování hráče
                ChasePlayer();
            }
            else
            {
                // Útok na hráče
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
        Debug.Log("Nepřítel útočí! Způsobuje " + damage + " poškození.");
        // Zde můžete přidat logiku pro snížení HP hráče
    }

    void ReturnToStart()
    {
        Vector3 direction = (startingPosition - transform.position).normalized;
        transform.position += direction * movementSpeed * Time.deltaTime;

        // Pokud je nepřítel velmi blízko startovní pozice, zastavte ho
        if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
        {
            transform.position = startingPosition;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Nepřítel dostal " + damage + " poškození! Zbývající HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Nepřítel zemřel!");
        Destroy(gameObject); // Smazání nepřítele
    }
}