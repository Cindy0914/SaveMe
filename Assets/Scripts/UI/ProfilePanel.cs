using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] private List<Profile> profiles = new();
    [SerializeField] private TimePanel timePanel;
    
    [TextArea(5, 10)] public List<string> descriptions = new();
    
    public void Start()
    {
        InitTimePanel();
        InitProfile();
        
        StopAllCoroutines();
        for (int i = 0; i < profiles.Count; i++)
        {
            StartCoroutine(ShowTextOneByOne(profiles[i], descriptions[i]));
        }
    }

    private void InitTimePanel()
    {
        // var resultTime = GameManager.Instance.GetTime();
        var resultTime = 5;
        timePanel.SetTime(resultTime);
    }

    private void InitProfile()
    {
        if (profiles.Count != descriptions.Count)
        {
            Debug.LogWarning("Profiles and descriptions count mismatch");
            return;
        }
        
        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            profile.tmpDesc.text = string.Empty;
            profile.picture_01.SetActive(false);
            profile.picture_02.SetActive(false);
        }
        
        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            profile.tmpDesc.text = string.Empty;
            profile.picture_01.SetActive(false);
            profile.picture_02.SetActive(false);
        }
    }
    
    private IEnumerator ShowTextOneByOne(Profile profile, string description)
    {
        yield return StartCoroutine(ShowPicture(profile));
        foreach (var letter in description)
        {
            profile.tmpDesc.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator ShowPicture(Profile profile)
    {
        yield return new WaitForSeconds(0.5f);
        
        profile.picture_01.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        profile.picture_02.SetActive(true);
        yield return new WaitForSeconds(0.2f);
    }
}
