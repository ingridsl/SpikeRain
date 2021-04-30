using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject toDestroy;
    [SerializeField] GameManager gameManager;

    [SerializeField] TextMeshProUGUI hishScoreText;

    int highScore;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.isPlaying = false;

        Destroy(toDestroy);

        var highScore = PlayerPrefs.GetInt("highscore", 0);
        if (gameManager.points > highScore)
        {
            highScore = gameManager.points;
            PlayerPrefs.SetInt("highscore", highScore);
        }
        hishScoreText.text = "Best Score\n" + highScore;

        var total = PlayerPrefs.GetInt("total", 0);
        PlayerPrefs.SetInt("total", total + gameManager.points);

        //TODO: SALVAR PONTUA��O
        //TODO: PEGAR RANKING
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}