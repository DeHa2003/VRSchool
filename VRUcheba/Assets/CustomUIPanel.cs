using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomUIPanel : MonoBehaviour
{
    [SerializeField] private Image image;
    void Start()
    {
        image.DOColor(Random.ColorHSV(), 3).SetLoops(-1);
    }
}
