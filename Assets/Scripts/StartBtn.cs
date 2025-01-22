using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void gotutorial()
    {
<<<<<<< HEAD
=======
        PlayerPrefs.SetInt("isTutorial", System.Convert.ToInt16(false));
>>>>>>> main
        SceneManager.LoadScene("MainScene");
    }
}
