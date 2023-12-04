using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaneDetect
{
    protected CharacterController characterController;
    protected AudioSource sourceFeet;

    protected float dependenceVolume = 2;
    protected float dependencePitch = 1;

    public virtual void OnWalk(AudioClip audioClip)
    {
        if (characterController.velocity.magnitude <= 0.1 || Time.deltaTime == 0)
        {
            sourceFeet.clip = null;
        }
        else
        {
            if (sourceFeet.clip != audioClip)
            {
                sourceFeet.clip = audioClip;
                sourceFeet.Play();
            }
            sourceFeet.volume = characterController.velocity.magnitude / dependenceVolume;
            sourceFeet.pitch = characterController.velocity.magnitude / dependencePitch;
        }
    }
}
