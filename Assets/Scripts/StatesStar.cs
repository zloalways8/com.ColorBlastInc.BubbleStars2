using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StatesStar : MonoBehaviour
{

    public int diffStar = 0;
    public int levelStar = 1;
    public bool musicIsOnStar = true;
    public bool soundIsOnStar = true;
    public AudioSource themeStar;
    static bool oncePlayStar = true;

    public float TimerModStar = 1f;


    public int CurrentTheme = 0;
    public bool ThemeBlackBought = false;
    public bool ThemeBlueBought = false;
    public int coinsStar = 0;



    public void ChangeMusicSoundStar()
    {
        musicIsOnStar=!musicIsOnStar;

        if(musicIsOnStar)
            themeStar.volume = 1f;
        else themeStar.volume = 0; 

    }



    void Start()
    {
        if (oncePlayStar)
        {
            themeStar.Play();
            oncePlayStar = false;
        }
        themeStar = GetComponent<AudioSource>();

        var checkBlack = PlayerPrefs.GetInt("blackArcade");
        if (checkBlack > 0) ThemeBlackBought = true;

        var checkBlue = PlayerPrefs.GetInt("blueArcade");
        if (checkBlue > 0) ThemeBlueBought = true;

        var checkCoins = PlayerPrefs.GetInt("coinsArcade");
        if (checkCoins > 0) coinsStar = checkCoins;

        var timerMode = PlayerPrefs.GetFloat("timerArcade");
        if (timerMode > 1f) TimerModStar = timerMode;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {


        if (!themeStar.isPlaying)
        {

            themeStar.Play();
        }
    }
}
