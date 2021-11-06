using UnityEngine;

public class Lamp : MonoBehaviour, IInterractable {
    public void Interract(params object[] data) {
        bool state = (bool)data[0];
        gameObject.SetActive(state);
    }
}