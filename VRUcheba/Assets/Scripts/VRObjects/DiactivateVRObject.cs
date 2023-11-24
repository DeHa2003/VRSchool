using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DiactivateVRObject : MonoBehaviour
{
    [SerializeField] private Transform parentObj;

    private Hand hand;
    public void DestroyHandObject(GameObject attachedObj)
    {
        hand = attachedObj.transform.parent.GetComponent<Hand>();
        hand.DetachObject(attachedObj, attachedObj.GetComponent<Throwable>().restoreOriginalParent);
        Destroy(attachedObj.GetComponent<Throwable>());
        Destroy(attachedObj.GetComponent<Rigidbody>());
        attachedObj.transform.parent = parentObj.parent;
    }
    public void DetachObject(GameObject attachedObj)
    {
        if (attachedObj.transform.parent.GetComponent<Hand>())
        {
            hand = attachedObj.transform.parent.GetComponent<Hand>();
            hand.DetachObject(attachedObj, attachedObj.GetComponent<Throwable>().restoreOriginalParent);
        }
    }
}
