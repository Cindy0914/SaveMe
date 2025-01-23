using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private AudioSource BtnSource;
    public AudioClip ButtonClip;

    private void Start()
    {
        BtnSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        BtnSource.PlayOneShot(ButtonClip);
    }
    
    public void GoTutorial()
    {
        PlayerPrefs.SetInt("isTutorial", System.Convert.ToInt16(false));
        Invoke(nameof(InvokeGoTutorial), 0.2f);
    }

    private void InvokeGoTutorial()
    {
        SceneManager.LoadScene("MainScene");
    }
}
