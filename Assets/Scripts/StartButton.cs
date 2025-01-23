using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{

    AudioSource BtnSource;
    public AudioClip clip;

    // Start is called before the first frame update
    
    void Start()
    {
        BtnSource = GetComponent<AudioSource>();
        BtnSource.clip = this.clip;
    }
    public void playsound()
    {
        BtnSource.PlayOneShot(clip);
    }
}
