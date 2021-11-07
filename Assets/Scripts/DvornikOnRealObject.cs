using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvornikOnRealObject : MonoBehaviour
{
    public Dvornik dvornik;
    private void OnEnable()
    {
        dvornik.skeletonAnimation.AnimationName = "dvornik5";
        dvornik.IsRealObject = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
