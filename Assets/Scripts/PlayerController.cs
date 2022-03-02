using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    private CharacterController controller;
    private Vector3 startPos;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        controller.Move(moveSpeed * Time.deltaTime * new Vector3(x, 0, z));    
    }

    public void Kill()
    {
        controller.enabled = false;
        transform.position = startPos;
        controller.enabled = true;
    }
}
