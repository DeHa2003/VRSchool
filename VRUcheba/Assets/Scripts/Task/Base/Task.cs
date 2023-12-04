using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] protected List<GameObject> VRObjects;
    [SerializeField] protected DiactivateVRObject diactivateObjs;

    private TaskUIManager manager;
    protected void Awake()
    {
        manager = FindObjectOfType<TaskUIManager>();
    }
    public virtual void CompletedTask()
    {
        foreach (var item in VRObjects)
        {
            diactivateObjs.DetachObject(item);
            Destroy(item);
        }

        AudioManager.instance.PlaySound("CompletedGame");

        manager.Congratulations();

        Destroy(gameObject);
    }

    public virtual void CancelTask()
    {
        AudioManager.instance.PlaySound("LooseGame");
        manager.CancelTask();
    }
}
