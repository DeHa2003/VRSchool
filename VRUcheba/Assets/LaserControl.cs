using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserControl : MonoBehaviour
{
    public static Action OnActivateLaser;
    public static Action OnDiactivateLaser;

    [SerializeField] SteamVR_Action_Boolean steamLaser;
    [SerializeField] private List<GameObject> hands;

    private bool isActiveLaser = false;

    public void AddLaserPointer()
    {
        isActiveLaser = true;

        if (!hands[0].GetComponent<PlayerLaser>())
        {
            for (int i = 0; i < hands.Count; i++)
            {
                hands[i].AddComponent<PlayerLaser>();
            }
        }
    }

    public void RemoveLaserPointer()
    {
        isActiveLaser = false;

        if (hands[0].GetComponent<PlayerLaser>())
        {
            for (int i = 0; i < hands.Count; i++)
            {
                Destroy(hands[i].GetComponent<PlayerLaser>());
            }
        }
    }

    private void Update()
    {
        if (steamLaser.GetStateDown(SteamVR_Input_Sources.Any) && !isActiveLaser)
        {
            OnActivateLaser?.Invoke();
            AddLaserPointer();
        }
        else if (steamLaser.GetStateDown(SteamVR_Input_Sources.Any) && isActiveLaser)
        {
            OnDiactivateLaser?.Invoke();
            RemoveLaserPointer();
        }
    }
}
