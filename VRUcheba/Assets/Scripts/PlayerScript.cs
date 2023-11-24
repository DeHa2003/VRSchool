using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerScript : MonoBehaviour
{

    public SteamVR_Action_Vector2 action;
    public SteamVR_Action_Boolean click;
    public Throwable screwdriver;


    private Hand hand;
    private void Update()
    {
        Vector3 vector = Player.instance.hmdTransform.TransformDirection(new Vector3(action.axis.x, 0, action.axis.y));
        transform.position += Vector3.ProjectOnPlane(1f * Time.deltaTime * vector, Vector3.up);

        Hvat();
    }

    private void Hvat()
    {
        if (screwdriver.attached)
        {
            hand = screwdriver.gameObject.transform.parent.GetComponent<Hand>();

            if (click.GetStateDown(hand.handType))
            {
                screwdriver.gameObject.GetComponent<AudioSource>().Play();
            }
            else if (click.GetStateUp(hand.handType))
            {
                screwdriver.gameObject.GetComponent<AudioSource>().Stop();
            }
        }
    }
}
