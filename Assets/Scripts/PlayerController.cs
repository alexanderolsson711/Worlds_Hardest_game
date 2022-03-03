using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float turnSpeed = 90f;

    private Animator animator;
    private CharacterController controller;
    private Vector3 startPos;
    private int speedHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        speedHash = Animator.StringToHash("Speed");
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Move(new Vector3(x, 0, z));
    }

    public void Move(Vector3 direction)
    {
        direction = direction.sqrMagnitude > 1 ? direction.normalized : direction;
        float speed = direction.sqrMagnitude;
        float moveStep = moveSpeed * Time.deltaTime;
        if (IsMovePossible(direction, moveStep))
        {
            controller.Move(moveStep * direction);
        }

        if (speed > 0)
        {
            Turn(direction);
        }

        animator.SetFloat(speedHash, speed);
    }

    private bool IsMovePossible(Vector3 direction, float moveStep)
    {
        Vector3 edgePos = transform.position + (controller.radius + moveStep) * direction.normalized;
        return Physics.Raycast(edgePos, Vector3.down, controller.height);
    }

    private void Turn(Vector3 direction)
    {
        float rotateStep = turnSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation,
                            Quaternion.LookRotation(direction), rotateStep);
    }

    public void Kill()
    {
        controller.enabled = false;
        transform.position = startPos;
        controller.enabled = true;
    }
}
