using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed;
    public SpriteRenderer PlayerSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
    }
    public void Run()
    {
        Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        gameObject.transform.position += Direction * Speed;
        PlayerSprite.flipX = Direction.x < 0;
    }
}
