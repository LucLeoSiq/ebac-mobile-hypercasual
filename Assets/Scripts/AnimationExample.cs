using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{
    public Animation animationModel;
    public AnimationClip runClip;
    public AnimationClip idleClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAnimation(runClip);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimation(idleClip);
        }
    }

    private void PlayAnimation(AnimationClip clip)
    {
        animationModel.clip = clip;
        animationModel.Play();
    }
}
