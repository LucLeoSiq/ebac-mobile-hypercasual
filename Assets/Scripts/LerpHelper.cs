using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour
{
    public Transform targetTransform;

    [Header("Movement")]
    public float lerpSpeed = 1f; // Lerp (Linear Interpolation) math function returns value between two others at a point on a linear scale.

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, lerpSpeed * Time.deltaTime); 
    }
}
