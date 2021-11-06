using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionFollowing : MonoBehaviour
{
    public Vector3 mousePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        gameObject.transform.LookAt(mousePosition);
    }
}


