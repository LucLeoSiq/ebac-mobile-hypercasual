using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;
using UnityEditor;

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

    public GameObject endScreen;

    [Header("Text")]
    public TextMeshPro uiTextPowerUp;
    
    public bool invincible = false;

    [Header("Coin Setup")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("VFXs")]
    public ParticleSystem vfxDeath;

    [Header("Limits")]
    public float limit = 4;
    public Vector2 playerLimitVector = new Vector2(-4, 4);

    [SerializeField] private BounceHelper _bounceHelper;

    // Private Variables
    private bool _canRun;
    [SerializeField]private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7;

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return; 

        _pos = lerpTarget.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if (_pos.x < playerLimitVector.x) _pos.x = playerLimitVector.x;
        else if (_pos.x > playerLimitVector.y) _pos.x = playerLimitVector.y;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
       
    }


    public void Bounce()
    {
        if(_bounceHelper != null)
        {
            _bounceHelper.Bounce();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invincible)
            {
                MoveBack();
                EndGame(AnimatorManager.AnimationType.DEAD);
                Debug.Log("Player collided with: " + collision.transform.tag);
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

    private void MoveBack()
    {
        transform.DOMoveZ(-1f, .3f).SetRelative(); 
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
        if (vfxDeath != null)
        {
            Debug.Log("Play Death particle");
            vfxDeath.Play();
        } 
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
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

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration); 
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
}
