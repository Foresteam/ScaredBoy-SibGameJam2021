using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public bool state { get; private set; }
    public void On() {
        state = true;
        gameObject.SetActive(true);
    }
    public void Off() {
        state = false;
        gameObject.SetActive(false);
    }
}