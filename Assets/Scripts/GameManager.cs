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
    bool isWarning = false;

    float time = 0f;
    float timeshow = 0f;

    public Animator StartAnim;
    bool startgame = false;
    bool isEnd = false;

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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        if (!System.Convert.ToBoolean(PlayerPrefs.GetInt("isTutorial")))
        {
            Invoke("StartGame", 5f);
        }
        else
        {
            Invoke("StartGame", 1.5f);
        }

        StartAnim.SetBool("istutorial", System.Convert.ToBoolean(PlayerPrefs.GetInt("isTutorial")));

        PlayerPrefs.SetFloat("clearTime", 0f);

        audioSource = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startgame)
        {
            Destroy(startAni);
            board.enabled = true;

            if (!isWarning && time >= 20f)
            {
                Instantiate(WarningObject);
                isWarning = true;
                audioSource.PlayOneShot(Waring);
            }
            if (isEnd) { }
            else if (time >= 30f)
            {
                time = 30f;
                endGame();
            }
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
        if(board != null)
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
            //audioSource.PlayOneShot(matchclip);
            Invoke("callSuccessSound", 0.5f);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                isEnd = true;
                Invoke("successGame", 1f);
            }
        }
        else
        {
            //audioSource.PlayOneShot(mismatchclip);
            Invoke("callfailsSound", 0.5f);
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
