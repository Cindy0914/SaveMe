using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        // MainScene으로 이동
        SceneManager.LoadScene("MainScene");

        // // Main BGM 재생
        // if (AudioManager.Instance != null)
        // {
        //     AudioManager.Instance.PlayBGM();
        // }
    }
}