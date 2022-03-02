using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMover : MonoBehaviour
{
    [SerializeField]
    private Vector3[] targets;

    [SerializeField]
    private float moveSpeed = 4f;

    [SerializeField]
    private float snapDistance = 0.001f;

    private int targetIndex;

    private void Start()
    {
        if (targets.Length < 2)
        {
            enabled = false;
        }
    }

    private void Update()
    {
        Vector3 target = targets[targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < snapDistance)
        {
            transform.position = target;
            targetIndex++;
            if (targetIndex == targets.Length)
            {
                targetIndex = 0;
            }
        }
    }
}
