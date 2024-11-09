using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmenaSvetla : MonoBehaviour
{   
    public Light Svetlo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Svetlo.color = Color.red;
        }
    }
}
