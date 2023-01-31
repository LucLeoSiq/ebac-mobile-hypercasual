using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float forwardSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.forward  * forwardSpeed * Time.deltaTime); 
    }
}
