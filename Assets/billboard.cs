using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : NetworkBehaviour
{

    // Standard Billboard script which makes canvas objects always look
    // at the camera

    object LateUpdate()
    {
            global::System.Object value = transform.LookAt(transform.position + DynamicTextManager.mainCamera.forward);
    }
}
