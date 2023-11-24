using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TriggerRazborka : MonoBehaviour
{
    [SerializeField] private int numberStepThisObj;
    [SerializeField] private DiactivateVRObject diactivateObj;
    [SerializeField] private Score score;
    [SerializeField] private TextTaskDone taskDone;

    [SerializeField] private GameObject doubleThis;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == doubleThis)
        {
            if(score.ScoreCount == numberStepThisObj)
            {
                score.Increase();
                taskDone.TaskDone();
                Destroy(gameObject);
            }
            else
            {
                other.gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
                diactivateObj.DetachObject(other.gameObject);
            }
        }
    }
}
