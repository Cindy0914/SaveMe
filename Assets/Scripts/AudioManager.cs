using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    AudioSource audioSource;
    public AudioClip startSceneClip; // StartScene용 BGM
    public AudioClip mainSceneClip;  // MainScene용 BGM

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGMForScene(SceneManager.GetActiveScene().name);

        SceneManager.activeSceneChanged += OnSceneChanged;
    }
   private void OnDestroy()
    {
        // 씬 변경 이벤트 해제
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    // 씬 변경 시 호출되는 메서드
    private void OnSceneChanged(Scene current, Scene next)
    {
        PlayBGMForScene(next.name); // 다음 씬 이름에 따라 BGM 변경
    }

    // 씬 이름에 따라 BGM 변경
    private void PlayBGMForScene(string sceneName)
    {
        AudioClip newClip = null;

        if (sceneName == "StartScene")
        {
            newClip = startSceneClip;
        }
        else if (sceneName == "MainScene")
        {
            newClip = mainSceneClip;
        }

        if (newClip != null && audioSource.clip != newClip)
        {
            audioSource.Stop(); // 현재 재생 중인 BGM 정지
            audioSource.clip = newClip; // 새로운 클립 할당
            audioSource.Play(); // 새로운 BGM 재생
        }
    }

    // BGM 중단 메서드
    public void StopBGM()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PlayBGM()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}