using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text TimeTxt;
    public GameObject endTxt; //¾Øµå UI

    public GameObject startAni;
    public Board board;

    public int cardCount = 0;
    public bool isstart = false;

    public GameObject WarningObject;
    bool isWarning = false;

    float time = 0f;

    //AudioSource audioSource;
    //public AudioClip clip;

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

        if (!isstart)
        {
            Invoke("StartGame", 4.4f);
        }

        PlayerPrefs.SetFloat("clearTime", 0f);

        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isstart)
        {
            Destroy(startAni);
            board.enabled = true;

            if (!isWarning && time >= 20f)
            {
                Instantiate(WarningObject);
                isWarning = true;
            }
            if (time >= 30f)
            {
                time = 30f;
                TimeTxt.text = time.ToString("00.00");
                endGame();
            }
            else
            {
                time += Time.deltaTime;
                TimeTxt.text = time.ToString("00.00");
            }
        }
        else
        {
            time = 0f;
            TimeTxt.text = time.ToString("00.00");
        }
    }

    private void StartGame()
    {
        if(board != null)
        {
            isstart = true;
        }
    }

    public void endGame()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0f;
    }

    public void successGame()
    {
        PlayerPrefs.SetFloat("clearTime", time);
        SceneManager.LoadScene("SuccessScene");
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            //audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                successGame();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
