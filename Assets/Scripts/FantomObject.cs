using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomObject : MonoBehaviour
{
    public GameObject Fantom;
    public GameObject RealObject;
    private bool _setReal;
    void Start()
    {
        _setReal = false;
        Fantom.SetActive(true);
        RealObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Flashlight _;
        if (!_setReal && collision.gameObject.TryGetComponent<Flashlight>(out _))
            SetRealObject();
    }
    public void SetRealObject()
    {
        Fantom.SetActive(false);
        RealObject.SetActive(true);
        _setReal = true;
    }
}
