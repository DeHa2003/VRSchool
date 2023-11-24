using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Action OnFallTime;
    [SerializeField] private float timeToLose;
    [SerializeField] private TextMeshProUGUI textTimer;

    private float time;

    private void OnEnable()
    {
        time = timeToLose;
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time > 1)
        {
            Debug.Log("Таймер работает");
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            OnFallTime?.Invoke();
        }
    }
}
