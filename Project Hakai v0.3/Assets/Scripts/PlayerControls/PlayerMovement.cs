using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Setup")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform groundDetector;

    //[SerializeField] private AutoLock autoLockInstance;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Transform cam;

    [Header("Movement Parameters")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerJump = 10f;
    [SerializeField] private float gravity = -30f;
    private float groundDistance = 0.2f;

    [Header("Misc.")]
    [SerializeField] private bool enableMove = true;

    private Vector3 velocity;
    [SerializeField] private bool isGrounded;

    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Update()
    {
        if (enableMove) PlayerMove();
    }

    private void PlayerMove()
    {
        // Checking if the player in on ground
        isGrounded = Physics.CheckSphere(groundDetector.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // raw input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = playerJump;
        }

        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (!AutoLock.instance.lockTarget)
            {
                // rotate towards direction of movement
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + /* add cam rotation */ cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // take into account camera direction
                controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
            }
            else
            {
                // face lock target
                transform.LookAt(new Vector3(AutoLock.instance.lockTargetEnemy.transform.position.x, transform.position.y, AutoLock.instance.lockTargetEnemy.transform.position.z));
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + /* add cam rotation */ cam.eulerAngles.y;

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // take into account camera direction
                controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
            }

        }       
    }
}
