using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void LoadScene()
    {
        // MainScene으로 이동
        SceneManager.LoadScene("MainScene");
    }
}