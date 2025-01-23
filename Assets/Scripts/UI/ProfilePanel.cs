using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] private List<Profile> profiles = new();
    [SerializeField] private TimePanel timePanel;
    
    private readonly WaitForSeconds wait_100ms = new(0.1f);
    private float resultTime;

    public void Start()
    {
        InitProfile();
        InitTimePanel();

        StopAllCoroutines();
        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            StartCoroutine(ShowTextOneByOne(profile));
        }
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

    private IEnumerator ShowTextOneByOne(Profile profile)
    {
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(ShowTextName(profile));

        var description = profile.tmpDesc.text;
        profile.tmpDesc.text = string.Empty;
        profile.tmpDesc.gameObject.SetActive(true);
        foreach (var letter in description)
        {
            profile.tmpDesc.text += letter;
            yield return wait_100ms;
        }
    }

    private IEnumerator ShowTextName(Profile profile)
    {
        var nameStr = profile.tmpName.text;
        profile.tmpName.text = string.Empty;
        profile.tmpName.gameObject.SetActive(true);
        
        foreach (var letter in nameStr)
        {
            profile.tmpName.text += letter;
            yield return wait_100ms;
        }
    }
}