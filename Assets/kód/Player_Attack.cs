using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {
    public int damage = 10;
    public float attackSpeed = 1f;
    public int heal = 10;
    public bool canAttack = false;
    private float lastAttackTime = 0f;
    private float lastHealTime = 0f;
    public float healCooldown = 5f;
    public GameObject me;
    private Health enemy;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update() {
        if (canAttack) {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Player attacking!");
                if (Time.time - lastAttackTime >= attackSpeed)
                {
                    enemy.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            if (Time.time - lastHealTime >= healCooldown) {
                    Health player = me.GetComponent<Health>();
                    player.Heal(heal);
                    lastHealTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter(Collider collision) {
        Debug.Log("Collision detected!");
        if (collision.CompareTag("Enemy")) {
            Debug.Log("Enemy detected!");
            canAttack = true;
            enemy = collision.gameObject.GetComponent<Health>();
        }
    }

    private void OnTriggerExit(Collider collision) {
        Debug.Log("Collision exit detected!");
        canAttack = false;
        enemy = null;
    }
}
