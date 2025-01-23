using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioClip textSound;

    [SerializeField] private List<Profile> profiles = new();
    [SerializeField] private TimePanel timePanel;
    [SerializeField] private Button retryButton;

    private readonly WaitForSeconds wait_50ms = new(0.05f);
    private float resultTime;

    public void Start()
    {
        // Sound
        audioSource = GetComponent<AudioSource>();
        AddOnRetryButtonClick();

        // Profile
        InitProfile();
        InitTimePanel();

        // Coroutine
        StopAllCoroutines();
        StartCoroutine(TextCoroutine());
    }

    private void InitTimePanel()
    {
        if (PlayerPrefs.HasKey("clearTime"))
        {
            resultTime = PlayerPrefs.GetFloat("clearTime");
        }

        timePanel.SetTime(resultTime);
    }

    private void InitProfile()
    {
        const int teamCount = 4;
        if (profiles.Count != teamCount)
        {
            Debug.LogWarning("Profiles count mismatch");
            return;
        }

        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            profile.tmpName.gameObject.SetActive(false);
            profile.tmpDesc.gameObject.SetActive(false);
        }
    }

    private IEnumerator TextCoroutine()
    {
        PlayTextSound();
        yield return ShowTextName();
        yield return ShowTextOneByOne();
        StopTextSound();
    }

    private IEnumerator ShowTextOneByOne()
    {
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            var description = profile.tmpDesc.text;
            
            profile.tmpDesc.text = string.Empty;
            profile.tmpDesc.gameObject.SetActive(true);
            foreach (var letter in description)
            {
                profile.tmpDesc.text += letter;
                yield return wait_50ms;
            }
        }
    }

    private IEnumerator ShowTextName()
    {
        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            var nameStr = profile.tmpName.text;
            
            profile.tmpName.text = string.Empty;
            profile.tmpName.gameObject.SetActive(true);
            foreach (var letter in nameStr)
            {
                profile.tmpName.text += letter;
                yield return wait_50ms;
            }
        }
    }

    private void PlayTextSound()
    {
        audioSource.clip = textSound;
        audioSource.Play();
        audioSource.loop = true;
    }

    private void StopTextSound()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.clip = null;
    }

    private void AddOnRetryButtonClick()
    {
        retryButton.onClick.AddListener(() =>
        {
            audioSource.PlayOneShot(buttonSound);
            StartCoroutine(LoadSceneWithDelay());
        });
    }
    
    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(0.2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}