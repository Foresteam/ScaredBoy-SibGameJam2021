using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Image DeathScreen;
    public float FadingSpeed;
    public float a = 0;
    public IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        for (float i = 0; i < 0.8f; i += 0.01f)
        {
            a += i;
            yield return new WaitForSeconds(0.04f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        DeathScreen.color = new Color(0, 0, 0, a);
    }
}
