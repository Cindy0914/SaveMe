using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text TimeTxt;

    [Header("GameObject")]
    public GameObject endTxt; //End UI

    public GameObject startAni;
    public Board board;

    public int cardCount = 0;

    public GameObject WarningObject;
    private bool isWarning = false;

    private float time = 0f;
    private float timeshow = 0f;

    public Animator StartAnim;
    private bool startgame = false;
    private bool isEnd = false;

    [Header("AudioSource")]
    AudioSource audioSource;

    public AudioClip matchclip;
    public AudioClip mismatchclip;
    public AudioClip Waring;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if (!System.Convert.ToBoolean(PlayerPrefs.GetInt("isTutorial")))
        {
            Invoke(nameof(StartGame), 5f);
        }
        else
        {
            Invoke(nameof(StartGame), 1.5f);
        }

        StartAnim.SetBool("istutorial", System.Convert.ToBoolean(PlayerPrefs.GetInt("isTutorial")));
        PlayerPrefs.SetFloat("clearTime", 0f);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (startgame) 
        {
            Destroy(startAni);
            board.enabled = true;
        
            // 게임 시작 후 20초가 지나면 경고 UI 생성
            if (!isWarning && time >= 20f)
            {
                Instantiate(WarningObject);
                isWarning = true;
                audioSource.PlayOneShot(Waring);
                audioSource.volume = 0.5f;
            }
            // 게임 시작 후 30초가 지나면 게임 오버
            else if (time >= 30f)
            {
                time = 30f;
                endGame();
            }
            // 게임 오버 전까지 시간 증가
            else
            {
                time += Time.deltaTime;
            }

            timeshow = 30f - time;
            TimeTxt.text = timeshow.ToString("00.00");
        }
        else
        {
            time = 0f;
            timeshow = 30f - time;
            TimeTxt.text = timeshow.ToString("00.00");
        }
    }

    private void StartGame()
    {
        if (board != null)
        {
            PlayerPrefs.SetInt("isTutorial", System.Convert.ToInt16(true));
            startgame = true;
        }
    }

    public void endGame()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0f;

        // 메인 BGM 중단
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopBGM();
        }
    }

    public void successGame()
    {
        PlayerPrefs.SetFloat("clearTime", time);
        SceneManager.LoadScene("SuccessScene");
    }

    private void callSuccessSound()
    {
        audioSource.PlayOneShot(matchclip);
    }

    private void callfailsSound()
    {
        audioSource.PlayOneShot(mismatchclip);
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            Invoke(nameof(callSuccessSound), 0.5f);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                isEnd = true;
                Invoke(nameof(successGame), 1f);
            }
        }
        else
        {
            Invoke(nameof(callfailsSound), 0.5f);
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}