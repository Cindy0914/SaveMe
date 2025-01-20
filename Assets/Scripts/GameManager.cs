using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text TimeTxt;

    float time = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        
    }


    void Update()
    {
        time += Time.deltaTime * 10f;
        TimeTxt.text = time.ToString("00.00");

        /*if (time >= 30f)
        {
            time = 30f;
            TimeTxt.text = time.ToString("00.00");
            endGame();
        }
        else
        {
            time += Time.deltaTime;
            TimeTxt.text = time.ToString("00.00");
        }*/
    }
}
