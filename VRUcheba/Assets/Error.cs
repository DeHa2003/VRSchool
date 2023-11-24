using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Error : MonoBehaviour
{
    [SerializeField] private Task task;
    [SerializeField] private int attempt = 10;
    [SerializeField] private TextMeshProUGUI textAttempt;

    private void Awake()
    {
        textAttempt.text = attempt.ToString();
    }

    public void ChangeAttempts()
    {
        if(attempt > 0)
        {
            attempt -= 1;
            Change();
            return;
        }

        if(attempt == 0)
        {
            task.CancelTask();
        }
    }

    public void IncreaseAttempts(int value)
    {
        attempt += value;
        Change();
    }

    private void Change()
    {
        textAttempt.text = attempt.ToString();
    }
}
