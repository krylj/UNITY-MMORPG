using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    // Start is called before the first frame update
    public int currentHealth = 100;
    public int maxHealth = 100;
    public Light light;
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0){
            light.color = Color.red;
        }
    }
    public void TakeDamage(int damage) {
        // damage reduction
        currentHealth -= damage;

        
    }
    public void Heal(int heal) {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}