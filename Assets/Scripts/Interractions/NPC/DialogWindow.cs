using System.Collections;
using UnityEngine;

public class DialogWindow : MonoBehaviour {
    private Coroutine _autoHide = null;
    public float hideAfter = 5;

    void Start() {
        Hide();
    }

    private IEnumerator AutoHide() {
        float timeElapsed = 0;
        while (timeElapsed < hideAfter) {
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Hide();
    }

    public void Show() {
        if (_autoHide != null)
            StopCoroutine(_autoHide);
        gameObject.SetActive(true);
        _autoHide = StartCoroutine("AutoHide");
    }
    public void Hide() {
        gameObject.SetActive(false);
    }
}