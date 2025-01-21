using UnityEngine;

public class Card : MonoBehaviour
{

    [Header("Settings")]
    public SpriteRenderer frontlamge;
    public Animator anim;
    public AudioClip clip;

    AudioSource audioSource;

    [Header("GameObject")]
    public GameObject front;
    public GameObject back;
    
    public int idx = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number)
    {
        idx = number;
        frontlamge.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
    public void OpenCard()
    {
        // 다른 효과음끼리 겹치지 않음
        audioSource.PlayOneShot(clip);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        // 첫 카드가 비었다면
        if (GameManager.Instance.firstCard == null)
        {
            // 첫 카드를 내 정보를 넘겨준다
            GameManager.Instance.firstCard = this;
        }
        // 비어있지 않다면
        else
        {
            // 두번째 카드에 내 정보를 넘겨준다.
            GameManager.Instance.secondCard = this;
            // Mached 함수를 호출
            GameManager.Instance.Matched();

        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardvoke", 0.5f);
    }

    void DestroyCardvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardvoke", 0.5f);
    }

    void CloseCardvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
