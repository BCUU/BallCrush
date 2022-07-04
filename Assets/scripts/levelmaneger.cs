using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelmaneger : MonoBehaviour
{
    public Text loadingtext;
    private void Start()
    {
        if (PlayerPrefs.HasKey("LevelIndex") == false)
        {
            PlayerPrefs.SetInt("LevelIndex", 1);


        }
        StartCoroutine("loadingbar");
        levelcontrol();

    }
    public void levelcontrol()
    {
        int level = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadSceneAsync(level);
    }
    public IEnumerator loadingbar()
    {
        while (true)
        {
            loadingtext.text = "LOADING".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingtext.text = "LOADING.".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingtext.text = "LOADING..".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            loadingtext.text = "LOADING...".ToString();
        }
    }
}
