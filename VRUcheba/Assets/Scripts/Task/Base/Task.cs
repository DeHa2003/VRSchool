using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] protected List<GameObject> VRObjects;
    [SerializeField] protected DiactivateVRObject diactivateObjs;
    public virtual void CompletedTask()
    {
        foreach (var item in VRObjects)
        {
            diactivateObjs.DetachObject(item);
            Destroy(item);
        }

        TaskUIManager taskManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TaskUIManager>();
        taskManager.Congratulations();

        Destroy(gameObject);
    }
}
