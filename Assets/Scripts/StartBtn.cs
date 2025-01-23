using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void gotutorial()
    {
        PlayerPrefs.SetInt("isTutorial", System.Convert.ToInt16(false));
        Invoke("invokegotutorial", 0.2f);
    }

    private void invokegotutorial()
    {
        SceneManager.LoadScene("MainScene");
    }
}
