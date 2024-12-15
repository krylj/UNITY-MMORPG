using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPTrigger : NetworkBehaviour
{
    public int xpAmount = 10; // Množství XP, které hráè získá

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Získej komponentu XPManager z hráèe
            XPManager xpManager = other.GetComponent<XPManager>();
            if (xpManager != null)
            {
                xpManager.AddXP(xpAmount); // Pøidej XP hráèi
            }
        }
    }
}