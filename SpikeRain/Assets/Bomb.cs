using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject deathPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj != null)
        {
            gameManager = gameManagerObj.GetComponent<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            var player = col.gameObject;
            player.SetActive(false);
            
            var explosion = Instantiate(deathPrefab, player.transform.position , Quaternion.identity);

            StartCoroutine(GameOver());

        }
    }

    private IEnumerator GameOver()
    {
        DOTween.Validate();

        yield return new WaitForSeconds(1.5f);
        var gameOver = GameObject.Find("GameOver");
        gameOver.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(2);

        Destroy(this.gameObject);
    }
}
