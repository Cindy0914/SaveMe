using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] private List<Profile> profiles = new();
    [SerializeField] private TimePanel timePanel;

    public List<string> names = new();
    [TextArea(5, 10)]
    public List<string> descriptions = new();

    public void Start()
    {
        InitTimePanel();
        InitProfile();

        StopAllCoroutines();
        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            var description = descriptions[i];
            var name = names[i];
            StartCoroutine(ShowTextOneByOne(profile, description, name));
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
        const int teamCount = 4;
        if (profiles.Count != teamCount)
        {
            Debug.LogWarning("Profiles count mismatch");
            return;
        }
        if (descriptions.Count != teamCount)
        {
            Debug.LogWarning("descriptions count mismatch");
            return;
        }
        if (names.Count != teamCount)
        {
            Debug.LogWarning("names count mismatch");
            return;
        }

        for (int i = 0; i < profiles.Count; i++)
        {
            var profile = profiles[i];
            profile.tmpDesc.text = string.Empty;
            profile.tmpName.text = string.Empty;
            profile.picture_01.SetActive(false);
            profile.picture_02.SetActive(false);
        }
    }

    private IEnumerator ShowTextOneByOne(Profile profile, string description, string name)
    {
        yield return StartCoroutine(ShowPicture(profile));
        yield return StartCoroutine(ShowTextName(profile, name));
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
        profile.picture_02.SetActive(true);
    }

    private IEnumerator ShowTextName(Profile profile, string name)
    {
        foreach (var letter in name)
        {
            profile.tmpName.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}