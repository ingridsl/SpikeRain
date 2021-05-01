using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        var gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj != null) {
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
            DOTween.Validate();

            var player = col.gameObject;
            gameManager.points++;

            var audio = player.GetComponent<AudioSource>();
            audio.Play(0);

            Destroy(this.gameObject);
        }
    }
}
