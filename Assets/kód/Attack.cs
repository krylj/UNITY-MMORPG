using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{

    public int damage = 10;
    public float attackSpeed = 1f;
    public GameObject owner; 
    private string enemyTag;
    // Start is called before the first frame update
    void Start(){
        enemyTag = owner.tag == "Player" ? "Enemy" : "Player";
    }

    // Update is called once per frame
    void Update(){
        
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag(enemyTag)){
            Health enemy = collision.gameObject.GetComponent<Health>();
            enemy.TakeDamage(damage);
        }
    }
    public void Bonk(){
        transform.localRotation = Quaternion.Euler(90, 0, 0);
        Debug.Log("Bonk!");
        Invoke("ResetPosition", 4f);
    }
    public void ResetPosition(){
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    void OnCollisonEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.CompareTag(enemyTag)){
            Debug.Log("Enemy hit!");
            Health enemy = collision.gameObject.GetComponent<Health>();
            enemy.TakeDamage(damage);
        }
    }
}
