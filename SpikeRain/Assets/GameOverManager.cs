using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject[] toDestroy;
    [SerializeField] GameManager gameManager;

    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI hishScoreText;
    [SerializeField] TextMeshProUGUI score;

    [SerializeField] GameObject menuPanel1;
    [SerializeField] GameObject menuPanel2;


    int highScore;
    // Start is called before the first frame update
    void Start()
    {
        SetGameOverInfo();
        DestroyToDestroy();
        StartCoroutine(MakeAppear());
    }

    private void SetGameOverInfo()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.isPlaying = false;

        var highScore = PlayerPrefs.GetInt("highscore", 0);
        if (gameManager.points > highScore)
        {
            highScore = gameManager.points;
            PlayerPrefs.SetInt("highscore", highScore);
        }
        hishScoreText.text = "Your Best\n" + highScore;
        pointsText.text = gameManager.points.ToString();

        var total = PlayerPrefs.GetInt("total", 0);
        PlayerPrefs.SetInt("total", total + gameManager.points);
    }

    private void DestroyToDestroy()
    {
        foreach (var obj in toDestroy)
        {
            Destroy(obj);
        }
    }

    private IEnumerator MakeAppear()
    {
        yield return new WaitForSeconds(0.6f);

        pointsText.gameObject.SetActive(true);
        hishScoreText.gameObject.SetActive(true);
        score.gameObject.SetActive(true);
        menuPanel1.gameObject.SetActive(true);
        menuPanel2.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
