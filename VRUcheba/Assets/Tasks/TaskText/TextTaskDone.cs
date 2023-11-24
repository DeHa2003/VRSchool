using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTaskDone : MonoBehaviour
{
    [SerializeField] protected string doneText;
    [SerializeField] protected Color color;
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected GameObject galka;

    public virtual void TaskDone()
    {
        galka.SetActive(true);
        text.color = color;
        text.text = doneText;
    }
}
