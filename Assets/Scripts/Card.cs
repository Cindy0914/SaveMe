using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Card : MonoBehaviour
{
    public int idx = 0;
    public GameObject front;
    public GameObject back;
    public GameObject ef1, ef2, ef3, ef4;
    
    public Animator Anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
    }
    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Picture{idx}");
    }
    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);
        
        Anim.SetBool("isOpen", true);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.5f);
    }

    void DestroyCardInvoke()
    {
        Anim.SetBool("isCorrect", true);
        Invoke("SpownEffect", 0.5f);
        //Destroy(gameObject);
    }

    void SpownEffect()
    {
        Instantiate(ef1, this.transform);
        Instantiate(ef2, this.transform);
        Instantiate(ef3, this.transform);
        Instantiate(ef4, this.transform);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.7f);
    }
    void CloseCardInvoke()
    {
        Anim.SetBool("isOpen", false);
    }
}