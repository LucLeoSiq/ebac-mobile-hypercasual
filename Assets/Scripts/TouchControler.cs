using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControler : MonoBehaviour
{

    public Vector2 objectPastPosition;

    [Header("Movement Speed")]
    public float velocity = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - objectPastPosition.x); 
        }

        objectPastPosition = Input.mousePosition;

    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}
