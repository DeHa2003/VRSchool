using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Task")]
public class Task_Data : ScriptableObject, ITask
{
    public string nameTask => taskName;

    public GameObject buttonPlay => button;

    public GameObject textCongrate => text;

    public TextMeshProUGUI nameTaskText => textTaskName;

    [SerializeField] private string taskName;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI textTaskName;
}
