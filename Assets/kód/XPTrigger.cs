using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPTrigger : NetworkBehaviour
{
    public int xpAmount = 10; // Mno�stv� XP, kter� hr�� z�sk�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Z�skej komponentu XPManager z hr��e
            XPManager xpManager = other.GetComponent<XPManager>();
            if (xpManager != null)
            {
                xpManager.AddXP(xpAmount); // P�idej XP hr��i
            }
        }
    }
}