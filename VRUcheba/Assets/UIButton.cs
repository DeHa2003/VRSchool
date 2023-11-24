using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private AudioClip selectUISound;
    [SerializeField] private AudioClip clickUISound;

    [SerializeField] private bool isChangeSize = true;
    [SerializeField] private bool isPlaySound = true;
    private Vector3 size;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1;
    }

    private void Start()
    {
        size = transform.localScale;
    }

    public void Select()
    {
        ChangeSize();
        PlaySound(selectUISound);
    }

    public void UnSelect()
    {
        ReturnChanges();
    }

    public void Click()
    {
        PlaySound(clickUISound);
    }

    private void ReturnChanges()
    {
        transform.localScale = size;
    }

    private void ChangeSize()
    {
        if (!isChangeSize) { return; }

        if (size == transform.localScale)
        {
            transform.localScale *= 1.1f;
        }
    }

    private void PlaySound(AudioClip audioClip)
    {
        if (!isPlaySound) { return; }

        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
