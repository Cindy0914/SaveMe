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

    public int cardCount = 0;

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

        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 30f)
        {
            time = 30f;
            TimeTxt.text = time.ToString("N2");
            endGame();
        }
        else
        {
            time += Time.deltaTime;
            TimeTxt.text = time.ToString("N2");
        }
    }

    public void endGame()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0f;
    }

    public void successGame()
    {
        SceneManager.LoadScene("SuccessScene1");
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
