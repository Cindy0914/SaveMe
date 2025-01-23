using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAni : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;
    public float startTime = 2f; // 시작 시간
    public float duration = 0.4f; // 재생할 시간
    public float delayTime = 0.23f; // 대기 시간 (2초)

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.clip;

        // 2초 대기 후 PlayClipPart 실행
        StartCoroutine(PlayClipWithDelay(delayTime));
    }

    IEnumerator PlayClipWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 2초 대기
        StartCoroutine(PlayClipPart(audioSource, startTime, duration)); // 2초 후 특정 구간 재생
    }

    IEnumerator PlayClipPart(AudioSource source, float start, float length)
    {
        source.time = start; // 시작 시간 설정
        source.Play(); // 재생
        yield return new WaitForSeconds(length); // 설정한 길이만큼 대기
        source.Stop(); // 재생 정지
    }
}
