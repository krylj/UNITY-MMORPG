using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.ComponentModel;

public class PohybHrace : NetworkBehaviour
{
    CharacterController characterController;
    public float Speed = 100f;
    public Camera playerCamera;

    public Transform Shoulders;
    public float TurnSpeed = 0.1f;
    public float MovementSpeed = 5.0f;
    public float JumpHeight = 1.0f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public float Gravity = -9.81f;
    Vector3 velocity;

    public bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        // Kontrola, zda jsme na zemi
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;


        if (moveY > 0)
        {
            MovementSpeed = 5.0f;
        }
        else if (moveY < 0)
        {
            MovementSpeed = 2.0f;
        }
        if (moveX > 0)
        {
            MovementSpeed = 3.0f;
        }
        else if (moveX < 0)
        {
            MovementSpeed = 3.0f;
        }


        Vector3 move = transform.right * moveX + transform.forward * moveY;
        characterController.Move(move);


        if (moveX != 0 || moveY != 0)
        {
            Vector3 currentAngles = transform.eulerAngles;
            float targetY = Shoulders.eulerAngles.y;
            float newY = Mathf.LerpAngle(currentAngles.y, targetY, TurnSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(currentAngles.x, newY, currentAngles.z);
        }

        // Skákání
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        velocity.y += Gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public override void OnStartLocalPlayer()
    {
        playerCamera.gameObject.SetActive(true);
    }
}
