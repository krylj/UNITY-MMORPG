using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Combat Settings")]
    public float aggroRange = 10f;      // Dosah, ve kter�m za�ne nep��tel reagovat na hr��e
    public float attackRange = 2f;     // Dosah, ve kter�m nep��tel �to��
    public int damage = 10;            // Po�kozen� zp�soben� hr��em
    public int maxHP = 50;             // Maxim�ln� po�et �ivot� nep��tele
    private int currentHP;             // Aktu�ln� �ivoty nep��tele

    [Header("Movement Settings")]
    public float movementSpeed = 3f;  // Rychlost pohybu nep��tele
    public float movementRange = 15f; // Vzd�lenost, do kter� se m��e nep��tel pohybovat od sv�ho v�choz�ho bodu
    private Vector3 startingPosition; // Startovn� pozice nep��tele

    [Header("Player Reference")]
    public Transform player;          // Odkaz na hr��e

    void Start()
    {
        startingPosition = transform.position; // Ulo�en� startovn� pozice nep��tele
        currentHP = maxHP; // Inicializace �ivot�
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        float distanceFromStart = Vector3.Distance(transform.position, startingPosition);

        if (distanceToPlayer <= aggroRange && distanceFromStart <= movementRange)
        {
            if (distanceToPlayer > attackRange)
            {
                // Pron�sledov�n� hr��e
                ChasePlayer();
            }
            else
            {
                // �tok na hr��e
                AttackPlayer();
            }
        }
        else if (distanceFromStart > movementRange)
        {
            // N�vrat do v�choz� pozice
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
        Debug.Log("Nep��tel �to��! Zp�sobuje " + damage + " po�kozen�.");
        // Zde m��ete p�idat logiku pro sn�en� HP hr��e
    }

    void ReturnToStart()
    {
        Vector3 direction = (startingPosition - transform.position).normalized;
        transform.position += direction * movementSpeed * Time.deltaTime;

        // Pokud je nep��tel velmi bl�zko startovn� pozice, zastavte ho
        if (Vector3.Distance(transform.position, startingPosition) < 0.1f)
        {
            transform.position = startingPosition;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Nep��tel dostal " + damage + " po�kozen�! Zb�vaj�c� HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Nep��tel zem�el!");
        Destroy(gameObject); // Smaz�n� nep��tele
    }
}
