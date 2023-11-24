using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloseOpenPanel : MonoBehaviour
{
    public UnityEvent OnOpen;
    public UnityEvent OnClose;

    private void OnEnable()
    {
        OnOpen?.Invoke();
    }

    private void OnDisable()
    {
        OnClose?.Invoke();
    }
}
