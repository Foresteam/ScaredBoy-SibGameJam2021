using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform gameObjectToFollow;
    public float followSpeed;
    public Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 NewPosition = gameObjectToFollow.position + offset;
        gameObject.transform.position = NewPosition;
    }
}
