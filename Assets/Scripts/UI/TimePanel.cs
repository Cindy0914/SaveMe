using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : MonoBehaviour
{
    [SerializeField] private Text tmpTime;

    public void SetTime(float time)
    {
        var strTime = time.ToString("F2");
        tmpTime.text = $"RECORD\n{strTime}";
    }
}
