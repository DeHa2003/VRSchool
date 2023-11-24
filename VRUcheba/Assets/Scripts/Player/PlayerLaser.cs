using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class PlayerLaser : SteamVR_LaserPointer
{
    private Hand hand;
    private GameObject _attachedObj;
    private LaserGrab laserGrab;
    private void Awake()
    {
        laserGrab = GetComponent<LaserGrab>();
        hand = GetComponent<Hand>();
    }

    public override void OnPointerIn(PointerEventArgs e)
    {
        base.OnPointerIn(e);

        if (e.target.CompareTag("VR"))
        {
            _attachedObj = e.target.gameObject;
            _attachedObj.GetComponent<Interactable>().OnHandHoverBegin(hand);
        }

        if(e.target.TryGetComponent<UIButton>(out var iButton))
        {
            iButton.Select();
        }
    }

    public override void OnPointerClick(PointerEventArgs e)
    {
        base.OnPointerClick(e);

        if(e.target.CompareTag("UI"))
        {
            if(e.target.gameObject.GetComponent<Button>())
            {
                e.target.gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }

        if (e.target.CompareTag("VR"))
        {
            _attachedObj = e.target.gameObject;
            _attachedObj.GetComponent<Interactable>().OnHandHoverEnd(hand);
            laserGrab.GrabObject(_attachedObj);
        }
    }

    public override void OnPointerOut(PointerEventArgs e)
    {
        base.OnPointerOut(e);

        if (e.target.CompareTag("VR"))
        {
            _attachedObj = e.target.gameObject;
            _attachedObj.GetComponent<Interactable>().OnHandHoverEnd(hand);
        }

        if (e.target.TryGetComponent<UIButton>(out var iButton))
        {
            iButton.UnSelect();
        }
    }

    private void OnDestroy()
    {
        Destroy(holder);
    }
}
