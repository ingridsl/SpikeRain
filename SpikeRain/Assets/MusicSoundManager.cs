using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSoundManager : MonoBehaviour
{
    [SerializeField] GameObject musicButton;
    [SerializeField] GameObject soundButton;

    [SerializeField] Sprite on;
    [SerializeField] Sprite off;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetMusicButton();
        SetSoundButton();
    }

    void SetMusicButton()
    {
        var musicOn = Convert.ToBoolean(PlayerPrefs.GetInt("music", 1));
        if (musicOn)
        {
            musicButton.transform.GetChild(0).GetComponent<Image>().sprite = off;
            musicButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "stop musics";
        }
        else
        {
            musicButton.transform.GetChild(0).GetComponent<Image>().sprite = on;
            musicButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "play musics";
        }
    }
    void SetSoundButton()
    {
        var soundOn = Convert.ToBoolean(PlayerPrefs.GetInt("sound", 1));
        if (soundOn)
        {
            soundButton.transform.GetChild(0).GetComponent<Image>().sprite = off;
            soundButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "stop sounds";
        }
        else
        {
            soundButton.transform.GetChild(0).GetComponent<Image>().sprite = on;
            soundButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "play sounds";
        }
    }
}
