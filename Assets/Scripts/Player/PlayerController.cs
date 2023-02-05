using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    // Public Variables
    [Header("Lerp")]
    public Transform lerpTarget;
    public float lerpSpeed = 1f;

    [Header("Player Speed")]
    public float forwardSpeed = 1f;

    [Header("Tags Setup")]
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckFinishLine = "EndLine";

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    public GameObject endScreen;
    public bool invincible = false;

    // Private Variables
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;

    private void Start()
    {
        ResetSpeed();
    }

    void Update()
    {
        if (_canRun)
        {
            _pos = lerpTarget.position;
            _pos.y = transform.position.y;
            _pos.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
            transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invincible)
            {
                EndGame();
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheckFinishLine)
        {
            if (!invincible)
            {
                EndGame();
            }
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

    // POWER-UPS
    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void SetInvincible(bool b)
    {
        invincible = b;
    }

    public void ResetSpeed()
    {
        _currentSpeed = forwardSpeed;
    }
}
