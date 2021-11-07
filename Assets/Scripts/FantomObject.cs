using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomObject : MonoBehaviour {
    public GameObject Fantom;
    public GameObject Monster;
    public GameObject RealObject;
    private bool _isMonster;
    public GameManager gameManager;
    private Coroutine _setMonster;
    void Start() {
        Reset();
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        PlayerControl player;
        if (collision.gameObject.TryGetComponent<PlayerControl>(out player) && _setMonster == null)
            if (player.flashlight.state)
                SetRealObject();
            else {
                _setMonster = StartCoroutine("SetMonster");
                _isMonster = true;
            }
    }
    public void OnTriggerExit2D(Collider2D collision) {
        if (!_isMonster) {
            Debug.Log("jopa");
            Reset();
        }
    }
    public void SetRealObject() {
        Fantom.SetActive(false);
        Monster.SetActive(false);
        RealObject.SetActive(true);
    }
    public void Reset() {
        _isMonster = false;
        _setMonster = null;
        Fantom.SetActive(true);
        Monster.SetActive(false);
        RealObject.SetActive(false);
    }
    IEnumerator SetMonster() {
        yield return new WaitForSeconds(1);

        Fantom.SetActive(false);
        RealObject.SetActive(false);
        Monster.SetActive(true);
        gameManager.StartCoroutine("Death");
    }

}
