using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject menu { get; private set; }

    [SerializeField] private float timeSpawn;
    [SerializeField] private GameObject menuPref;
    [SerializeField] private Transform posSpawn;
    [SerializeField] private Transform posMenu;
    [SerializeField] private Transform posDelete;
    private void Awake()
    {
        menu = null;
    }
    private void OnEnable()
    {
        LaserControl.OnActivateLaser += InstantiateMenuPanel;
        LaserControl.OnDiactivateLaser += DeleteMenuPanel;
    }

    private void OnDisable()
    {
        LaserControl.OnActivateLaser -= InstantiateMenuPanel;
        LaserControl.OnDiactivateLaser -= DeleteMenuPanel;
    }

    private void InstantiateMenuPanel()
    {
        if (menu == null)
        {
            AudioManager.instance.PlaySound("OpenMenu");

            menu = Instantiate(menuPref, posSpawn.position, posSpawn.rotation);
            menu.transform.DOMove(posMenu.position, timeSpawn);
            menu.transform.DOScale(0.01f, timeSpawn);
        }
    }

    public void DeleteMenuPanel()
    {
        if (menu != null)
        {
            AudioManager.instance.PlaySound("CloseMenu");

            menu.transform.DOScale(0f, timeSpawn);
            menu.transform.DOMove(posDelete.position, timeSpawn).OnComplete(() => {
                Destroy(menu);
            });
        }
    }
}
