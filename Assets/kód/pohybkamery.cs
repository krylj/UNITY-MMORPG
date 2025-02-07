using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybKamery : MonoBehaviour
{

    
    float rotX = 0f;
    float rotY = 0f;
    public Transform Hrac;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mysX = Input.GetAxis("Mouse X");
        float myxY = Input.GetAxis("Mouse Y");

        rotX += mysX;
        rotY -= myxY;

        rotY = Mathf.Clamp(rotY, -91, 90);

        transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        Hrac.transform.rotation = Quaternion.Euler(0, rotX, 0);


    }
}