using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject thisPanel;
    [SerializeField] GameObject thatPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HideThisOpenThat()
    {
        thisPanel.SetActive(false);
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
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {

    }

    public void Share()
    {

    }
}
