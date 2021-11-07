using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvornicMakeMonster : MonoBehaviour
{
    public Dvornik dvornik;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && dvornik.IsRealObject == false)
        {
            dvornik.MakeMonster();
        }
    }


}
