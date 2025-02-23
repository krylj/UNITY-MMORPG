using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : NetworkBehaviour
{

    // Standard Billboard script which makes canvas objects always look
    // at the camera

    void LateUpdate()
    {
        if (!isServer) return; // Zajist�, �e se k�d spust� jen na serveru

        if (Camera.main != null) // Ov���, zda kamera existuje
        {
            transform.LookAt(transform.position + Camera.main.transform.forward);
        }
    }
}
