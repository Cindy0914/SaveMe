using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    AudioSource BtnSource;
    public AudioClip clip;

    // Start is called before the first frame update
    
    void Start()
    {
        BtnSource = GetComponent<AudioSource>();
        BtnSource.clip = this.clip;
        BtnSource.PlayOneShot(clip);
    }
}
