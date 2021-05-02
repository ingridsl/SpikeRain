using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject thisPanel;
    [SerializeField] GameObject[] thosePanel;
    [SerializeField] GameObject thatPanel;

    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void HideThisOpenThose()
    {
        foreach (var toHide in thosePanel)
        {
            toHide.SetActive(true);
        }
        thisPanel.SetActive(false);
    }

    public void HideThisOpenThat()
    {
        foreach (var toHide in thosePanel)
        {
            toHide.SetActive(false);
        }
        thatPanel.SetActive(true);
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        gameManager.isPlaying = false;
        thisPanel.transform.DOMove(new Vector3(thisPanel.transform.position.x, 5000, 0), 4).SetEase(Ease.OutSine);

        foreach (var thatPanel in thosePanel)
        {
            thatPanel.transform.DOMove(new Vector3(thatPanel.transform.position.x, -500, 0), 4).SetEase(Ease.OutSine);
        }

        StartCoroutine(OpenGame());
    }

    private IEnumerator OpenGame()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(thisPanel);
        SceneManager.LoadScene("GameScene");
    }

    public void OnOffMusic()
    {
        var musicOn = Convert.ToBoolean(PlayerPrefs.GetInt("music", 1));
        PlayerPrefs.SetInt("music", Convert.ToInt32(!musicOn));
    }

    public void OnOffSound()
    {
        var soundOn = Convert.ToBoolean(PlayerPrefs.GetInt("sound", 1));
        PlayerPrefs.SetInt("sound", Convert.ToInt32(!soundOn));
    }

    public void Share()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }


    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("I played Emoji vs Spike").SetText("That was my score!").SetUrl("https://github.com/yasirkula/UnityNativeShare")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();

        //Share on WhatsApp only, if installed(Android only)
        if (NativeShare.TargetExists("com.whatsapp"))
        {
            new NativeShare().AddFile(filePath).AddTarget("com.whatsapp").Share();
        }
    }
}
