using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public int damage = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AttackPlayer()
    {
        Debug.Log("Nepøítel útoèí! Zpùsobuje " + damage + " poškození.");
        // Zde mùžete pøidat logiku pro snížení HP hráèe
    }
}
