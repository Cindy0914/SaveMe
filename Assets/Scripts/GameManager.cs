using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Card firstCard;
    public Card secondCard;
    [Header("Settings")]
    public Text TimeTxt;
    public GameObject EndTxt;
    public int CardCount = 0;

    public AudioClip audioClip;

    AudioSource audioSource;

    float time = 0.0f;

    public void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimeTxt.text = time.ToString("N2");
        if (time > 30.0f)
        {
            EndTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(audioClip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            CardCount -= 2;
            if(CardCount == 0)
            {
                Time.timeScale = 0.0f;
                EndTxt.SetActive(true);
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
