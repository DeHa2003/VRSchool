using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTaskUI : TaskUI
{
    [SerializeField] private float timeStart;
    [SerializeField] private float timeEnd;

    [SerializeField] private GameObject textProcessing;
    public override void Play()
    {
        PlayAnimation();
        base.Play();
    }

    public override void Congratulate()
    {
        base.Congratulate();
        Destroy(textProcessing);
    }

    public override void Cancel()
    {
        CancelAnimation();
        base.Cancel();
    }

    private void PlayAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0f, timeStart)).InsertCallback(0, Process).Append(transform.DOScale(1f, timeStart));
    }

    private void CancelAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(0f, timeEnd)).
            InsertCallback(0, ()=> textProcessing.SetActive(false)).
            Append(transform.DOScale(1f, timeEnd));
    }

    private void Process()
    {
        textProcessing.SetActive(true);
        textProcessing.transform.Rotate(new Vector3(0, 0, Random.Range(-30f, 30f)));
    }
}
