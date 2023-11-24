using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface ITask
{
    string nameTask { get; }
    TextMeshProUGUI nameTaskText { get; }
    GameObject buttonPlay { get; }
    GameObject textCongrate { get; }
}
