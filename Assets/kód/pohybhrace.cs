using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PohybHrace : NetworkBehaviour
{
    CharacterController characterController;
    public float Speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer) return;

        float pohybX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float pohybY = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 pohyb = (transform.forward * pohybY) + (transform.right * pohybX);
        characterController.SimpleMove(pohyb);

    }
}