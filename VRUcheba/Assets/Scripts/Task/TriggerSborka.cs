using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerSborka : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Score score;
    [SerializeField] private TextTaskDone textTaskDone;
    [SerializeField] private DiactivateVRObject destroyObj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == obj)
        {
            obj.transform.SetPositionAndRotation(transform.position, transform.rotation);
            obj.GetComponent<Throwable>().onDetachFromHand.Invoke();
            obj.tag = "Untagged";
            destroyObj.DestroyHandObject(obj);

            score.Increase();
            textTaskDone.TaskDone();
            Destroy(gameObject);
        }
    }
}
