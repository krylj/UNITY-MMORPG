using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
{
    public int damage = 10;
    public float actionSpeed = 1f;
    private bool isAttacking = false;
    private float lastActionTime = 0f;
    private Health player; 
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        if (isAttacking){
            if (Time.time - lastActionTime >= actionSpeed){
                player.TakeDamage(damage);
                lastActionTime = Time.time;

            }
        }
    }

    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Player")){
            isAttacking = true;
            player = collision.gameObject.GetComponent<Health>();
        }
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("Player")){
            isAttacking = false;
            player = null;
        }
    }
}