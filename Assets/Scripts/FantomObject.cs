using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomObject : MonoBehaviour
{
    public GameObject Fantom;
    public GameObject RealObject;
    void Start()
    {
        Fantom.SetActive(true);
        RealObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            SetRealObject();
        }
    }
    public void SetRealObject()
    {
        Fantom.SetActive(false);
        RealObject.SetActive(true);
    }
}
