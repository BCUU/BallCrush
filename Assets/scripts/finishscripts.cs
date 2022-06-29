using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishscripts : MonoBehaviour
{
    public UIManeger uimaneger;
    public void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("moneyy"));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            Debug.Log("level bitti");
            CoinCalculator(100);
            uimaneger.CoinTextuptade();
            uimaneger.finishscreenn();
        }
    }
    public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldscore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldscore + money);
        }
        else
            PlayerPrefs.SetInt("moneyy", 0);
    }
}
