using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] public float bombWaitTime = 0.6f;
    [SerializeField] public float coinWaitTime = 4f;

    public bool isPlaying = true;
    bool hasSpeedUpdate = false;

    public int points = 0;
    [SerializeField] GameObject pointsTextObj;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.SetTweensCapacity(2000, 1000);
        OnOffAudio();

        DOTween.ClearCachedTweens();
        CallRain();
    }

    public void CallRain()
    {

        StartCoroutine(BombInstantiate());
        StartCoroutine(CoinInstantiate());
    }

    // Update is called once per frame
    void Update()
    {
        //só se quiser alterar a velocidade que cai as bombas
        //if (hasSpeedUpdate)
        //{
        //    hasSpeedUpdate = false;
        //    StartCoroutine(BombInstantiate());
        //}
        Scene scene = SceneManager.GetActiveScene();
        OnOffAudio();

        if (pointsTextObj != null)
        {
            var pointsText = pointsTextObj.GetComponent<TextMeshProUGUI>().text;
            if (pointsText != points.ToString())
            {
                var textMesh = pointsTextObj.GetComponent<TextMeshProUGUI>();
                if (textMesh.text != points.ToString())
                {
                    textMesh.text = points.ToString();
                    StartCoroutine(PumpScore());
                }
            }
        }
        
    }

    private void OnOffAudio()
    {
        //music
        var musicOn = PlayerPrefs.GetInt("music", 1) == 1;
        GameObject.FindWithTag("HasMusic").GetComponent<AudioSource>().enabled = musicOn;

        //sounds
        var soundOn = PlayerPrefs.GetInt("sound", 1) == 1;
        var soundObjs = GameObject.FindGameObjectsWithTag("HasSound");
        foreach (var soundObj in soundObjs)
        {
            soundObj.GetComponent<AudioSource>().enabled = soundOn;
        }
    }

    private IEnumerator PumpScore()
    {
        //pointsTextObj.GetComponent<Animator>().SetBool("addPoints", true);

            var previous = pointsTextObj.transform.localScale;
            var localScale = pointsTextObj.transform.localScale;
            pointsTextObj.transform.DOScale(new Vector3(localScale.x + (localScale.x * 15 / 100), localScale.y + (localScale.y * 15 / 100), localScale.z), 0.2f);
            yield return new WaitForSeconds(0.3f);
            pointsTextObj.transform.DOScale(new Vector3(previous.x, previous.y, previous.z), 0.2f);

        //pointsTextObj.GetComponent<Animator>().SetBool("addPoints", false);
    }

    private IEnumerator BombInstantiate()
    {
        while (isPlaying)
        {
            var bomb = Instantiate(bombPrefab);
            bomb.transform.position = new Vector3(UnityEngine.Random.Range(-0.4f, 0.4f), 0.871f, 0);
            yield return new WaitForSeconds(bombWaitTime);
        }
    }

    private IEnumerator CoinInstantiate()
    {
        while (isPlaying)
        {
            var coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector3(UnityEngine.Random.Range(-0.4f, 0.4f), 0.871f, 0);
            yield return new WaitForSeconds(coinWaitTime);
        }
    }
}
