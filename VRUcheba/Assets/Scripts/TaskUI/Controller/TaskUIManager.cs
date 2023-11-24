using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _cancelTask;

    private TaskUI _taskUI;

    public void CancelTask()
    {
        if(_taskUI == null) { return; }

        _taskUI.Cancel();
        _taskUI = null;
        _cancelTask.SetActive(false);
    }

    public void Congratulations()
    {
        if (_taskUI == null) { return; }

        _taskUI.Congratulate();
        _taskUI = null;
        _cancelTask.SetActive(false);
    }

    public void PlayTask(TaskUI taskUI)
    {
        if (_taskUI != null)
        {
            CancelTask();
        }
        _taskUI = taskUI;
        _taskUI.Play();
        _cancelTask.SetActive(true);

    }
}
