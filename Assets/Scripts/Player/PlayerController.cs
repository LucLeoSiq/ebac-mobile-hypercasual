using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Variables
    [Header("Lerp")]
    public Transform lerpTarget;
    public float lerpSpeed = 1f;

    [Header("Player Speed")]
    public float forwardSpeed = 1f;

    [Header("Tags Setup")]
    public string tagToCheckEnemy = "Enemy";

    public GameObject endScreen;

    // Private Variables
    private bool _canRun;
    private Vector3 _pos;

    void Update()
    {
        if (_canRun)
        {
            _pos = lerpTarget.position;
            _pos.y = transform.position.y;
            _pos.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
            transform.Translate(transform.forward * forwardSpeed * Time.deltaTime);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            EndGame(); 
        } 
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true; 
    }
}
