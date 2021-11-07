using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform gameObjectToFollow;
    public Transform levelMinX, levelMaxX;
    private float _minX, _maxX;
    public Vector3 offset;

    void Start() {
        _minX = levelMinX.position.x;
        _maxX = levelMaxX.position.x;
    }

    void FixedUpdate()
    {
        Vector3 newPos = gameObjectToFollow.position + offset;
        transform.position = newPos;
        var cam = GetComponent<Camera>();
        float xCenterOffest = (cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)) - cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).x;
        float xOkMin = _minX + xCenterOffest;
        float xOkMax = _maxX - xCenterOffest;
        float xFuckupMin = cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float xFuckupMax = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        
        if (xFuckupMin <= _minX)
            newPos.x = xOkMin;
        if (xFuckupMax >= _maxX)
            newPos.x = xOkMax;

        transform.position = newPos;
    }
}
