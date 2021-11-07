using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomObject : MonoBehaviour
{
    public GameObject Fantom;
    public GameObject Monstr;
    public GameObject RealObject;
    private bool _setReal;
    public GameManager gameManager;
    void Start()
    {
        Fantom.SetActive(true);
        RealObject.SetActive(false);
        Monstr.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerControl>()._flashlight.gameObject.active == true)
            {
                SetRealObject();
            }
            else
            {
                StartCoroutine("SetMonstr");
            }
        }
    }
    public void SetRealObject()
    {
        Fantom.SetActive(false);
        RealObject.SetActive(true);
    }
    IEnumerator SetMonstr()
    {
        yield return new WaitForSeconds(1);

        Fantom.SetActive(false);
        Monstr.SetActive(true);
        gameManager.StartCoroutine("Death");
    }

}
