using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void gotutorial()
    {
        PlayerPrefs.SetInt("isTutorial", System.Convert.ToInt16(false));
        SceneManager.LoadScene("MainScene");
    }
}
