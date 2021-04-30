using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject coinPrefab;

    [System.NonSerialized] public float bombWaitTime = 0.6f;
    [System.NonSerialized] public float coinWaitTime = 4f;

    public bool isPlaying = true;
    bool hasSpeedUpdate = false;

    public int points = 0;
    [SerializeField] GameObject pointsTextObj;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BombInstantiate());
        StartCoroutine(CoinInstantiate());
    }

    // Update is called once per frame
    void Update()
    {
        DOTween.Validate();
        //só se quiser alterar a velocidade que cai as bombas
        //if (hasSpeedUpdate)
        //{
        //    hasSpeedUpdate = false;
        //    StartCoroutine(BombInstantiate());
        //}
        if (pointsTextObj != null)
        {
            var pointsText = pointsTextObj.GetComponent<TextMeshProUGUI>().text;
            if (pointsText != points.ToString())
            {
                pointsTextObj.GetComponent<TextMeshProUGUI>().text = points.ToString();
                StartCoroutine(PumpScore());
            }
        }
    }
    private IEnumerator PumpScore()
    {
        pointsTextObj.GetComponent<Animator>().SetBool("addPoints", true);
        yield return new WaitForSeconds(0.5f);
        pointsTextObj.GetComponent<Animator>().SetBool("addPoints", false);
    }

    private IEnumerator BombInstantiate()
    {
        while (isPlaying && !hasSpeedUpdate)
        {
            var bomb = Instantiate(bombPrefab);
            bomb.transform.position = new Vector3(Random.Range(-0.4f, 0.4f), 0.871f, 0);
            yield return new WaitForSeconds(bombWaitTime);
        }
    }

    private IEnumerator CoinInstantiate()
    {
        while (isPlaying)
        {
            var coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector3(Random.Range(-0.4f, 0.4f), 0.871f, 0);
            yield return new WaitForSeconds(coinWaitTime);
        }
    }
}
