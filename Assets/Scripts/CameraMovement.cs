using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private VectorConstraint[] constraints;
    [SerializeField] private Transform player;



    private void Update()
    {
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        foreach (VectorConstraint constraint in constraints)
        {
            targetPos = constraint.Constrain(targetPos);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    [Serializable]
    public class VectorConstraint 
    {
        public enum Variable { x, y, z}
        public enum Type { less, greater}

        [SerializeField] private float constraint;
        [SerializeField] private Variable variable;
        [SerializeField] private Type type;

        public Vector3 Constrain(Vector3 v)
        {
            switch (variable)
            {
                case Variable.x:
                    v.x = type == Type.less ? Mathf.Min(v.x, constraint) : Mathf.Max(v.x, constraint);
                    break;
                case Variable.y:
                    v.y = type == Type.less ? Mathf.Min(v.y, constraint) : Mathf.Max(v.y, constraint);
                    break;
                case Variable.z:
                    v.z = type == Type.less ? Mathf.Min(v.z, constraint) : Mathf.Max(v.z, constraint);
                    break;
            }
            return v;
        }
    }
}
