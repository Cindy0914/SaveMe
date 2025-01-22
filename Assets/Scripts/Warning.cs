using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{

    void Start()
    {
        transform.position = new Vector3(0f, 3f, 0f);
        transform.localScale = new Vector3(1f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.y < 1)
        {
            transform.localScale += new Vector3(0f, 2f, 0f) * Time.deltaTime;
        }

        transform.position += new Vector3(-3f, 0f, 0f) * Time.deltaTime;
    }
}
