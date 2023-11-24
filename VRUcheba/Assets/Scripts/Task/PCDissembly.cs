using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDissembly : Task
{
    private void Start()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        transform.DOScale(4, 0.5f);
    }
}
