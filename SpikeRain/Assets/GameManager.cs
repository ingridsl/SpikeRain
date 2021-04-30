using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject coinPrefab;

    [System.NonSerialized] public float bombWaitTime = 0.5f;
    [System.NonSerialized] public float coinWaitTime = 2;

    bool isPlaying = true;
    bool hasSpeedUpdate = false;

    public int points = 0;
    [SerializeField] TextMeshProUGUI pointText;

    // Start is called before the first frame update
    void Start()
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
        pointText.text = points.ToString();
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
