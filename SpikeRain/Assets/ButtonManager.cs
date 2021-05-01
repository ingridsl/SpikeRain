using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
        thisPanel.transform.DOMove(new Vector3(1500, thisPanel.transform.position.y, 0), 5);
        StartCoroutine(OpenGame());
    }

    private IEnumerator OpenGame()
    {
        yield return new WaitForSeconds(4);
        Destroy(thisPanel);
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {

    }

    public void Share()
    {

    }
}
