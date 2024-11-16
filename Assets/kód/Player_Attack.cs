using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {
    public int damage = 10;
    public float attackSpeed = 1f;
    public int heal = 30;
    private float lastAttackTime = 0f;
    private float lastHealTime = 0f;
    public float healCooldown = 5f;
    public GameObject me;
    public GameObject weapon;
    private Attack attack;
    // Start is called before the first frame update
    void Start(){
        attack = weapon.GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Player attacking!");
            if (Time.time - lastAttackTime >= attackSpeed){
                attack.Bonk();
                lastAttackTime = Time.time;
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
}
