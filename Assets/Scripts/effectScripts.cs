using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectScripts : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float z = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, z);

        addforce();
    }

    private void addforce()
    {
        rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
    }
}
