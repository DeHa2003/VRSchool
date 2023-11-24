using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskUI : MonoBehaviour
{
    [SerializeField] protected GameObject buttonPlay;
    [SerializeField] protected GameObject textCongrate;
    [SerializeField] protected Task task;

    private Task _task;

    public virtual void Play()
    {
        if(task == null) { return; }

        _task = Instantiate(task);
        buttonPlay.SetActive(false);
    }

    public virtual void Congratulate()
    {
        if(_task == null) { Debug.Log("Нет задачи"); return; }
        textCongrate.SetActive(true);
        Destroy(_task.gameObject);
        Destroy(GetComponent<TaskUI>());
    }

    public virtual void Cancel()
    {
        if (_task == null) { Debug.Log("Нет задачи"); return; }
        Destroy(_task.gameObject);
        buttonPlay.SetActive(true);
    }
}
