using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManeger : MonoBehaviour
{
    public Image FiilRateImage;
    public GameObject player;
    public GameObject fnishline;
    public Text coin_text;
    public bool radialshine;
    //butonlar
    public GameObject seton;
    public GameObject setof;
    public GameObject layoutbackground;

    public GameObject soundon;
    public GameObject soundoff;
    public GameObject vibon;
    public GameObject viboff;
    public GameObject iap;
    public GameObject info;

    public GameObject introhand;
    public GameObject toptopmove;
    public GameObject noads;
    public GameObject shopbuton;


    public GameObject restartscreen;
    public GameObject finishscreen;
    public GameObject bacground;
    public GameObject complatetitle;
    public GameObject coinfinish;
    public GameObject btn_claim;
    public GameObject btn_no;
    public GameObject coinbackeffect;

    public GameObject achivedcoin;
    public GameObject nextlevel;
    public Text achivedtext;

    public void finishscreenn()
    {
        StartCoroutine("finishlaunch");
    }
    public void Update()
    {
        if (radialshine == true)
        {
            coinbackeffect.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 10f * Time.deltaTime));
        }


        FiilRateImage.fillAmount = (player.transform.position.z) / (fnishline.transform.position.z);
    }





    public IEnumerator finishlaunch()
    {
        Time.timeScale = 0.3f;
        radialshine = true;
        finishscreen.SetActive(true);
        bacground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complatetitle.SetActive(true);
        yield return new WaitForSecondsRealtime(1.2f);
        coinbackeffect.SetActive(true);
        coinfinish.SetActive(true);
        yield return new WaitForSecondsRealtime(0.4f);
        btn_claim.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        btn_no.SetActive(true);



    }
    public IEnumerator afterrewardButton()
    {
        achivedcoin.SetActive(true);
        achivedtext.gameObject.SetActive(true);
        btn_claim.SetActive(false);
        btn_no.SetActive(false);
        for (int i = 0; i < 401; i += 4)
        {
            achivedtext.text = "+" + i.ToString();
            yield return new WaitForSecondsRealtime(0.0001f);

        }
      
        yield return new WaitForSecondsRealtime(0.8f);
        nextlevel.SetActive(true);
      

    }

    public void restartbutonactive()
    {
        restartscreen.SetActive(true);
    }
    public void nextscane()
    {
        Variables.fistouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void scanerestart()
    {
        Variables.fistouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




    public void CoinTextuptade()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void fistouch()
    {
        introhand.SetActive(false);
        toptopmove.SetActive(false);
        layoutbackground.SetActive(false);
        noads.SetActive(false);
        shopbuton.SetActive(false);
        seton.SetActive(false);
        setof.SetActive(false);
        soundon.SetActive(false);
        vibon.SetActive(false);
        viboff.SetActive(false);
        iap.SetActive(false);
        info.SetActive(false);
        soundoff.SetActive(false);

    }
    public void Start()
    {
        if (PlayerPrefs.HasKey("Sounds") == false)
        {
            PlayerPrefs.SetInt("Sounds", 1);
        }
        CoinTextuptade();
    }


    public Image whiteeffectimage;
    private int effectcontrol = 0;
    public Animator Layoutanimator;
    public void privacy_policy()
    {
        Application.OpenURL("www.google.com");
    }
    public void termof_use()
    {
        Application.OpenURL("www.google.com");
    }
    public void layoutsettingsopen()
    {

        seton.SetActive(false);
        setof.SetActive(true);
        Layoutanimator.SetTrigger("slide_in");
        if (PlayerPrefs.GetInt("Sounds") == 1)
        {

            soundon.SetActive(true);
            soundoff.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sounds") == 2)
        {
            soundon.SetActive(false);
            soundoff.SetActive(true);
            AudioListener.volume = 0;
        }
    }
    public void layoutsettingsclose()
    {

        seton.SetActive(true);
        setof.SetActive(false);
        Layoutanimator.SetTrigger("slide_out");
    }
    public IEnumerator whiteffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.01f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.01f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1))
            {
                effectcontrol = 1;
            }


        }
        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.01f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.01f);
        }
        if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
        {
            effectcontrol = 2;
        }
        if (effectcontrol == 2)
        {
            Debug.Log("effect bitti");
        }

    }
    public void sound__on()
    {
        soundon.SetActive(false);
        soundoff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sounds", 2);


    }
    public void sound__off()
    {
        soundon.SetActive(true);
        soundoff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sounds", 1);

    }

    public void vib__on()
    {
        vibon.SetActive(false);
        viboff.SetActive(true);
    }
    public void vib__off()
    {
        vibon.SetActive(true);
        viboff.SetActive(false);
    }

}

