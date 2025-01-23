using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{

    public AudioSource BgmaudioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        BgmaudioSource = GetComponent<AudioSource>();
        BgmaudioSource.clip = this.clip;
    }
    public void playsound()
    {
        BgmaudioSource?.PlayOneShot(clip);
    }
}
