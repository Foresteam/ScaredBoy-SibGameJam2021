using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Dvornik : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public GameManager gameManager;
    public GameObject ScreemAudio;
    public bool IsRealObject;
    void Start()
    {
        ScreemAudio.SetActive(false);
        skeletonAnimation.AnimationName = "dvornik3";
    }

    public void MakeMonster()
    {
        skeletonAnimation.AnimationName = "dvornik1";
        gameManager.StartCoroutine("Death");
        ScreemAudio.SetActive(true);
    }
}
