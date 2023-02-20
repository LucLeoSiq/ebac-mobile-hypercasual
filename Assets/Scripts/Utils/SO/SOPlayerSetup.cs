using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator player;
    public SOString soStringName;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 10.0f;

    [Header("Animation Setup")]
    //public Ease ease = Ease.OutBack;

    public float jumpScaleY = 1.5f;
    public float jumpScaleX = -1.5f;
    public float animationDuration = .3f;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;

}
