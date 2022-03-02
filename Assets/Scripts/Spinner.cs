using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 90f;

    private void Update()
    {
        transform.Rotate(spinSpeed * Time.deltaTime * Vector3.forward);   
    }
}
