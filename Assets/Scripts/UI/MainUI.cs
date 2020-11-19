using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text TimeText;

    private void Update()
    {
        TimeText.text = WorldTimer.Instance.GetCurrentTime();
    }
}
