using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public void On() {
        gameObject.SetActive(true);
    }
    public void Off() {
        gameObject.SetActive(false);
    }
}