using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    //public Animator Anim;

    //AudioSource audioSource;
    //public AudioClip clip;

    // public SpriteRenderer frontImage;
    public UnityEngine.UI.Image Aimage;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        // frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
        // Aimage.sprite = Resources.Load<Sprite>($"rtan{idx}");
        Aimage.sprite = Resources.Load<Sprite>($"C{idx}");
    }

    public void OpenCard()
    {
        //audioSource.PlayOneShot(clip);

        //Anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

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
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        //Anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
