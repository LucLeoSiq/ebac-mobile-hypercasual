using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class TouchControler : MonoBehaviour
{
    public Vector2 objectPastPosition;

    [Header("Movement Speed")]
    public float velocity = 1f;

    public Vector2 playerLimitVector = new Vector2(-4, 4);

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
        Vector3 targetPosition = transform.position + Vector3.right * Time.deltaTime * speed * velocity;

        if (targetPosition.x < playerLimitVector.x) targetPosition.x = playerLimitVector.x;
        else if (targetPosition.x > playerLimitVector.y) targetPosition.x = playerLimitVector.y;

        transform.position = targetPosition;
    }
}
