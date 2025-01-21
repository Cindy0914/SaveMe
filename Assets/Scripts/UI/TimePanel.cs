using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpTime;

    public void SetTime(float time)
    {
        var strTime = time.ToString("F2");
        tmpTime.text = $"TIME : {strTime}";
    }
}
