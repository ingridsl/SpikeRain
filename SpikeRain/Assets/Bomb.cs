using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject deathPrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            //TODO: SALVAR PONTUAÇÃO

            StartCoroutine(GameOver());

        }
    }

    private IEnumerator GameOver()
    {

        yield return new WaitForSeconds(2);
        //TODO: MOSTRAR TELA DE GAME OVER
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
