using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [System.NonSerialized] Camera gameCamera;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameCamera = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBackgroundColor();
    }

    void SetBackgroundColor()
    {
        if (gameManager.points == 10)
        {
            gameCamera.backgroundColor = new Color(65f / 255f, 110f / 255f, 102f / 255f);
        } else if (gameManager.points == 20)
        {
            gameCamera.backgroundColor = new Color(110f / 255f, 98f / 255f, 65f / 255f);
        } else if (gameManager.points == 30)
        {
            gameCamera.backgroundColor = new Color(86f / 255f, 65f / 255f, 110f / 255f);
        } else if (gameManager.points == 40)
        {
            gameCamera.backgroundColor = new Color(65f / 255f, 110f / 255f, 68f / 255f);
        }
        else if (gameManager.points == 50)
        {
            gameCamera.backgroundColor = new Color(110f / 255f, 65f / 255f, 81f / 255f);
        }

    }
}
