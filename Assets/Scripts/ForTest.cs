using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("isTutorial", System.Convert.ToInt16(false));
    }
}
