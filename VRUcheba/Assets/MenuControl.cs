using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MenuControl : MonoBehaviour
{
    public GameObject menu { get; private set; }

    [SerializeField] private SteamVR_Action_Boolean steamMenu;

    [SerializeField] private float timeSpawn;
    [SerializeField] private GameObject menuPref;
    [SerializeField] private Transform posSpawn;
    [SerializeField] private Transform posMenu;
    [SerializeField] private Transform posDelete;
    private void Awake()
    {
        menu = null;
    }

    public void InstantiateMenuPanel()
    {
        AudioManager.instance.PlaySound("OpenMenu");

        menu = Instantiate(menuPref, posSpawn.position, posSpawn.rotation);
        menu.transform.DOMove(posMenu.position, timeSpawn);
        menu.transform.DOScale(0.01f, timeSpawn);
    }

    public void DeleteMenuPanel()
    {
        AudioManager.instance.PlaySound("CloseMenu");

        menu.transform.DOScale(0f, timeSpawn);
        menu.transform.
            DOMove(posDelete.position, timeSpawn).
            OnComplete(() => {
            Destroy(menu);
        });
    }

    public void MenuControlling()
    {
        if (steamMenu.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (menu == null)
            {
                InstantiateMenuPanel();
            }
            else if(menu != null)
            {
                DeleteMenuPanel();
            }
        }
    }
}
